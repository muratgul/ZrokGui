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
- 🔐 **Basic Authentication**: Add instant security to public shares.
- 📌 **Reserved Shares**: Create, save, and manage permanent endpoints.
- ▶ **Start / ⏹ Stop**: Easily toggle active shares with large accessible buttons.
- 📋 **Auto-Clipboard**: Automatically copies active share URLs to clipboard.
- 🗂 **Persistent Storage**: Reserved shares are saved locally in JSON.
- 🖥 **Live Logging**: Real-time zrok console output directly in the app.
- ⚡ **Headless Execution**: zrok runs silently in the background.

---

## 🧰 Requirements

- **Windows 10 / 11**
- **.NET 10.0 (WPF)**
- **zrok installed and accessible in PATH**

Verify your zrok installation via command line:
```bash
zrok version
```
