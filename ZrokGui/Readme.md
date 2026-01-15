# Zrok Desktop GUI (Windows)

A Windows Forms desktop application that provides a graphical user interface for managing **zrok** shares.  
It allows you to create, start, stop, reserve, and manage **public, private, file-based, and reserved zrok shares** without using the command line.

---

## 🚀 Features

- ✅ Public & Private sharing
- 📁 Folder sharing (public / private)
- 🔐 Basic Authentication support
- 📌 Reserved share creation and management
- ▶ Start / ⏹ Stop active shares
- 📋 Automatically copies active share URL to clipboard
- 🗂 Persistent reserved shares stored in JSON
- 🖥 Real-time zrok output logging
- 🔍 Status & environment check
- ⚡ Headless zrok execution

---

## 🧰 Requirements

- **Windows**
- **.NET Framework / .NET (WinForms)**  
  (Project target depends on your solution configuration)
- **zrok installed and accessible in PATH**

Verify zrok installation:
```bash
zrok version
