using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinBand;
using System.Runtime.InteropServices;
using WindowsDeskBand.DeskBand.BandParts;
using WindowsDeskBand.DeskBand.BandParts.Menu;
using System.Windows.Threading;
using System.Windows;
using System.Reflection;
using System.IO;
using System.Windows.Forms.Integration;
using BandTest_WinForm_.Utils;
using System.Threading;
using System.Diagnostics;

namespace BandTest_WinForm_ {
    // public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [Guid("5731FC61-8530-404C-86C1-86CCB8738D06")]
    [BandRegistration(Name = "BandTest", ShowDeskBand = true)]
    public partial class BandControlT : WinBandControl {

        #region Properties

        private List<DeskBandMenuItem> _menu {
            get {
                DeskBandMenuAction setting = new DeskBandMenuAction("设置");
                setting.Clicked += Setting_Clicked;
                return new List<DeskBandMenuItem> { setting };
            }
        }

        private readonly Dispatcher _uidispatcher;

        // private SettingWindow _settingwindow;
        #endregion

        public BandControlT() {
            InitializeComponent();
            _uidispatcher = Dispatcher.CurrentDispatcher;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            InitAsync();
            LogUtil.DLog("Start");
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            LogUtil.DLog(args.RequestingAssembly.GetName().Name + "Needs" + args.Name);
            var asmName = args.Name.Substring(0, args.Name.IndexOf(','));
            if (asmName.Contains("resources"))
                return null;
            string dir = Assembly.GetExecutingAssembly().Location;
            dir = dir.Replace(Assembly.GetExecutingAssembly().GetName().Name + ".dll", "");
            var filename = Path.Combine(dir, asmName + ".dll");
            LogUtil.DLog(filename);
            return File.Exists(filename) ? Assembly.LoadFrom(filename) : null;
        }

        private async Task InitAsync() {
            await Task.Run(() => {
                Options.ContextMenuItems = _menu;
                Options.MinHorizontalSize.Width = 120;
                LogUtil.DLog("OK");
            });
        }

        private void Setting_Clicked(object sender, EventArgs e) {
            LogUtil.DLog("Open");
            try {
                
            }
            catch (Exception err) {
                LogUtil.DLog(err.Message);
                LogUtil.DLog(err.StackTrace);
            }
        }

        protected override void OnClose() {
            LogUtil.DLog("Exit");
        }
    }
}
