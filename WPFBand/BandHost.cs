using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace WPFBand {
    internal partial class BandHost : Form {
        private ElementHost _host;

        public BandHost(System.Windows.Controls.UserControl control) {
            FormBorderStyle = FormBorderStyle.None;
            AllowTransparency = true;
            TransparencyKey = Color.Black;
            BackColor = Color.Black;

            _host = new ElementHost {
                Child = control,
                AutoSize = true,
                Dock = DockStyle.Fill, //This is required or else it will crash
                BackColorTransparent = true,
            };

            Controls.Add(_host);
        }
    }
}
