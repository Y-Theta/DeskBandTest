#pragma warning disable 1591
using System;
using System.Runtime.InteropServices;

namespace WindowsDeskBand.DeskBand.Interop.COM
{
    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms680102(v=vs.85).aspx
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000114-0000-0000-C000-000000000046")]
    public interface IOleWindow
    {
        /// <summary>
        /// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
        /// </summary>
        /// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
        /// <returns>This method returns S_OK on success. </returns>
        [PreserveSig]
        int GetWindow(out IntPtr phwnd);

        /// <summary>
        /// Determines whether context-sensitive help mode should be entered during an in-place activation session.
        /// </summary>
        /// <param name="fEnterMode">TRUE if help mode should be entered; FALSE if it should be exited.</param>
        /// <returns>This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in fEnterMode.</returns>
        [PreserveSig]
        int ContextSensitiveHelp(bool fEnterMode);
    }
}