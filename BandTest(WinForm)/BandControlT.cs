using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBand;
using System.Runtime.InteropServices;
using WindowsDeskBand.DeskBand.BandParts;

namespace BandTest_WinForm_ {
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [Guid("5731FC61-8530-404C-86C1-86CCB8738D06")]
    [BandRegistration(Name = "BandTest", ShowDeskBand = true)]
    public partial class BandControlT : WinBandControl {
        #region DLLImprot

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        //Get active window title code from stack overflow
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        #endregion

        #region Properties
        private readonly WinEventDelegate _delegate;
        private readonly IntPtr _hookId;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        #endregion

        public BandControlT() {
            InitializeComponent();
            Options.HorizontalSize.Width = Options.MinHorizontalSize.Width = 120;
            
            UpdateLabel();
            _delegate = CallBack;
            _hookId = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, _delegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        protected override void OnClose() {
            base.OnClose();
            UnhookWinEvent(_hookId);
        }

        private void UpdateLabel() {
            _label1.Text = GetActiveWindowTitle() ?? _label1.Text;
        }

        private void CallBack(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime) {
            UpdateLabel();
        }

        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        private string GetActiveWindowTitle() {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0) {
                return Buff.ToString();
            }
            return null;
        }
    }
}
