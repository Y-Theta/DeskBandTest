using SettingWindowTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WindowsDeskBand.DeskBand.BandParts;
using WindowsDeskBand.DeskBand.BandParts.Menu;
using WPFBand;

namespace BandTest {
    /// <summary>
    /// BandControlT.xaml 的交互逻辑
    /// </summary>
    [ComVisible(true)]
    [Guid("eabd5a5b-4273-4fb8-a851-aa0d4b803534")]
    [BandRegistration(Name = "FlowBand", ShowDeskBand = true)]
    public partial class BandControlT : WPFBandControl {

        #region interop
        private const int SC_MONITORPOWER = 0xF170;
        private const int WM_SYSCOMMAND = 0x0112;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion

        private Dispatcher _uidispatcher;
        private AppDomain _settingprocess;

        private List<DeskBandMenuItem> _menu {
            get {
                DeskBandMenuAction setting = new DeskBandMenuAction("设置");
                setting.Clicked += Setting_Clicked;
                return new List<DeskBandMenuItem> { setting };
            }
        }

        private void Setting_Clicked(object sender, EventArgs e) {
            try {
                InitSettingWindow();
            }
            catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        public BandControlT() {
            Options.MinHorizontalSize.Width = 120;
            Options.ContextMenuItems = _menu;
            InitializeComponent();
            _uidispatcher = Dispatcher.CurrentDispatcher;
            InitAsync();
        }

        private void InitSettingWindow() {
            string cb = Assembly.GetExecutingAssembly().CodeBase;
            string path = cb.Replace(cb.Split('/').Last(), "");
            path = path.Replace(path.Split('/').First() + "///", "");
        }

        private async void InitAsync() {
            await Task.Run(() => {
                _uidispatcher.Invoke(() => {
                }, DispatcherPriority.Normal);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
        }
    }
}
