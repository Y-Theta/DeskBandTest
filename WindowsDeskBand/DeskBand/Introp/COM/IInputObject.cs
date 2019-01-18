#pragma warning disable 1591
using System.Runtime.InteropServices;
using WindowsDeskBand.DeskBand.Interop.Struct;

namespace WindowsDeskBand.DeskBand.Interop.COM
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("68284faa-6a48-11d0-8c78-00c04fd918b4")]
    public interface IInputObject
    {
        /// <summary>
        /// UI-activates or deactivates the object.
        /// </summary>
        /// <param name="fActivate">Indicates if the object is being activated or deactivated. If this value is nonzero, the object is being activated. If this value is zero, the object is being deactivated.</param>
        /// <param name="msg">A pointer to an MSG structure that contains the message that caused the activation change. This value may be NULL.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        int UIActivateIO(bool fActivate, ref MSG msg);

        /// <summary>
        /// Determines if one of the object's windows has the keyboard focus.
        /// </summary>
        /// <returns>Returns S_OK if one of the object's windows has the keyboard focus, or S_FALSE otherwise.</returns>
        [PreserveSig]
        int HasFocusIO();

        /// <summary>
        /// Enables the object to process keyboard accelerators.
        /// </summary>
        /// <param name="msg">The address of an MSG structure that contains the keyboard message that is being translated.</param>
        /// <returns>Returns S_OK if the accelerator was translated, or S_FALSE otherwise.</returns>
        [PreserveSig]
        int TranslateAcceleratorIO(ref MSG msg);
    }
}
