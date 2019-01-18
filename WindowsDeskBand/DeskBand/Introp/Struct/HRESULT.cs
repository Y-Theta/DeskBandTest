namespace WindowsDeskBand.DeskBand.Interop.Struct {
    internal class HRESULT
    {
        public static readonly int S_OK = 0;
        public static readonly int S_FALSE = 1;
        public static readonly int E_FAIL = -2147467259;
        public static readonly int E_NOTIMPL = unchecked((int)0x80004001);

        public static int MakeHResult(uint sev, uint facility, uint errorNo)
        {
            return (int)((sev << 31) | (facility << 16) | errorNo);
        }
    }
}