using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        private List<DeskBandMenuItem> ContextMenuItems {
            get {
                var action = new DeskBandMenuAction("流量监控设置");
                action.Clicked += Action_Clicked;
                return new List<DeskBandMenuItem>() { action };
            }
        }

        private void Action_Clicked(object sender, EventArgs e) {
            //TODO:Open your "Setting Window" to control deskband


        }

        public BandControlT() {
            InitializeComponent();
            Options.MinHorizontalSize.Width = 120;
            Options.ContextMenuItems = ContextMenuItems;
        }
    }
}
