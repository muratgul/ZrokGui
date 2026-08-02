# Zrok Desktop GUI (Windows)

A beautiful, modern Windows desktop application built with **WPF** and **Material Design 3**, providing a graphical user interface for managing **zrok** shares.  
It allows you to create, start, stop, reserve, and manage **public, private, file-based, and reserved zrok shares** without using the command line.

---

## 🚀 Features

- 🎨 **Modern UI**: Completely overhauled borderless window design using Material Design 3.
- 💡 **Interactive Help Guides**: Built-in, bilingual (English & Turkish) help dialogs for every feature.
- 🩺 **Smart Installation Detection**: Visually detects if `zrok` is missing and provides an easy 1-click download menu.
- 🟢 **Real-Time Status Badge**: A live badge in the title bar tracking your zrok installation and its version.
- ✅ **Public & Private sharing**: Expose endpoints securely.
- 📁 **Folder sharing**: Serve local directories over public or private networks.
- 🔐 **Security & Permissions**: Basic Auth for public shares, and **Open Mode / Access Grants** for private shares.
- 📌 **Reserved Shares**: Create, save, and manage permanent endpoints with custom **Unique Names**.
- ▶ **Simultaneous Execution**: Start and run multiple zrok shares concurrently in the background without them interfering with each other.
- 🛠 **Full Backend Support**: proxy, web, caddy, drive, tcpTunnel, udpTunnel, and socks backend modes.
- 📋 **Auto-Clipboard**: Automatically copies active share URLs to clipboard.
- 🗂 **Persistent Storage**: Reserved shares are saved locally in JSON.
- 🖥 **Live Logging**: Real-time zrok console output directly in the app.
- ⚡ **Headless Execution**: zrok runs silently in the background.

---

## 🧰 Requirements

- **Windows 10 / 11**
- **.NET 10.0** (if not using the self-contained release)
- **zrok executable**

### ⚙️ How to setup Zrok with this GUI:
`zrok` is a portable command-line tool. You don't need to formally install it or add it to your system PATH!
1. Download the Windows version of `zrok` from the [official website](https://netfoundry.io/docs/zrok/how-tos/install/).
2. Extract the `.exe` file (it might be named `zrok.exe` or `zrok2.exe`).
3. Place that executable directly inside the **same folder** as `ZrokGuiWpf.exe`.
4. Our application will automatically discover it (even if it's named `zrok2.exe` or similar) and use it silently in the background!

### 🔑 Enabling Your Account (Required):
Before creating any shares, you must authenticate your device:
1. Go to [myzrok.io](https://myzrok.io/) (or api.zrok.io) and sign up for a free account.
2. Once logged in, find your **Enable Token** (a secret key used to authenticate your environment).
3. Open the **Zrok Desktop GUI**, navigate to the **Settings & Status** section (via the left menu).
4. Paste your token into the **Enable Token** field and click **Enable**.
5. You are now ready to start sharing!
