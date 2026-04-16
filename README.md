# 🚀 OmniCalc: Modern C# Calculator & Unit Converter

![License](https://img.shields.io/badge/license-MIT-green.svg)
![.NET](https://img.shields.io/badge/.NET-Framework%204.7.2%2B-blueviolet)
![C#](https://img.shields.io/badge/Language-C%23-blue)

**OmniCalc** is a high-performance, versatile calculation and unit conversion engine built with Windows Forms. It is a proof-of-concept project designed to demonstrate that WinForms applications can possess a modern, sleek aesthetic far beyond the traditional "90s software" look.

---

## 🎨 Why OmniCalc?

Most desktop calculators are just simple grids of buttons. OmniCalc breaks that mold with:
* **Discord-Inspired UI:** A dark, eye-pleasing aesthetic designed for long coding or calculation sessions.
* **Code-First UI:** The interface is built entirely through code, ensuring pixel-perfect alignment and bypasses the limitations of the standard Visual Studio Designer.
* **Live Engine:** A conversion engine that updates results in real-time as you type.

---

## ✨ Features

* **🧮 Advanced Expression Parsing:** Powered by a robust `DataTable.Compute` engine, handling nested parentheses and complex mathematical strings with ease.
* **⚖️ Live Unit Conversion:** Converts length and weight units on-the-fly. No "Calculate" button required—results update instantly.
* **🎨 Modern UI/UX:** A customized flat design interface with interactive button states and a consistent dark-mode palette.
* **🌍 Global Compatibility:** Uses `CultureInfo.InvariantCulture` to ensure seamless operation regardless of local decimal settings (dot vs. comma).
* **🚫 Smart Input Logic:** Built-in safeguards prevent operator stacking (e.g., `++` or `*/`) and automatically filter invalid characters.

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** .NET / Windows Forms
- **Design:** Flat Design (Discord Palette)
- **Engine:** Dynamic String Expression Parsing & GDI+

---

## ⚙️ Installation & Usage

### Prerequisites
* Visual Studio 2019 or newer.
* .NET Framework 4.7.2 or higher.

### Quick Start
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yourusername/OmniCalc.git](https://github.com/yourusername/OmniCalc.git)
    ```
2.  **Open the Project:**
    Launch the `.sln` file in Visual Studio.
3.  **Build & Run:**
    Press `F5` to compile and start calculating!

---

## 🤝 Contributing

Contributions are what make the open-source community such an amazing place!

1.  **Found a bug?** Open an [Issue](https://github.com/yourusername/OmniCalc/issues).
2.  **Have a feature idea?** Want to add new units (Temperature, Volume, Currency)?
    * Fork the Project.
    * Create your Feature Branch (`git checkout -b feature/AmazingFeature`).
    * Commit your Changes (`git commit -m 'Add some AmazingFeature'`).
    * Push to the Branch (`git push origin feature/AmazingFeature`).
    * Open a Pull Request.

---

## 📜 License

Distributed under the **MIT License**. See `LICENSE` for more information.

---

## 💡 Developer's Note

> "I built this to challenge the 'WinForms is outdated' stereotype. If you find the UI logic or the expression engine helpful, feel free to fork it and don't forget to drop a ⭐!"

---
*Developed with ❤️ by [Your Name/Username]*
