# IMPORTANT!
This app is Still in Development!, there could be sudden crashes and Random Exceptions.

# FileMonitor

FileMonitor is a C# application designed to live monitor a file and display its content dynamically. It offers a customizable theme system and supports file monitoring with automatic updates when changes occur.

## Features

- **Live File Monitoring:** Automatically updates file content when changes are detected.
- **Customizable Themes:** Choose from multiple themes to personalize the application's appearance.
- **User-friendly Interface:** Simple and intuitive interface for easy navigation and use.

## Screenshots

![Pink, Sky Blue, Dark And Light Themes](screenshots/fourthemes.png?raw=true "")

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/taldb/FileMonitor.git
   ```
2. Open the solution in Visual Studio.
3. Build and run the project.

## Usage

1. **Open File:** Select a file to monitor using the "Open" option in the menu.
2. **Start Monitoring:** Begin monitoring the selected file to receive real-time updates.
3. **Change Themes:** Switch between different themes such as Dark Mode, Light Mode, and Sky Blue Mode (You can install More).

## Themes

FileMonitor supports the following themes:

- **Dark Mode:** Stylish dark interface with high contrast.
- **Light Mode:** Clean and light interface for improved readability.
- **Sky Blue Mode:** Blue-themed interface for a refreshing look.

## Making Themes
all theme Files needs to have a '.dbt' Extension.

- NOTE - theme file ONLY supports Hex Color codes (For now)

File Structure:

```
name:<Theme Name>
MenuItemBackground: #99cbec
ToolStripBackground: #99cbec
TextColor: #FFFFFF
BackColor: #74b5e4
ToolStripItemText: #FFFFFF
ToolStripItemBackground: #74b5e4
```
## Contributing

Contributions are welcome! If you find any bugs or have suggestions for improvements, please create an issue or a pull request.

## License

This project is licensed under the GPL-3.0 License - see the [LICENSE](LICENSE) file for details.

---
