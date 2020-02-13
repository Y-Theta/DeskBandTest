///------------------------------------------------------------------------------
/// @ Y_Theta
///------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BandTest {
    public class AssemblyResolve {
        #region Properties
        #endregion

        #region Methods
        public static Assembly Reslove(object sender, ResolveEventArgs args) {
            Assembly MyAssembly = null;
            String MisAssembly = "";
            if (args.Name.Contains(".resources")) {
                return null;
            }
            string cb = Assembly.GetExecutingAssembly().CodeBase;
            string path = cb.Replace(cb.Split('/').Last(), "");
            path = path.Replace(path.Split('/').First() + "///", "");
            List<string> Directorys = new List<string>() { path, AppDomain.CurrentDomain.BaseDirectory };
            foreach (var dir in Directorys) {
                string[] items = Directory.GetFileSystemEntries(dir, args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");
                if (items.Count() > 0) {
                    MisAssembly = items.First();
                    break;
                }
            }
            MessageBox.Show(MisAssembly);
            try {
                MyAssembly = Assembly.LoadFrom(MisAssembly);
            }
            catch {
                
            }
            return MyAssembly;
        }

        public static void DomainUnload(object sender, EventArgs e) {
            
        }
        #endregion

        #region Constructors
        public AssemblyResolve() {}
        #endregion
    }
}
