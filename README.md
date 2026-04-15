🚀 OmniCalc: Modern C# Calculator & Unit Converter

OmniCalc is a high-performance, versatile calculation and unit conversion engine built on Windows Forms. It’s designed to prove that WinForms doesn't have to look like it's from 1998.

Why OmniCalc? Most calculators are just grids of buttons. OmniCalc features a Discord-inspired dark theme, a dynamic UI built entirely through code, and a "live" conversion engine that thinks as fast as you type.

✨ Features

🧮 Advanced Expression Parsing: Powered by a robust DataTable.Compute engine, it handles nested parentheses and complex mathematical strings with ease.

⚖️ Live Unit Conversion: No "Calculate" button needed. It converts length and weight units in real-time (on-the-fly) as you enter values.

🎨 Modern UI/UX: Forget the clunky Visual Studio Designer. The interface is dynamically generated via code for pixel-perfect alignment and a sleek Dark Mode.

🌍 Global Compatibility: Optimized with CultureInfo.InvariantCulture. Whether your PC uses dots or commas for decimals, OmniCalc won't crash.

🚫 Smart Input Logic: Built-in safeguards prevent operator stacking (e.g., ++ or */) and filter out invalid character entries automatically.

🛠️ Tech Stack

Language: C#

Framework: .NET / Windows Forms

UI Style: Flat Design (Discord Palette)

Engine: Dynamic String Expression Parsing

⚙️ Installation & Usage

Clone the repo:

Bash
git clone https://github.com/yourusername/OmniCalc.git
Open the Project: Launch the .sln file in Visual Studio.

Build & Run: Press F5 and start calculating!

🤝 Contributing

Contributions are what make the open-source community such an amazing place!

Found a bug? Open an Issue.

Want to add new units (Temperature, Volume, Currency)? Submit a Pull Request.

📜 License

Distributed under the MIT License. See LICENSE for more information.

💡 Developer's Note

I built this to challenge the "WinForms is outdated" stereotype. If you find this UI logic or the expression engine helpful, feel free to fork it and don't forget to drop a ⭐!
