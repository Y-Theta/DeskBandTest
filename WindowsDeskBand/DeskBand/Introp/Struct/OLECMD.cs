using System.Runtime.InteropServices;

namespace WindowsDeskBand.DeskBand.Interop.Struct {
    [StructLayout(LayoutKind.Sequential)]
    internal struct OLECMD
    {
        public uint cmdID;
        public uint cmdf;
    }
}
