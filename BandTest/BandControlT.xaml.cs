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

        public BandControlT() {
            Options.MinHorizontalSize.Width = 120;
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
    }
}
