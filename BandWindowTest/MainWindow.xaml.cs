using BandTest;
using System;
using System.Windows;
using WindowsDeskBand.DeskBand.Interop.COM;

namespace BandWindowTest {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {


        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Type trayDeskbandType = Type.GetTypeFromCLSID(new Guid("E6442437-6C68-4f52-94DD-2CFED267EFB9"));
            Guid deskbandGuid = typeof(BandControlT).GUID;
            ITrayDeskband csdeskband = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
            if (csdeskband != null) {
                csdeskband.DeskBandRegistrationChanged();
                if (csdeskband.IsDeskBandShown(ref deskbandGuid) == HRESULT.S_FALSE) {
                    csdeskband.ShowDeskBand(ref deskbandGuid);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Type trayDeskbandType = Type.GetTypeFromCLSID(new Guid("E6442437-6C68-4f52-94DD-2CFED267EFB9"));
            Guid deskbandGuid = typeof(BandControlT).GUID;
            ITrayDeskband csdeskband = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
            if (csdeskband != null) {
                csdeskband.DeskBandRegistrationChanged();
                if (csdeskband.IsDeskBandShown(ref deskbandGuid) == HRESULT.S_OK) {
                    csdeskband.HideDeskBand(ref deskbandGuid);
                }
            }
        }
    }

    internal class HRESULT {
        public static readonly int S_OK = 0;
        public static readonly int S_FALSE = 1;
        public static readonly int E_NOTIMPL = unchecked((int)0x80004001);
        public static readonly int E_FAIL = unchecked((int)0x80004005);

        public static int MakeHResult(uint sev, uint facility, uint errorNo) {
            uint result = sev << 31 | facility << 16 | errorNo;
            return unchecked((int)result);
        }
    }
}
