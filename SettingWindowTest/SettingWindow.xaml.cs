using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SettingWindowTest {
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : Window {
        public SettingWindow() {
            InitializeComponent();
            MouseLeftButtonDown += SettingWindow_MouseDown;
        }

        private void SettingWindow_MouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {

        }
    }
}
