using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
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
        private const int HWND_BROADCAST = 0xffff;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion

        private Dispatcher _uidispatcher;
        private AppDomain _settingprocess;
        private Timer _timer;
        private int _delay, _delayori;
        private string _settingfile;
        private string _path;

        public Geometry TimeRing {
            get { return (Geometry)GetValue(TimeRingProperty); }
            set { SetValue(TimeRingProperty, value); }
        }
        public static readonly DependencyProperty TimeRingProperty =
            DependencyProperty.Register("TimeRing", typeof(Geometry),
                typeof(BandControlT), new PropertyMetadata(null));

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
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void InitSettingWindow() {
            //string cb = Assembly.GetExecutingAssembly().CodeBase;
            //string path = cb.Replace(cb.Split('/').Last(), "");
            //path = path.Replace(path.Split('/').First() + "///", "");
            //var window = path + "SettingWindowTest.exe";
            //Process.Start(new ProcessStartInfo {
            //    FileName = window,
            //});
        }

        private PathGeometry CalculatePath(double angle) {
            double x, y, r, c, g;
            g = 6;
            c = 16;
            r = 16 - g;
            var A = angle * Math.PI / 180;
            x = r * Math.Sin(A) + c;
            y = c - r * Math.Cos(A);

            PathGeometry path = new PathGeometry();
            PathFigure item = new PathFigure();
            ArcSegment arc = new ArcSegment(new Point(x, y), new Size(r, r), 0, angle > 180, SweepDirection.Clockwise, true);
            item.Segments.Add(arc);
            item.StartPoint = new Point(c, g);
            path.Figures.Add(item);
            return path;
        }


        private void _timer_Elapsed(object sender, ElapsedEventArgs e) {
            if (_delay == 0) {
                SendMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2);
                _delay = _delayori;
                _timer.Stop();
                return;
            }
            _delay--;
            _uidispatcher.Invoke(() => {
                TimeRing = CalculatePath(360 * _delay / _delayori);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                string delay = Setting.Read("config", "TimeDelay", "1500", _settingfile);
                //File.WriteAllText(_path + "data.txt", _settingfile + "\n" + File.ReadAllText(_settingfile) + "\n" + delay  + "\n" + timestamp + "  -  " + DateTime.Now.ToString());
                _delay = _delayori = int.Parse(delay) / 50;
            } catch (Exception ex) {
                _delay = _delayori = 30;
                File.WriteAllText(_path + "error.txt", ex.Message + ex.StackTrace);
            }

            _timer.Start();
            //SendMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2);
        }

        public BandControlT() {
            Options.MinHorizontalSize.Width = 32;
            Options.ContextMenuItems = _menu;
            InitializeComponent();
            InitAsync();
            Init();
        }

        ~BandControlT() {
            _timer.Dispose();
        }

        private void Init() {
            _uidispatcher = Dispatcher.CurrentDispatcher;
            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Elapsed += _timer_Elapsed;

            string cb = Assembly.GetExecutingAssembly().CodeBase;
            string path = cb.Replace(cb.Split('/').Last(), "");
            _path = path.Replace(path.Split('/').First() + "///", "");
            _settingfile = _path + "setting.ini";
            Setting.Write("config", "TimeDelay", "1500", _settingfile);
        }

        private async void InitAsync() {
            //await Task.Run(() => {

            //});
        }
    }
}
