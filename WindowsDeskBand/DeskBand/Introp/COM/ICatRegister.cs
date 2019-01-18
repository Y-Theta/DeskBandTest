using System;
using System.Runtime.InteropServices;
using WindowsDeskBand.DeskBand.Interop.Struct;

namespace WindowsDeskBand.DeskBand.Interop.COM
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0002E012-0000-0000-C000-000000000046")]
    internal interface ICatRegister
    {
        /// <summary>
        /// Registers one or more component categories. Each component category 
        /// consists of a CATID and a list of locale-dependent description strings.
        /// </summary>
        /// <param name="cCategories">The number of component categories to register.</param>
        /// <param name="rgCategoryInfo">
        /// The array of cCategories CATEGORYINFO structures. By providing the same 
        /// CATID for multiple CATEGORYINFO structures, multiple locales can be 
        /// registered for the same component category. 
        /// </param>
        [PreserveSig]
        int RegisterCategories(uint cCategories, [In, MarshalAs(UnmanagedType.LPArray)] CATEGORYINFO[] rgCategoryInfo);

        /// <summary>
        /// Removes the registration of one or more component categories. Each component 
        /// category consists of a CATID and a list of locale-dependent description strings.
        /// </summary>
        /// <param name="cCategories">The number of cCategories CATIDs to be removed.</param>
        /// <param name="rgcatid">Identifies the categories to be removed.</param>
        [PreserveSig]
        int UnRegisterCategories(uint cCategories, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);

        /// <summary>
        /// Registers the class as implementing one or more component categories.
        /// </summary>
        /// <param name="rclsid">The class ID of the relevent class for which category information will be set.</param>
        /// <param name="cCategories">The number of categories to associate as category identifiers for the class.</param>
        /// <param name="rgcatid">The array of cCategories CATIDs to associate as category identifiers for the class.</param>
        [PreserveSig]
        int RegisterClassImplCategories([In] ref Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);

        /// <summary>
        /// Removes one or more implemented category identifiers from a class.
        /// </summary>
        /// <param name="rclsid">The class ID of the relevant class to be manipulated.</param>
        /// <param name="cCategories">The number of category CATIDs to remove.</param>
        /// <param name="rgcatid">The array of cCategories CATID that are to be removed. Only the category IDs specified in this array are removed.</param>
        [PreserveSig]
        int UnRegisterClassImplCategories([In] ref Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);

        /// <summary>
        /// Registers the class as requiring one or more component categories.
        /// </summary>
        /// <param name="rclsid">The class ID of the relevent class for which category information will be set.</param>
        /// <param name="cCategories">The number of category CATIDs to associate as category identifiers for the class.</param>
        /// <param name="rgcatid">The array of cCategories CATID to associate as category identifiers for the class.</param>
        [PreserveSig]
        int RegisterClassReqCategories([In] ref Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);

        /// <summary>
        /// Removes one or more required category identifiers from a class.
        /// </summary>
        /// <param name="rclsid">The class ID of the relevent class to be manipulated.</param>
        /// <param name="cCategories">The number of category CATIDs to remove.</param>
        /// <param name="rgcatid">The array of cCategories CATID that are to be removed. Only the category IDs specified in this array are removed.</param>
        [PreserveSig]
        int UnRegisterClassReqCategories([In] ref Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] rgcatid);
    }

    //Exceptions when using this. Seems that dlls need to be registered in GAC
    internal class ComponentCategoryManager
    {
        public static readonly Guid CATID_DESKBAND = new Guid("00021492-0000-0000-C000-000000000046");

        private static readonly Guid _componentCategoryManager = new Guid("0002e005-0000-0000-c000-000000000046");
        private static readonly ICatRegister _catRegister;
        private Guid _classId;

        static ComponentCategoryManager()
        {
            _catRegister = Activator.CreateInstance(Type.GetTypeFromCLSID(_componentCategoryManager, true)) as ICatRegister;
        }

        private ComponentCategoryManager(Guid classId)
        {
            _classId = classId;
        }

        public static ComponentCategoryManager For(Guid classId)
        {
            return new ComponentCategoryManager(classId);
        }

        public void RegisterCategories( Guid[] categoryIds)
        {
            _catRegister.RegisterClassImplCategories(ref _classId, (uint)categoryIds.Length, categoryIds);
        }

        public void UnRegisterCategories(Guid[] categoryIds)
        {
            _catRegister.UnRegisterClassImplCategories(ref _classId, (uint)categoryIds.Length, categoryIds);
        }
    }
}
