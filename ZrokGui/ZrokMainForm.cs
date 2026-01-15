using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZrokGui
{
    public partial class ZrokMainForm : Form
    {// UI Controls
        private TabControl tabControl;
        private TabPage tabPublicShare;
        private TabPage tabPrivateShare;
        private TabPage tabFileShare;
        private TabPage tabSettings;

        // Public Share Controls
        private TextBox txtPublicTarget;
        private Button btnPublicShare;
        private Button btnPublicStop;
        private TextBox txtPublicOutput;
        private ComboBox cmbPublicBackend;
        private CheckBox chkPublicAuth;
        private TextBox txtPublicUsername;
        private TextBox txtPublicPassword;

        // Private Share Controls
        private TextBox txtPrivateTarget;
        private Button btnPrivateShare;
        private Button btnPrivateStop;
        private TextBox txtPrivateOutput;
        private ComboBox cmbPrivateBackend;

        // File Share Controls
        private TextBox txtFilePath;
        private Button btnBrowseFolder;
        private ComboBox cmbFileMode;
        private RadioButton rbFilePublic;
        private RadioButton rbFilePrivate;
        private Button btnFileShare;
        private Button btnFileStop;
        private TextBox txtFileOutput;

        // Settings Controls
        private TextBox txtZrokPath;
        private Button btnBrowseZrok;
        private TextBox txtEnableToken;
        private Button btnEnable;
        private Button btnStatus;
        private TextBox txtStatusOutput;

        // Process Management
        private Process currentProcess;
        private string zrokExecutablePath = "zrok.exe";
        public ZrokMainForm()
        {
            InitializeComponent();
            InitializeControls();
            CheckZrokInstallation();
        }
        private void InitializeControls()
        {
            this.Text = "zrok GUI Manager";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += MainForm_FormClosing;

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            // Initialize tabs
            InitializePublicShareTab();
            InitializePrivateShareTab();
            InitializeFileShareTab();
            InitializeSettingsTab();

            this.Controls.Add(tabControl);
        }

        #region Public Share Tab

        private void InitializePublicShareTab()
        {
            tabPublicShare = new TabPage("Public Share");

            // Target
            Label lblTarget = new Label
            {
                Text = "Target (localhost:port):",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtPublicTarget = new TextBox
            {
                Location = new Point(20, 45),
                Width = 300,
                Text = "localhost:8080"
            };

            // Backend Mode
            Label lblBackend = new Label
            {
                Text = "Backend Mode:",
                Location = new Point(20, 80),
                AutoSize = true
            };

            cmbPublicBackend = new ComboBox
            {
                Location = new Point(20, 105),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPublicBackend.Items.AddRange(new object[] { "Default", "web", "tcpTunnel", "udpTunnel" });
            cmbPublicBackend.SelectedIndex = 0;

            // Authentication
            chkPublicAuth = new CheckBox
            {
                Text = "Enable Basic Authentication",
                Location = new Point(20, 145),
                AutoSize = true
            };
            chkPublicAuth.CheckedChanged += (s, e) =>
            {
                txtPublicUsername.Enabled = chkPublicAuth.Checked;
                txtPublicPassword.Enabled = chkPublicAuth.Checked;
            };

            Label lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(40, 175),
                AutoSize = true
            };

            txtPublicUsername = new TextBox
            {
                Location = new Point(120, 172),
                Width = 150,
                Enabled = false
            };

            Label lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(40, 205),
                AutoSize = true
            };

            txtPublicPassword = new TextBox
            {
                Location = new Point(120, 202),
                Width = 150,
                PasswordChar = '*',
                Enabled = false
            };

            // Buttons
            btnPublicShare = new Button
            {
                Text = "Start Sharing",
                Location = new Point(20, 240),
                Width = 120,
                Height = 35
            };
            btnPublicShare.Click += BtnPublicShare_Click;

            btnPublicStop = new Button
            {
                Text = "Stop",
                Location = new Point(150, 240),
                Width = 120,
                Height = 35,
                Enabled = false
            };
            btnPublicStop.Click += BtnStop_Click;

            // Output
            Label lblOutput = new Label
            {
                Text = "Output:",
                Location = new Point(20, 285),
                AutoSize = true
            };

            txtPublicOutput = new TextBox
            {
                Location = new Point(20, 310),
                Width = 720,
                Height = 200,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Font = new Font("Consolas", 9)
            };

            // Add controls to tab
            tabPublicShare.Controls.AddRange(new Control[]
            {
                lblTarget, txtPublicTarget, lblBackend, cmbPublicBackend,
                chkPublicAuth, lblUsername, txtPublicUsername, lblPassword, txtPublicPassword,
                btnPublicShare, btnPublicStop, lblOutput, txtPublicOutput
            });

            tabControl.TabPages.Add(tabPublicShare);
        }

        private async void BtnPublicShare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublicTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string arguments = $"share public {txtPublicTarget.Text}";

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

        #endregion
        #region Private Share Tab

        private void InitializePrivateShareTab()
        {
            tabPrivateShare = new TabPage("Private Share");

            // Target
            Label lblTarget = new Label
            {
                Text = "Target (localhost:port):",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtPrivateTarget = new TextBox
            {
                Location = new Point(20, 45),
                Width = 300,
                Text = "localhost:3000"
            };

            // Backend Mode
            Label lblBackend = new Label
            {
                Text = "Backend Mode:",
                Location = new Point(20, 80),
                AutoSize = true
            };

            cmbPrivateBackend = new ComboBox
            {
                Location = new Point(20, 105),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPrivateBackend.Items.AddRange(new object[] { "Default", "web", "tcpTunnel", "udpTunnel" });
            cmbPrivateBackend.SelectedIndex = 0;

            // Buttons
            btnPrivateShare = new Button
            {
                Text = "Start Private Sharing",
                Location = new Point(20, 145),
                Width = 150,
                Height = 35
            };
            btnPrivateShare.Click += BtnPrivateShare_Click;

            btnPrivateStop = new Button
            {
                Text = "Stop",
                Location = new Point(180, 145),
                Width = 120,
                Height = 35,
                Enabled = false
            };
            btnPrivateStop.Click += BtnStop_Click;

            // Output
            Label lblOutput = new Label
            {
                Text = "Output (Share this token with authorized users):",
                Location = new Point(20, 190),
                AutoSize = true
            };

            txtPrivateOutput = new TextBox
            {
                Location = new Point(20, 215),
                Width = 720,
                Height = 285,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Font = new Font("Consolas", 9)
            };

            // Add controls
            tabPrivateShare.Controls.AddRange(new Control[]
            {
                lblTarget, txtPrivateTarget, lblBackend, cmbPrivateBackend,
                btnPrivateShare, btnPrivateStop, lblOutput, txtPrivateOutput
            });

            tabControl.TabPages.Add(tabPrivateShare);
        }

        private async void BtnPrivateShare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrivateTarget.Text))
            {
                MessageBox.Show("Please enter a target!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string arguments = $"share private {txtPrivateTarget.Text}";

            if (cmbPrivateBackend.SelectedIndex > 0)
            {
                arguments += $" --backend-mode {cmbPrivateBackend.SelectedItem}";
            }

            btnPrivateShare.Enabled = false;
            btnPrivateStop.Enabled = true;
            txtPrivateOutput.Clear();

            await RunZrokCommand(arguments, txtPrivateOutput);
        }

        #endregion
        #region File Share Tab

        private void InitializeFileShareTab()
        {
            tabFileShare = new TabPage("File Share");

            // Folder Selection
            Label lblFolder = new Label
            {
                Text = "Select Folder to Share:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtFilePath = new TextBox
            {
                Location = new Point(20, 45),
                Width = 500,
                ReadOnly = true
            };

            btnBrowseFolder = new Button
            {
                Text = "Browse...",
                Location = new Point(530, 43),
                Width = 100
            };
            btnBrowseFolder.Click += BtnBrowseFolder_Click;

            // Share Type
            Label lblShareType = new Label
            {
                Text = "Share Type:",
                Location = new Point(20, 85),
                AutoSize = true
            };

            rbFilePublic = new RadioButton
            {
                Text = "Public (Anyone with link)",
                Location = new Point(20, 110),
                Checked = true,
                AutoSize = true
            };

            rbFilePrivate = new RadioButton
            {
                Text = "Private (Token required)",
                Location = new Point(20, 135),
                AutoSize = true
            };

            // File Mode
            Label lblFileMode = new Label
            {
                Text = "File Mode:",
                Location = new Point(20, 170),
                AutoSize = true
            };

            cmbFileMode = new ComboBox
            {
                Location = new Point(20, 195),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbFileMode.Items.AddRange(new object[] { "web", "drive" });
            cmbFileMode.SelectedIndex = 0;

            Label lblInfo = new Label
            {
                Text = "web: Browse files in browser\ndrive: Mount as network drive (WebDAV)",
                Location = new Point(230, 195),
                AutoSize = true,
                ForeColor = Color.Gray
            };

            // Buttons
            btnFileShare = new Button
            {
                Text = "Start File Sharing",
                Location = new Point(20, 245),
                Width = 150,
                Height = 35
            };
            btnFileShare.Click += BtnFileShare_Click;

            btnFileStop = new Button
            {
                Text = "Stop",
                Location = new Point(180, 245),
                Width = 120,
                Height = 35,
                Enabled = false
            };
            btnFileStop.Click += BtnStop_Click;

            // Output
            Label lblOutput = new Label
            {
                Text = "Share URL:",
                Location = new Point(20, 290),
                AutoSize = true
            };

            txtFileOutput = new TextBox
            {
                Location = new Point(20, 315),
                Width = 720,
                Height = 185,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Font = new Font("Consolas", 9)
            };

            // Add controls
            tabFileShare.Controls.AddRange(new Control[]
            {
                lblFolder, txtFilePath, btnBrowseFolder,
                lblShareType, rbFilePublic, rbFilePrivate,
                lblFileMode, cmbFileMode, lblInfo,
                btnFileShare, btnFileStop, lblOutput, txtFileOutput
            });

            tabControl.TabPages.Add(tabFileShare);
        }

        private void BtnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
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

            string shareType = rbFilePublic.Checked ? "public" : "private";
            string arguments = $"share {shareType} --backend-mode {cmbFileMode.SelectedItem} \"{txtFilePath.Text}\"";

            btnFileShare.Enabled = false;
            btnFileStop.Enabled = true;
            txtFileOutput.Clear();

            await RunZrokCommand(arguments, txtFileOutput);
        }

        #endregion
        #region Settings Tab

        private void InitializeSettingsTab()
        {
            tabSettings = new TabPage("Settings");

            // zrok Path
            Label lblZrokPath = new Label
            {
                Text = "zrok.exe Path:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtZrokPath = new TextBox
            {
                Location = new Point(20, 45),
                Width = 500,
                Text = zrokExecutablePath
            };

            btnBrowseZrok = new Button
            {
                Text = "Browse...",
                Location = new Point(530, 43),
                Width = 100
            };
            btnBrowseZrok.Click += BtnBrowseZrok_Click;

            // Enable Token
            Label lblToken = new Label
            {
                Text = "Enable Token (from zrok.io account):",
                Location = new Point(20, 90),
                AutoSize = true
            };

            txtEnableToken = new TextBox
            {
                Location = new Point(20, 115),
                Width = 500,
                PasswordChar = '*'
            };

            btnEnable = new Button
            {
                Text = "Enable Account",
                Location = new Point(530, 113),
                Width = 150,
                Height = 25
            };
            btnEnable.Click += BtnEnable_Click;

            // Status
            Label lblStatus = new Label
            {
                Text = "Account Status:",
                Location = new Point(20, 160),
                AutoSize = true
            };

            btnStatus = new Button
            {
                Text = "Check Status",
                Location = new Point(20, 185),
                Width = 150,
                Height = 35
            };
            btnStatus.Click += BtnStatus_Click;

            txtStatusOutput = new TextBox
            {
                Location = new Point(20, 230),
                Width = 720,
                Height = 270,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                BackColor = Color.White,
                Font = new Font("Consolas", 9)
            };

            // Add controls
            tabSettings.Controls.AddRange(new Control[]
            {
                lblZrokPath, txtZrokPath, btnBrowseZrok,
                lblToken, txtEnableToken, btnEnable,
                lblStatus, btnStatus, txtStatusOutput
            });

            tabControl.TabPages.Add(tabSettings);
        }

        private void BtnBrowseZrok_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
                dialog.Title = "Select zrok.exe";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtZrokPath.Text = dialog.FileName;
                    zrokExecutablePath = dialog.FileName;
                }
            }
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

        private async void BtnStatus_Click(object sender, EventArgs e)
        {
            txtStatusOutput.Clear();
            await RunZrokCommandSync("status", txtStatusOutput);
        }

        #endregion
        #region Process Management

        private async Task RunZrokCommand(string arguments, TextBox outputBox)
        {
            try
            {
                currentProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = zrokExecutablePath,
                        Arguments = arguments,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                currentProcess.OutputDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            outputBox.AppendText(e.Data + Environment.NewLine);
                        });
                    }
                };

                currentProcess.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            outputBox.AppendText("[ERROR] " + e.Data + Environment.NewLine);
                        });
                    }
                };

                currentProcess.Start();
                currentProcess.BeginOutputReadLine();
                currentProcess.BeginErrorReadLine();

                await Task.Run(() => currentProcess.WaitForExit());

                this.Invoke((MethodInvoker)delegate
                {
                    EnableButtons();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableButtons();
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
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                await Task.Run(() => process.WaitForExit());

                this.Invoke((MethodInvoker)delegate
                {
                    outputBox.AppendText(output);
                    if (!string.IsNullOrEmpty(error))
                    {
                        outputBox.AppendText("[ERROR] " + error);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #endregion

        private void ZrokMainForm_Load(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
        }
    }
}
