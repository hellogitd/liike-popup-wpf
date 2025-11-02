# 温馨提示弹窗应用 (Warm Reminder Popup App)

## 项目简介 (Project Introduction)

这是一个基于WPF（Windows Presentation Foundation）开发的温馨提示弹窗应用程序。当应用启动时，它会在屏幕上随机位置显示多个带有温暖、鼓励话语的彩色弹窗，为用户带来愉悦的视觉体验和积极的心理暗示。

This is a warm reminder popup application developed based on WPF (Windows Presentation Foundation). When launched, the application displays multiple colorful popups with warm, encouraging messages at random positions on the screen, bringing users a pleasant visual experience and positive psychological hints.

## 主要功能 (Main Features)

- 应用启动时自动显示50+条温馨提示消息
- 每个弹窗具有随机的位置和背景颜色
- 弹窗以平滑的顺序依次出现，避免视觉混乱
- 简约美观的用户界面设计

- Automatically displays 50+ warm reminder messages when the application starts
- Each popup has a random position and background color
- Popups appear in a smooth sequence to avoid visual confusion
- Simple and beautiful user interface design

## 技术实现 (Technical Implementation)

- 使用C#和WPF框架开发
- 采用多线程技术确保UI响应性
- 通过Dispatcher实现UI线程安全更新
- 使用随机数生成器控制弹窗位置和延迟
- 预定义多种温馨提示语和美观的颜色方案

- Developed using C# and WPF framework
- Multi-threading technology to ensure UI responsiveness
- UI thread-safe updates through Dispatcher
- Random number generator to control popup positions and delays
- Predefined multiple warm reminder messages and beautiful color schemes

## 应用场景 (Application Scenarios)

- 作为日常使用的心情提升工具
- 在工作环境中提供积极的心理暗示
- 为用户提供定时的自我关怀提醒
- 作为简单的桌面装饰应用

- As a daily mood-enhancing tool
- Providing positive psychological hints in work environments
- Offering users regular self-care reminders
- As a simple desktop decoration application

## 如何运行 (How to Run)

1. 确保您的系统已安装.NET Framework
2. 直接运行WpfAppbb.exe可执行文件
3. 应用启动后，温馨提示弹窗将自动开始显示

1. Ensure your system has .NET Framework installed
2. Directly run the WpfAppbb.exe executable file
3. After the application starts, warm reminder popups will automatically begin to display

## 项目结构 (Project Structure)

```
WpfAppbb/
├── App.config          # 应用程序配置文件
├── App.xaml            # 应用程序定义文件
├── App.xaml.cs         # 应用程序逻辑代码
├── MainWindow.xaml     # 主窗口XAML定义
├── MainWindow.xaml.cs  # 主窗口逻辑代码
├── Properties/         # 应用程序属性文件
└── WpfAppbb.csproj     # 项目配置文件
```

## 自定义说明 (Customization Instructions)

如果您希望自定义温馨提示语或颜色方案，可以修改`MainWindow.xaml.cs`文件中的`strings`和`colors`数组。每个数组中的元素都会被随机应用到生成的弹窗上。

If you want to customize the warm reminder messages or color schemes, you can modify the `strings` and `colors` arrays in the `MainWindow.xaml.cs` file. Each element in these arrays will be randomly applied to the generated popups.

## 开发环境 (Development Environment)

- Visual Studio
- .NET Framework
- WPF SDK

## 许可证 (License)

This project is open-source and available for personal use.

本项目为开源项目，可供个人使用。