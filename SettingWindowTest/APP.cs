///------------------------------------------------------------------------------
/// @ Y_Theta
///------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SettingWindowTest {
    public class APP {

        [STAThread]
        static void Main(string[] args) {
            SettingWindow main = new SettingWindow();
            main.ShowInTaskbar = false;
            main.ShowDialog();
        }
    }
}
