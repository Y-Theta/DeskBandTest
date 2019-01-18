#pragma warning disable 1591
using System.Drawing;
using System.Runtime.InteropServices;

namespace WindowsDeskBand.DeskBand.Interop.Struct {
    [StructLayout(LayoutKind.Sequential)]
    public struct COLORREF
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="COLORREF"/> from a <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The color.</param>
        public COLORREF(Color color) {
            R = (byte)(0x000000FFU & color.R);
            G = (byte)((0x0000FF00U & color.G) >> 8);
            B = (byte)((0x00FF0000U & color.B) >> 16);
        }

        public byte R;
        public byte G;
        public byte B;
    }
}