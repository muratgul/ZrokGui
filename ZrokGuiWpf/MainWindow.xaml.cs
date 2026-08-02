using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace ZrokGuiWpf
{
    public partial class MainWindow : Window
    {
        private Process? currentProcess;
        private string zrokExecutablePath = "zrok.exe";
        private readonly string reserveJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reserved_shares.json");

        public MainWindow()
        {
            InitializeComponent();
            FindZrokExecutable();
            LoadReservedSharesFromJson();
        }

        private void FindZrokExecutable()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var possibleNames = new[] { "zrok.exe", "zrok2.exe" };
            
            foreach (var name in possibleNames)
            {
                if (File.Exists(Path.Combine(baseDir, name)))
                {
                    zrokExecutablePath = name;
                    return;
                }
            }
            
            // Eğer tam adıyla bulamazsa, içinde zrok geçen ilk exe'yi al
            var files = Directory.GetFiles(baseDir, "zrok*.exe");
            if (files.Length > 0)
            {
                zrokExecutablePath = Path.GetFileName(files[0]);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckZrokInstallation();
        }

        #region Window Controls
        private void ColorZone_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnDownloadZrok_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://netfoundry.io/docs/zrok/how-tos/install/") { UseShellExecute = true });
        }

        private void BtnRetryZrok_Click(object sender, RoutedEventArgs e)
        {
            RootDialog.IsOpen = false;
            CheckZrokInstallation();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Events
        private void ChkPublicAuth_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (txtPublicUsername == null || txtPublicPassword == null) return;
            bool isChecked = chkPublicAuth.IsChecked ?? false;
            txtPublicUsername.IsEnabled = isChecked;
            txtPublicPassword.IsEnabled = isChecked;
        }

        private async void BtnPublicShare_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublicTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var arguments = $"share public {txtPublicTarget.Text}";

            if (cmbPublicBackend.SelectedItem is ComboBoxItem cbi && cbi.Content.ToString() != "proxy")
            {
                arguments += $" --backend-mode {cbi.Content}";
            }

            if (chkPublicAuth.IsChecked == true && !string.IsNullOrWhiteSpace(txtPublicUsername.Text))
            {
                arguments += $" --basic-auth {txtPublicUsername.Text}:{txtPublicPassword.Password}";
            }

            btnPublicShare.IsEnabled = false;
            btnPublicStop.IsEnabled = true;
            txtPublicOutput.Clear();

            await RunZrokCommand(arguments, txtPublicOutput);
        }

        private async void BtnPrivateShare_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrivateTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var arguments = $"share private {txtPrivateTarget.Text}";

            if (cmbPrivateBackend.SelectedItem is ComboBoxItem cbi && cbi.Content.ToString() != "proxy")
            {
                arguments += $" --backend-mode {cbi.Content}";
            }

            btnPrivateShare.IsEnabled = false;
            btnPrivateStop.IsEnabled = true;
            txtPrivateOutput.Clear();

            await RunZrokCommand(arguments, txtPrivateOutput);
        }

        private void BtnBrowseFolder_Click(object sender, RoutedEventArgs e)
        {
            // Use Win32 OpenFileDialog for folder picking alternative or modern dialog
            // Note: WPF doesn't have a built-in FolderBrowserDialog in old versions, but in .NET 8 we can use OpenFolderDialog if targeting windows.
            // Using a simple trick with OpenFileDialog
            var dialog = new Microsoft.Win32.OpenFolderDialog();
            if (dialog.ShowDialog() == true)
            {
                txtFilePath.Text = dialog.FolderName;
            }
        }

        private async void BtnFileShare_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please select a folder!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var shareType = rbFilePublic.IsChecked == true ? "public" : "private";
            var mode = (cmbFileMode.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "web";
            var arguments = $"share {shareType} --backend-mode {mode} \"{txtFilePath.Text}\"";

            btnFileShare.IsEnabled = false;
            btnFileStop.IsEnabled = true;
            txtFileOutput.Clear();

            await RunZrokCommand(arguments, txtFileOutput);
        }

        private async void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            btnStatus.IsEnabled = false;
            txtStatusOutput.Clear();
            txtStatusOutput.AppendText("Fetching status...\n");
            txtStatusOutput.AppendText("═══════════════════════════════════════\n");

            await RunZrokCommandSync("status", txtStatusOutput);

            btnStatus.IsEnabled = true;
        }

        private async void BtnEnable_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnableToken.Text))
            {
                MessageBox.Show("Please enter your enable token!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            btnEnable.IsEnabled = false;
            txtStatusOutput.Clear();
            txtStatusOutput.AppendText("Enabling account...\n");

            await RunZrokCommandSync($"enable {txtEnableToken.Text}", txtStatusOutput);

            btnEnable.IsEnabled = true;
            MessageBox.Show("Account enabled! Check status to verify.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                try
                {
                    currentProcess.Kill(true);
                }
                catch { }
                currentProcess = null;
                EnableButtons();
                MessageBox.Show("Share stopped.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                var result = MessageBox.Show(
                    "There is an active share. Do you want to stop it and exit?",
                    "Confirm Exit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result == MessageBoxResult.Yes)
                {
                    try { currentProcess.Kill(true); } catch { }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private async void BtnCreateReserve_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReserveTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var shareType = (cmbReserveType.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "public";
            var arguments = $"reserve {shareType}";

            var backend = (cmbReserveBackend.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (backend != "proxy")
            {
                arguments += $" --backend-mode {backend}";
            }

            arguments += $" {txtReserveTarget.Text}";

            btnCreateReserve.IsEnabled = false;
            txtReserveOutput.Clear();
            txtReserveOutput.AppendText("Creating reserved share...\n");

            await RunZrokCommandSync(arguments, txtReserveOutput);

            btnCreateReserve.IsEnabled = true;

            var output = txtReserveOutput.Text;
            var (token, url) = ParseReserveOutput(output);

            if (!string.IsNullOrEmpty(token))
            {
                var reserves = LoadReservesFromFile();
                if (!reserves.Any(r => r.Token == token))
                {
                    reserves.Add(new ZrokReserve
                    {
                        Token = token,
                        Target = txtReserveTarget.Text,
                        Backend = new Backend { Mode = backend ?? "proxy" }
                    });
                    SaveReservesToFile(reserves);
                }
            }
            LoadReservedSharesFromJson();

            MessageBox.Show("Reserved share created! The token and URL are shown in the output.",
                "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnRefreshReserves_Click(object sender, RoutedEventArgs e)
        {
            LoadReservedSharesFromJson();
        }

        private async void BtnStartReserved_Click(object sender, RoutedEventArgs e)
        {
            if (lvReservedShares.SelectedItem is not ReserveViewModel selected)
            {
                MessageBox.Show("Please select a reserved share to start!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selected.Token == "No reserved shares found") return;

            string arguments = $"share reserved {selected.Token}";

            btnStartReserved.IsEnabled = false;
            btnStopReserved.IsEnabled = true;
            txtReserveOutput.Clear();
            txtReserveOutput.AppendText($"Starting reserved share: {selected.Token}\n");

            await RunZrokCommand(arguments, txtReserveOutput);
        }

        private async void BtnDeleteReserve_Click(object sender, RoutedEventArgs e)
        {
            if (lvReservedShares.SelectedItem is not ReserveViewModel selected)
            {
                MessageBox.Show("Please select a reserved share to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var token = selected.Token;
            if (token == "No reserved shares found") return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete the reserved share?\n\nToken: {token}\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                var reserves = LoadReservesFromFile();
                var toRemove = reserves.FirstOrDefault(r => r.Token == token);

                if (toRemove != null)
                {
                    reserves.Remove(toRemove);
                    SaveReservesToFile(reserves);
                }

                txtReserveOutput.Clear();
                txtReserveOutput.AppendText($"Deleting reserved share: {token}\n");

                await RunZrokCommandSync($"release {token}", txtReserveOutput);

                LoadReservedSharesFromJson();

                MessageBox.Show("Reserved share deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region Help Guides
        private void ShowHelp(string title, string content)
        {
            ZrokMissingDialogContainer.Visibility = Visibility.Collapsed;
            HelpDialogContainer.Visibility = Visibility.Visible;
            txtHelpTitle.Text = title;
            txtHelpContent.Text = content;
            RootDialog.IsOpen = true;
        }

        private void BtnHelpPublic_Click(object sender, RoutedEventArgs e)
        {
            ShowHelp("Public Share Guide", 
                "🇬🇧 [EN] The Public Share feature exposes a local service (like a local web server) to the internet securely.\n\n" +
                "🎯 Target Endpoint:\n" +
                "Enter the local port or address (e.g., '8080' or 'localhost:3000') that you want to share.\n\n" +
                "⚙️ Backend Mode:\n" +
                "• proxy: Forwards traffic to a local web server.\n" +
                "• web: Serves local files directly via HTTP.\n\n" +
                "🔐 Basic Auth:\n" +
                "Enable this to require a username and password to access the public link.\n\n" +
                "───────────────────────────\n\n" +
                "🇹🇷 [TR] Public Share (Genel Paylaşım) özelliği, yerel bir hizmeti (örneğin yerel bir web sunucusu) güvenli bir şekilde internete açar.\n\n" +
                "🎯 Target Endpoint (Hedef):\n" +
                "Paylaşmak istediğiniz yerel portu veya adresi girin (Örn: '8080' veya 'localhost:3000').\n\n" +
                "⚙️ Backend Mode (Arka Plan Modu):\n" +
                "• proxy: Trafiği yerel bir web sunucusuna yönlendirir.\n" +
                "• web: Yerel dosyaları doğrudan HTTP üzerinden sunar.\n\n" +
                "🔐 Basic Auth (Temel Doğrulama):\n" +
                "Açık linkinize (public link) erişmek için kullanıcı adı ve şifre sormasını istiyorsanız bunu etkinleştirin.");
        }

        private void BtnHelpPrivate_Click(object sender, RoutedEventArgs e)
        {
            ShowHelp("Private Share Guide", 
                "🇬🇧 [EN] Private Share creates an encrypted, private tunnel that is NOT accessible publicly on the internet. " +
                "Only users with the specific zrok token can access it.\n\n" +
                "🎯 Target Endpoint:\n" +
                "Enter the local resource (e.g., '8080' or a database port).\n\n" +
                "⚙️ Backend Mode:\n" +
                "Select proxy for web servers, tcpTunnel for databases (like SQL or Redis), or udpTunnel for streaming/gaming.\n\n" +
                "───────────────────────────\n\n" +
                "🇹🇷 [TR] Private Share (Özel Paylaşım), internet üzerinden herkese açık OLMAYAN şifreli ve özel bir tünel oluşturur. " +
                "Sadece özel zrok token'ına (anahtarına) sahip kullanıcılar erişebilir.\n\n" +
                "🎯 Target Endpoint (Hedef):\n" +
                "Yerel kaynağı girin (Örn: '8080' veya bir veritabanı portu).\n\n" +
                "⚙️ Backend Mode (Arka Plan Modu):\n" +
                "Web sunucuları için proxy'yi, veritabanları (SQL, Redis vb.) için tcpTunnel'ı veya yayın/oyun için udpTunnel'ı seçin.");
        }

        private void BtnHelpFile_Click(object sender, RoutedEventArgs e)
        {
            ShowHelp("File Server Guide", 
                "🇬🇧 [EN] Quickly turn any local folder on your computer into a shared drive over the network.\n\n" +
                "📁 Folder Path:\n" +
                "Browse and select the local directory you want to share.\n\n" +
                "🌐 Network Type:\n" +
                "• Public: Anyone with the link can access the files.\n" +
                "• Private: Only authorized zrok users can access it.\n\n" +
                "⚙️ Backend Mode:\n" +
                "• web: Provides a simple web interface to browse and download files.\n" +
                "• drive: Allows mounting the share as a network drive (requires zrok drive).\n\n" +
                "───────────────────────────\n\n" +
                "🇹🇷 [TR] Bilgisayarınızdaki herhangi bir yerel klasörü hızlıca ağ üzerinden paylaşılan bir sürücüye dönüştürür.\n\n" +
                "📁 Folder Path (Klasör Yolu):\n" +
                "Paylaşmak istediğiniz yerel klasörü seçin.\n\n" +
                "🌐 Network Type (Ağ Türü):\n" +
                "• Public: Linke sahip herkes dosyalara erişebilir.\n" +
                "• Private: Sadece yetkili zrok kullanıcıları erişebilir.\n\n" +
                "⚙️ Backend Mode (Arka Plan Modu):\n" +
                "• web: Dosyalara göz atmak ve indirmek için basit bir web arayüzü sunar.\n" +
                "• drive: Paylaşımı bir ağ sürücüsü olarak bağlamanızı sağlar (zrok drive gerektirir).");
        }

        private void BtnHelpReserve_Click(object sender, RoutedEventArgs e)
        {
            ShowHelp("Reserved Shares Guide", 
                "🇬🇧 [EN] Reserved Shares allow you to create permanent, static endpoints that do not change across restarts.\n\n" +
                "📌 Create Reserve:\n" +
                "Enter your target, choose public or private, and create. You will receive a permanent 'Token'.\n\n" +
                "▶️ Start Selected:\n" +
                "Instead of creating a new temporary share, select a token from the list and start it. Your share will resume on the exact same URL as before.\n\n" +
                "───────────────────────────\n\n" +
                "🇹🇷 [TR] Reserved Shares (Ayrılmış Paylaşımlar), yeniden başlatmalarda değişmeyen kalıcı ve sabit uç noktalar (URL/Token) oluşturmanızı sağlar.\n\n" +
                "📌 Create Reserve (Rezervasyon Oluştur):\n" +
                "Hedefinizi girin, public (genel) veya private (özel) seçin ve oluşturun. Size kalıcı bir 'Token' verilecektir.\n\n" +
                "▶️ Start Selected (Seçileni Başlat):\n" +
                "Yeni geçici bir paylaşım oluşturmak yerine, listeden bir token seçip başlatın. Paylaşımınız daha öncekiyle tamamen aynı URL/Token üzerinden devam edecektir.");
        }

        private void BtnHelpSettings_Click(object sender, RoutedEventArgs e)
        {
            ShowHelp("Settings & Status Guide", 
                "🇬🇧 [EN] Manage your zrok account and environment.\n\n" +
                "🔑 Enable Account:\n" +
                "Paste your secret zrok enable token (from the zrok web console) to authenticate this device.\n\n" +
                "🔍 Check Network Status:\n" +
                "Verifies that zrok is installed correctly and checks the current account and environment details.\n\n" +
                "───────────────────────────\n\n" +
                "🇹🇷 [TR] zrok hesabınızı ve çalışma ortamınızı yönetin.\n\n" +
                "🔑 Enable Account (Hesabı Etkinleştir):\n" +
                "Bu cihazın kimliğini doğrulamak için (zrok web konsolundan aldığınız) gizli zrok etkinleştirme token'ınızı yapıştırın.\n\n" +
                "🔍 Check Network Status (Ağ Durumunu Kontrol Et):\n" +
                "zrok'un doğru yüklenip yüklenmediğini doğrular; mevcut hesap ve ortam detaylarınızı kontrol eder.");
        }
        #endregion

        #region Process Management
        private void LoadReservedSharesFromJson()
        {
            lvReservedShares.Items.Clear();

            var reserves = LoadReservesFromFile();

            if (reserves.Count == 0)
            {
                lvReservedShares.Items.Add(new ReserveViewModel { Token = "No reserved shares found", Backend = "-", Target = "-" });
                return;
            }

            foreach (var r in reserves)
            {
                lvReservedShares.Items.Add(new ReserveViewModel
                {
                    Token = r.Token,
                    Backend = r.Backend?.Mode ?? "-",
                    Target = r.Target ?? "-"
                });
            }
        }

        private List<ZrokReserve> LoadReservesFromFile()
        {
            if (!File.Exists(reserveJsonPath))
                return new List<ZrokReserve>();

            try
            {
                var json = File.ReadAllText(reserveJsonPath);
                return JsonConvert.DeserializeObject<List<ZrokReserve>>(json) ?? new List<ZrokReserve>();
            }
            catch
            {
                return new List<ZrokReserve>();
            }
        }

        private void SaveReservesToFile(List<ZrokReserve> reserves)
        {
            var json = JsonConvert.SerializeObject(reserves, Formatting.Indented);
            File.WriteAllText(reserveJsonPath, json);
        }

        private (string? token, string? url) ParseReserveOutput(string output)
        {
            var tokenMatch = Regex.Match(output, @"token is '([a-z0-9]+)'", RegexOptions.IgnoreCase);
            var urlMatch = Regex.Match(output, @"https://[a-z0-9]+\.share\.zrok\.io", RegexOptions.IgnoreCase);

            return (
                tokenMatch.Success ? tokenMatch.Groups[1].Value : null,
                urlMatch.Success ? urlMatch.Value : null
            );
        }

        private async Task RunZrokCommand(string arguments, TextBox outputBox)
        {
            try
            {
                if (currentProcess != null && !currentProcess.HasExited)
                {
                    currentProcess.Kill(true);
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
                    if (e.Data != null) AppendToOutput(outputBox, e.Data);
                };

                currentProcess.ErrorDataReceived += (s, e) => {
                    if (e.Data != null) AppendToOutput(outputBox, "[ERROR] " + e.Data);
                };

                currentProcess.Start();
                currentProcess.BeginOutputReadLine();
                currentProcess.BeginErrorReadLine();

                await currentProcess.WaitForExitAsync();

                Dispatcher.Invoke(() => EnableButtons());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running zrok: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispatcher.Invoke(() => EnableButtons());
            }
        }

        private void AppendToOutput(TextBox tb, string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            Dispatcher.Invoke(() => ProcessOutput(tb, text));
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
                await process.WaitForExitAsync();

                Dispatcher.Invoke(() =>
                {
                    if (!string.IsNullOrEmpty(output)) outputBox.AppendText(output);
                    if (!string.IsNullOrEmpty(error)) outputBox.AppendText("[ERROR] " + error);
                    
                    if (string.IsNullOrEmpty(output) && string.IsNullOrEmpty(error))
                    {
                        outputBox.AppendText("Command executed successfully (no output)" + Environment.NewLine);
                    }
                    outputBox.ScrollToEnd();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnableButtons()
        {
            btnPublicShare.IsEnabled = true;
            btnPublicStop.IsEnabled = false;
            btnPrivateShare.IsEnabled = true;
            btnPrivateStop.IsEnabled = false;
            btnFileShare.IsEnabled = true;
            btnFileStop.IsEnabled = false;
            btnStartReserved.IsEnabled = true;
            btnStopReserved.IsEnabled = false;
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
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                string version = "Unknown";
                var match = Regex.Match(output, @"v\d+\.\d+\.\d+");
                if (match.Success)
                {
                    version = match.Value;
                }

                Dispatcher.Invoke(() => {
                    txtZrokStatus.Text = $"Zrok {version} Ready";
                    ZrokStatusBadge.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#4CAF50");
                    ZrokStatusIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                });
            }
            catch
            {
                Dispatcher.Invoke(() => {
                    txtZrokStatus.Text = "Zrok Missing!";
                    ZrokStatusBadge.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#E53935");
                    ZrokStatusIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircleOutline;

                    HelpDialogContainer.Visibility = Visibility.Collapsed;
                    ZrokMissingDialogContainer.Visibility = Visibility.Visible;
                    RootDialog.IsOpen = true;
                });
            }
        }

        private void ProcessOutput(TextBox tb, string text)
        {
            if (text.Contains("\"msg\":") && text.Contains("https://"))
            {
                try
                {
                    var urlMatch = Regex.Match(text, @"https://[a-zA-Z0-9\-\.]+\.share\.zrok\.io");
                    if (urlMatch.Success)
                    {
                        var url = urlMatch.Value;
                        tb.AppendText("═══════════════════════════════════════" + Environment.NewLine);
                        tb.AppendText("✓ Share Active!" + Environment.NewLine);
                        tb.AppendText($"📎 URL: {url}" + Environment.NewLine);
                        tb.AppendText($"🕐 Time: {DateTime.Now:HH:mm:ss}" + Environment.NewLine);
                        tb.AppendText("═══════════════════════════════════════" + Environment.NewLine);

                        Clipboard.SetText(url);
                        tb.AppendText("✓ URL copied to clipboard!" + Environment.NewLine);
                        tb.ScrollToEnd();
                        return;
                    }
                }
                catch { }
            }

            if (!text.StartsWith("[ERROR]"))
            {
                tb.AppendText(text + Environment.NewLine);
            }
            else
            {
                if (!text.Contains("\"level\":\"info\"") && !text.Contains("\"level\":\"debug\""))
                {
                    tb.AppendText(text + Environment.NewLine);
                }
            }
            tb.ScrollToEnd();
        }
        #endregion
    }

    public class ReserveViewModel
    {
        public string? Token { get; set; }
        public string? Backend { get; set; }
        public string? Target { get; set; }
    }

    public class ZrokReserve
    {
        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("target")]
        public string? Target { get; set; }

        [JsonProperty("backend")]
        public Backend? Backend { get; set; }
    }

    public class Backend
    {
        [JsonProperty("mode")]
        public string? Mode { get; set; }
    }
}