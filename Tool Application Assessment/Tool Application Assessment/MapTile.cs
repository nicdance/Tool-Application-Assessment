using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Tool_Application_Assessment
{
    class MapTile
    {
        public PictureBox Picture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int UniqueID { get; set; }
    }
}
