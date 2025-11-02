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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppbb
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                // Task.Run自动使用线程池线程，返回Task对象
                Task.Run(() =>
                {
                    // 更新UI需通过Dispatcher
                    this.Dispatcher.Invoke(() =>
                    {
                        ShowDialog();
                    });
                });
            }
        }

        private new void ShowDialog()
        {
            // 获取主屏幕对象
            Screen primaryScreen = Screen.PrimaryScreen;

            // 获取主屏幕物理像素宽高（分辨率）
            int screenWidth = primaryScreen.Bounds.Width - 300;
            int screenHeight = primaryScreen.Bounds.Height - 100;
            //随机数
            Random random = new Random();
            //预制语句
            string[] strings = { "想你啦，随时找我", "今天也惦记着你", "你的开心最重要", "我一直都在身边", "累了就靠靠我", 
                "有你在，很安心", "陪你度过每个瞬间", "往后日子，一起暖", "你已经很棒啦", "慢慢走，我等你", "别怕，有我在",
                "慢慢来，会好的", "你超有潜力的", "坚持住，我相信你", "每一步都没白走", "你值得所有美好", "勇敢点，你可以的",
                "小挫折，不算什么", "发光的你超迷人", "继续加油，超厉害", "不开心就说给我听", "难过时，我抱抱你", "没关系，我理解你",
                "一切都会慢慢变好", "别扛着，我陪着你", "坏情绪会悄悄溜走", "你已经做得很好了", "不勉强，舒服就好", "把烦恼都丢给我吧",
                "黑暗过后是晴天", "记得多喝温水呀", "天冷了，添件衣", "好好吃饭，别饿肚子", "今天也要好好照顾自己", "早餐一定要吃哦", 
                 "别太累，适当休息", "降温了，注意保暖", "多吃水果，补补维生素", "好好睡觉，养足精神", "别熬夜，早点休息", "慢慢来，别急呀",
                "别忘了爱自己呀", "偶尔偷懒也没关系", "别太较真，开心就好", "记得抬头看看阳光", "累了就停下来歇会", "对自己好一点呀", 
                "别给自己太大压力", "生活虽忙，别忘微笑" };
            //预制颜色
            string[] colors = { "#FFE6F2", "#FFEBD7", "#FFF3E0", "#F0E68C", "#FFDAB9", "#FFC0CB", "#E6E6FA", "#F5DEB3", "#FFE4E1", "#FFF8DC", "#FFE4B5", "#FFD700", "#F4A460", "#DDA0DD", "#FFB6C1", "#F8F8FF", "#F5F5DC", "#FFE4E1", "#FFC1C1", "#F0FFF0", "#FAFAD2", "#FFEBCD", "#DEB887", "#FFA07A", "#E0FFFF", "#F5FFFA", "#FFFACD", "#FFDAB9", "#FFC107", "#FFB347", "#FF8C00", "#F9DC5C", "#F7DC6F", "#BB8FCE", "#D2B48C", "#F8C471", "#FFE5B4", "#FF69B4", "#FF7F50", "#FFA500", "#FFD7C4", "#F6E5D1", "#F0E68C", "#FFE8CC", "#FFC8DD", "#FFE0BD", "#FFB6C1", "#F5F0E1", "#FFE4C4", "#FFD1DC" };
            //索引,颜色用
            int i = 0;
            foreach (string s in strings)
            {
                //设置弹窗标题、初始参数
                Window window = new Window();
                window.Title = "温馨提示";
                window.Width = 300;
                window.Height = 100;
                //设置弹窗背景色
                Color color = (Color)ColorConverter.ConvertFromString(colors[i]);
                window.Background = new SolidColorBrush(color);
                //在屏幕内任意位置出现
                window.Left = random.Next(screenWidth);
                window.Top = random.Next(screenHeight);
                //设置要显示的文本
                TextBlock textBlock = new TextBlock();
                textBlock.Text = s;//文本内容
                textBlock.FontSize = 24;//字号
                textBlock.TextAlignment = TextAlignment.Center;//居中对齐
                //设置组件到弹窗
                window.Content = textBlock;
                //随机延迟1-3s继续下一个循环
                Thread.Sleep(random.Next(100, 1000));
                //显示弹窗
                window.Show();
                i++;
            }
        }
    }
}
