using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppbb
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 用于追踪所有显示的弹窗，方便统一管理
        private List<Window> popupWindows = new List<Window>();

        // 单例随机数生成器，避免多线程下的重复
        private readonly Random random = new Random();

        // 控制是否继续显示弹窗
        private bool isShowingPopups = false;

        // 用于取消异步任务
        private CancellationTokenSource cts;

        // 最大弹窗数量限制
        private int maxPopupCount = 500;

        // 弹窗显示时间（毫秒）
        private int popupDisplayTime = 300 * 1000;

        // 预制语句
        private readonly string[] messages = {
            "想你啦，随时找我", "今天也惦记着你", "你的开心最重要", "我一直都在身边", "累了就靠靠我",
            "有你在，很安心", "陪你度过每个瞬间", "往后日子，一起暖", "你已经很棒啦", "慢慢走，我等你",
            "别怕，有我在", "慢慢来，会好的", "你超有潜力的", "坚持住，我相信你", "每一步都没白走",
            "你值得所有美好", "勇敢点，你可以的", "小挫折，不算什么", "发光的你超迷人", "继续加油，超厉害",
            "不开心就说给我听", "难过时，我抱抱你", "没关系，我理解你", "一切都会慢慢变好", "别扛着，我陪着你",
            "坏情绪会悄悄溜走", "你已经做得很好了", "不勉强，舒服就好", "把烦恼都丢给我吧", "黑暗过后是晴天",
            "记得多喝温水呀", "天冷了，添件衣", "好好吃饭，别饿肚子", "今天也要好好照顾自己", "早餐一定要吃哦",
            "别太累，适当休息", "降温了，注意保暖", "多吃水果，补补维生素", "好好睡觉，养足精神", "别熬夜，早点休息",
            "慢慢来，别急呀", "别忘了爱自己呀", "偶尔偷懒也没关系", "别太较真，开心就好", "记得抬头看看阳光",
            "累了就停下来歇会", "对自己好一点呀", "别给自己太大压力", "生活虽忙，别忘微笑"
        };

        // 预制颜色
        private readonly string[] colors = {
            "#FFE6F2", "#FFEBD7", "#FFF3E0", "#F0E68C", "#FFDAB9", "#FFC0CB", "#E6E6FA", "#F5DEB3", "#FFE4E1", "#FFF8DC",
            "#FFE4B5", "#FFD700", "#F4A460", "#DDA0DD", "#FFB6C1", "#F8F8FF", "#F5F5DC", "#FFC1C1", "#F0FFF0", "#FAFAD2",
            "#FFEBCD", "#DEB887", "#FFA07A", "#E0FFFF", "#F5FFFA", "#FFFACD", "#FFC107", "#FFB347", "#FF8C00", "#F9DC5C",
            "#F7DC6F", "#BB8FCE", "#D2B48C", "#F8C471", "#FFE5B4", "#FF69B4", "#FF7F50", "#FFA500", "#FFD7C4", "#F6E5D1",
            "#FFE8CC", "#FFC8DD", "#FFE0BD", "#F5F0E1", "#FFE4C4", "#FFD1DC"
        };

        // 打乱后的消息列表，用于循环显示
        private string[] shuffledMessages;

        // 当前显示的消息索引
        private int currentMessageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            // 初始化打乱的消息列表
            shuffledMessages = messages.ToArray();
            ShuffleMessages();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 程序启动后自动开始显示弹窗
            await StartShowingPopupsAsync();

            // 启动后隐藏主窗口
            this.Hide();
        }

        // 开始显示弹窗
        private async Task StartShowingPopupsAsync()
        {
            if (isShowingPopups) return;

            isShowingPopups = true;
            cts = new CancellationTokenSource();

            try
            {
                while (isShowingPopups && !cts.Token.IsCancellationRequested)
                {
                    // 检查当前弹窗数量是否超过限制
                    if (popupWindows.Count < maxPopupCount)
                    {
                        // 在UI线程上创建并显示弹窗
                        this.Dispatcher.Invoke(() =>
                        {
                            CreateAndShowPopup();
                        });
                    }

                    // 随机延迟一段时间再显示下一个弹窗
                    await Task.Delay(random.Next(100, 1000), cts.Token);
                }
            }
            catch (TaskCanceledException) { }
            finally
            {
                isShowingPopups = false;
            }
        }

        // 创建并显示一个弹窗
        private void CreateAndShowPopup()
        {
            // 获取主屏幕对象
            Screen primaryScreen = Screen.PrimaryScreen;

            // 获取主屏幕物理像素宽高（分辨率）
            int screenWidth = primaryScreen.Bounds.Width - 320;
            int screenHeight = primaryScreen.Bounds.Height - 120;

            // 创建弹窗
            Window window = new Window
            {
                Title = "温馨提示",
                Width = 300,
                Height = 100,
                ShowInTaskbar = false,
                Topmost = true,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.ToolWindow,
                // 设置弹窗背景色
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colors[random.Next(colors.Length)]))
            };

            // 在屏幕内任意位置出现
            window.Left = random.Next(Math.Max(0, screenWidth));
            window.Top = random.Next(Math.Max(0, screenHeight));

            // 创建文本控件
            TextBlock textBlock = new TextBlock
            {
                Text = GetNextMessage(), // 获取下一条消息
                FontSize = 20,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Margin = new Thickness(10),
                TextWrapping = TextWrapping.Wrap
            };

            // 设置组件到弹窗
            window.Content = textBlock;

            // 添加到追踪列表
            popupWindows.Add(window);

            // 设置关闭事件，从追踪列表中移除
            window.Closed += (s, e) =>
            {
                popupWindows.Remove(window);
            };

            // 显示弹窗
            window.Show();

            // 应用淡入动画
            ApplyFadeInAnimation(window);

            // 启动自动关闭计时器
            StartAutoCloseTimer(window);
        }

        // 获取下一条消息
        private string GetNextMessage()
        {
            if (currentMessageIndex >= shuffledMessages.Length)
            {
                // 当所有消息显示完毕后，重新打乱列表
                ShuffleMessages();
                currentMessageIndex = 0;
            }

            return shuffledMessages[currentMessageIndex++];
        }

        // 打乱消息列表
        private void ShuffleMessages()
        {
            int n = shuffledMessages.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = shuffledMessages[k];
                shuffledMessages[k] = shuffledMessages[n];
                shuffledMessages[n] = value;
            }
        }

        // 应用淡入动画
        private void ApplyFadeInAnimation(Window window)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromMilliseconds(500))
            };

            window.BeginAnimation(Window.OpacityProperty, fadeInAnimation);
        }

        // 应用淡出动画
        private void ApplyFadeOutAnimation(Window window, Action onCompleted)
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromMilliseconds(500))
            };

            fadeOutAnimation.Completed += (s, e) => onCompleted?.Invoke();
            window.BeginAnimation(Window.OpacityProperty, fadeOutAnimation);
        }

        // 启动自动关闭计时器
        private void StartAutoCloseTimer(Window window)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(popupDisplayTime)
            };

            timer.Tick += (s, e) =>
            {
                timer.Stop();

                // 应用淡出动画后关闭窗口
                ApplyFadeOutAnimation(window, () =>
                {
                    if (window.IsLoaded) // 确保窗口仍然加载
                        window.Close();
                });
            };

            timer.Start();
        }

        // 停止显示弹窗
        private void StopShowingPopups()
        {
            isShowingPopups = false;
            cts?.Cancel();
            cts?.Dispose();
        }

        // 关闭所有弹窗
        private void CloseAllPopups()
        {
            // 复制列表以避免在迭代过程中修改
            var windowsToClose = new List<Window>(popupWindows);

            foreach (var window in windowsToClose)
            {
                if (window.IsLoaded)
                {
                    ApplyFadeOutAnimation(window, () =>
                    {
                        if (window.IsLoaded)
                            window.Close();
                    });
                }
            }
        }

        // 窗口关闭时清理资源
        protected override void OnClosed(EventArgs e)
        {
            StopShowingPopups();
            CloseAllPopups();
            base.OnClosed(e);
        }
    }
}
