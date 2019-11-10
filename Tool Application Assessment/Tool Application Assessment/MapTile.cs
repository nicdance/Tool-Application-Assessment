using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Tool_Application_Assessment
{
    public class MapTile
    {
        public PictureBox Picture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int UniqueID { get; set; }
        public int PalletteID { get; set; }

        public override string ToString()
        {
            return "M,"+Height + "," + Width + ","+ UniqueID + ","+ PalletteID;
        }
    }
}
