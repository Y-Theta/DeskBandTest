using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Controls;
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
    public partial class BandControlT : WBandControl {
        private Dispatcher _uidispatcher;

        private List<DeskBandMenuItem> _menu {
            get {
                DeskBandMenuAction setting = new DeskBandMenuAction("设置");
                setting.Clicked += Setting_Clicked;
                return new List<DeskBandMenuItem> { setting };
            }
        }

        private void Setting_Clicked(object sender, EventArgs e) {
            //TODO:Open Setting Window
        }

        public BandControlT() {
            Options.MinHorizontalSize.Width = 120;
            Options.ContextMenuItems = _menu;
            InitializeComponent();
            _uidispatcher = Dispatcher.CurrentDispatcher;
            InitAsync();
        }

        private async Task InitAsync() {
            await Task.Run(() => {
                _uidispatcher.Invoke(() => {
                    TextHolder.Text = "Hello";
                }, DispatcherPriority.Normal);
            });
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {
            Random rand = new Random();
            TextHolder.Text = rand.Next(1, 10).ToString() ;
        }
    }
}
