using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ZrokGui
{
    public partial class MainForm : Form
    {
        private Process currentProcess;
        private string zrokExecutablePath = "zrok.exe";
        private readonly string reserveJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reserved_shares.json");

        public MainForm()
        {
            InitializeComponent();
            cmbPublicBackend.SelectedIndex = 0;
            cmbPrivateBackend.SelectedIndex = 0;
            cmbFileMode.SelectedIndex = 0;
            cmbReserveType.SelectedIndex = 0;
            cmbReserveBackend.SelectedIndex = 0;
            CheckZrokInstallation();
            LoadReservedSharesFromJson();
        }

        #region Events
        private void ChkPublicAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtPublicUsername.Enabled = chkPublicAuth.Checked;
            txtPublicPassword.Enabled = chkPublicAuth.Checked;
        }
        private async void BtnPublicShare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublicTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var arguments = $"share public {txtPublicTarget.Text}";

            // Add backend mode
            if (cmbPublicBackend.SelectedIndex > 0)
            {
                arguments += $" --backend-mode {cmbPublicBackend.SelectedItem}";
            }

            // Add authentication
            if (chkPublicAuth.Checked && !string.IsNullOrWhiteSpace(txtPublicUsername.Text))
            {
                arguments += $" --basic-auth {txtPublicUsername.Text}:{txtPublicPassword.Text}";
            }

            btnPublicShare.Enabled = false;
            btnPublicStop.Enabled = true;
            txtPublicOutput.Clear();

            await RunZrokCommand(arguments, txtPublicOutput);
        }
        private async void BtnPrivateShare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrivateTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var arguments = $"share private {txtPrivateTarget.Text}";

            if (cmbPrivateBackend.SelectedIndex > 0)
            {
                arguments += $" --backend-mode {cmbPrivateBackend.SelectedItem}";
            }

            btnPrivateShare.Enabled = false;
            btnPrivateStop.Enabled = true;
            txtPrivateOutput.Clear();

            await RunZrokCommand(arguments, txtPrivateOutput);
        }
        private void BtnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = dialog.SelectedPath;
                }
            }
        }
        private async void BtnFileShare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please select a folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var shareType = rbFilePublic.Checked ? "public" : "private";
            var arguments = $"share {shareType} --backend-mode {cmbFileMode.SelectedItem} \"{txtFilePath.Text}\"";

            btnFileShare.Enabled = false;
            btnFileStop.Enabled = true;
            txtFileOutput.Clear();

            await RunZrokCommand(arguments, txtFileOutput);
        }
        private void BtnBrowseZrok_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = dialog.SelectedPath;
                }
            }
        }
        private async void BtnStatus_Click(object sender, EventArgs e)
        {
            btnStatus.Enabled = false; // Butonu devre dışı bırak
            txtStatusOutput.Clear();
            txtStatusOutput.AppendText("Fetching status...\n");
            txtStatusOutput.AppendText("═══════════════════════════════════════\n");

            await RunZrokCommandSync("status", txtStatusOutput);

            btnStatus.Enabled = true; // Butonu tekrar aktif et
        }
        private async void BtnEnable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnableToken.Text))
            {
                MessageBox.Show("Please enter your enable token!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnEnable.Enabled = false;
            txtStatusOutput.Clear();
            txtStatusOutput.AppendText("Enabling account...\n");

            await RunZrokCommandSync($"enable {txtEnableToken.Text}", txtStatusOutput);

            btnEnable.Enabled = true;
            MessageBox.Show("Account enabled! Check status to verify.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                currentProcess.Kill();
                currentProcess = null;
                EnableButtons();

                MessageBox.Show("Share stopped.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                var result = MessageBox.Show(
                    "There is an active share. Do you want to stop it and exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    currentProcess.Kill();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private async void BtnCreateReserve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReserveTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var shareType = cmbReserveType.SelectedItem.ToString();
            var arguments = $"reserve {shareType}";

            // Add backend mode
            if (cmbReserveBackend.SelectedIndex > 0)
            {
                arguments += $" --backend-mode {cmbReserveBackend.SelectedItem}";
            }

            // Add target
            arguments += $" {txtReserveTarget.Text}";

            btnCreateReserve.Enabled = false;
            txtReserveOutput.Clear();
            txtReserveOutput.AppendText("Creating reserved share...\n");

            await RunZrokCommandSync(arguments, txtReserveOutput);

            btnCreateReserve.Enabled = true;

            // ÇIKTIYI OKU
            var output = txtReserveOutput.Text;

            var (token, url) = ParseReserveOutput(output);

            if (!string.IsNullOrEmpty(token))
            {
                var item = new ListViewItem(token);
                item.SubItems.Add(cmbReserveBackend.SelectedItem?.ToString() ?? "-");
                item.SubItems.Add(txtReserveTarget.Text);
                lvReservedShares.Items.Add(item);
            }

            if (!string.IsNullOrEmpty(token))
            {
                var reserves = LoadReservesFromFile();

                // Aynı token varsa ekleme
                if (!reserves.Any(r => r.Token == token))
                {
                    reserves.Add(new ZrokReserve
                    {
                        Token = token,
                        Target = txtReserveTarget.Text,
                        Backend = new Backend
                        {
                            Mode = cmbReserveBackend.SelectedItem?.ToString()
                        }
                    });

                    SaveReservesToFile(reserves);
                }
            }

            // Refresh the list
            //await RefreshReservedSharesList();

            MessageBox.Show("Reserved share created! The token and URL are shown in the output.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void BtnRefreshReserves_Click(object sender, EventArgs e)
        {
            LoadReservedSharesFromJson();
        }
        private async void BtnStartReserved_Click(object sender, EventArgs e)
        {
            if (lvReservedShares.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a reserved share to start!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string token = lvReservedShares.SelectedItems[0].Text;

            if (token == "No reserved shares found")
            {
                return;
            }

            string arguments = $"share reserved {token}";

            btnStartReserved.Enabled = false;
            btnStopReserved.Enabled = true;
            txtReserveOutput.Clear();
            txtReserveOutput.AppendText($"Starting reserved share: {token}\n");

            await RunZrokCommand(arguments, txtReserveOutput);

        }
        private async void BtnDeleteReserve_Click(object sender, EventArgs e)
        {
            if (lvReservedShares.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a reserved share to delete!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var token = lvReservedShares.SelectedItems[0].Text;



            if (token == "No reserved shares found")
            {
                return;
            }

            var reserves = LoadReservesFromFile();
            var toRemove = reserves.FirstOrDefault(r => r.Token == token);

            if (toRemove != null)
            {
                reserves.Remove(toRemove);
                SaveReservesToFile(reserves);
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the reserved share?\n\nToken: {token}\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                txtReserveOutput.Clear();
                txtReserveOutput.AppendText($"Deleting reserved share: {token}\n");

                await RunZrokCommandSync($"release {token}", txtReserveOutput);

                // Refresh the list
                await RefreshReservedSharesList();

                MessageBox.Show("Reserved share deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        #region Process Management
        private void LoadReservedSharesFromJson()
        {
            lvReservedShares.Items.Clear();

            var reserves = LoadReservesFromFile();

            if (reserves.Count == 0)
            {
                lvReservedShares.Items.Add(new ListViewItem("No reserved shares found"));
                return;
            }

            foreach (var r in reserves)
            {
                var item = new ListViewItem(r.Token);
                item.SubItems.Add(r.Backend?.Mode ?? "-");
                item.SubItems.Add(r.Target ?? "-");
                lvReservedShares.Items.Add(item);
            }
        }
        private List<ZrokReserve> LoadReservesFromFile()
        {
            if (!File.Exists(reserveJsonPath))
                return new List<ZrokReserve>();

            var json = File.ReadAllText(reserveJsonPath);
            return JsonConvert.DeserializeObject<List<ZrokReserve>>(json)
                   ?? new List<ZrokReserve>();
        }

        private void SaveReservesToFile(List<ZrokReserve> reserves)
        {
            var json = JsonConvert.SerializeObject(reserves, Formatting.Indented);
            File.WriteAllText(reserveJsonPath, json);
        }
        private (string token, string url) ParseReserveOutput(string output)
        {
            var tokenMatch = Regex.Match(output,
                @"token is '([a-z0-9]+)'",
                RegexOptions.IgnoreCase);

            var urlMatch = Regex.Match(output,
                @"https://[a-z0-9]+\.share\.zrok\.io",
                RegexOptions.IgnoreCase);

            return (
                tokenMatch.Success ? tokenMatch.Groups[1].Value : null,
                urlMatch.Success ? urlMatch.Value : null
            );
        }

        private async Task RefreshReservedSharesList()
        {
            lvReservedShares.Items.Clear();

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = zrokExecutablePath,
                        Arguments = "ls --json",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.UTF8
                    }
                };

                process.Start();
                var output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                var reserves = JsonConvert.DeserializeObject<List<ZrokReserve>>(output);

                if (reserves == null || reserves.Count == 0)
                {
                    lvReservedShares.Items.Add(new ListViewItem("No reserved shares found"));
                    return;
                }

                foreach (var r in reserves)
                {
                    var item = new ListViewItem(r.Token);
                    item.SubItems.Add(r.Backend?.Mode ?? "-");
                    item.SubItems.Add(r.Target ?? "-");
                    lvReservedShares.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"List error: {ex.Message}");
            }
        }

        private async Task RunZrokCommand(string arguments, TextBox outputBox)
        {
            try
            {
                if (currentProcess != null && !currentProcess.HasExited)
                {
                    currentProcess.Kill();
                }

                currentProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = zrokExecutablePath,
                        Arguments = arguments + " --headless",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    },
                    EnableRaisingEvents = true,
                };

                currentProcess.OutputDataReceived += (s, e) => {
                    if (e.Data != null)
                    {
                        AppendToOutput(outputBox, e.Data);
                    }
                };

                currentProcess.ErrorDataReceived += (s, e) => {
                    if (e.Data != null)
                    {
                        AppendToOutput(outputBox, "[ERROR] " + e.Data);
                    }
                };


                currentProcess.Start();
                currentProcess.BeginOutputReadLine();
                currentProcess.BeginErrorReadLine();

                await Task.Run(() => currentProcess.WaitForExit());

                Invoke((MethodInvoker)delegate
                {
                    EnableButtons();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running zrok: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke((MethodInvoker)delegate {
                    EnableButtons();
                });
            }
        }
        private void AppendToOutput(TextBox tb, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            if (tb.InvokeRequired)
            {
                tb.Invoke(new Action(() => ProcessOutput(tb, text)));
            }
            else
            {
                ProcessOutput(tb, text);
            }
        }
        private async Task RunZrokCommandSync(string arguments, TextBox outputBox)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = zrokExecutablePath,
                        Arguments = arguments,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    }
                };

                process.Start();
                var output = await process.StandardOutput.ReadToEndAsync();
                var error = await process.StandardError.ReadToEndAsync();
                await Task.Run(() => process.WaitForExit());

                this.Invoke((MethodInvoker)delegate
                {
                    if (!string.IsNullOrEmpty(output))
                    {
                        outputBox.AppendText(output);
                    }
                    if (!string.IsNullOrEmpty(error))
                    {
                        outputBox.AppendText("[ERROR] " + error);
                    }

                    // Eğer hiç çıktı yoksa
                    if (string.IsNullOrEmpty(output) && string.IsNullOrEmpty(error))
                    {
                        outputBox.AppendText("Command executed successfully (no output)" + Environment.NewLine);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        private void EnableButtons()
        {
            btnPublicShare.Enabled = true;
            btnPublicStop.Enabled = false;
            btnPrivateShare.Enabled = true;
            btnPrivateStop.Enabled = false;
            btnFileShare.Enabled = true;
            btnFileStop.Enabled = false;
        }
        private void CheckZrokInstallation()
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = zrokExecutablePath,
                        Arguments = "version",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                process.WaitForExit();
            }
            catch
            {
                MessageBox.Show(
                    "zrok.exe not found in PATH. Please set the correct path in Settings tab.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        public void Dispose()
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                currentProcess.Kill();
                currentProcess.Dispose();
            }
        }
        private void ProcessOutput(TextBox tb, string text)
        {
            // JSON log mesajını kontrol et
            if (text.Contains("\"msg\":") && text.Contains("https://"))
            {
                try
                {
                    // URL'yi regex ile yakala
                    var urlMatch = System.Text.RegularExpressions.Regex.Match(
                        text, @"https://[a-zA-Z0-9\-\.]+\.share\.zrok\.io");

                    if (urlMatch.Success)
                    {
                        var url = urlMatch.Value;
                        tb.AppendText("═══════════════════════════════════════" + Environment.NewLine);
                        tb.AppendText("✓ Share Active!" + Environment.NewLine);
                        tb.AppendText($"📎 URL: {url}" + Environment.NewLine);
                        tb.AppendText($"🕐 Time: {DateTime.Now:HH:mm:ss}" + Environment.NewLine);
                        tb.AppendText("═══════════════════════════════════════" + Environment.NewLine);

                        // URL'yi panoya kopyala
                        Clipboard.SetText(url);
                        tb.AppendText("✓ URL copied to clipboard!" + Environment.NewLine);

                        return;
                    }
                }
                catch { }
            }

            // Normal mesajları göster (ERROR olmayan)
            if (!text.StartsWith("[ERROR]"))
            {
                tb.AppendText(text + Environment.NewLine);
            }
            else
            {
                // ERROR mesajlarını kontrol et - eğer sadece log ise gösterme
                if (!text.Contains("\"level\":\"info\"") && !text.Contains("\"level\":\"debug\""))
                {
                    tb.AppendText(text + Environment.NewLine);
                }
            }
        }
        #endregion        
    }

    public class ZrokReserve
    {
        [JsonProperty("token")]
        public string Token
        {
            get; set;
        }

        [JsonProperty("target")]
        public string Target
        {
            get; set;
        }

        [JsonProperty("backend")]
        public Backend Backend
        {
            get; set;
        }
    }

    public class Backend
    {
        [JsonProperty("mode")]
        public string Mode
        {
            get; set;
        }
    }
}
