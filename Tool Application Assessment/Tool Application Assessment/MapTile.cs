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
        public PictureBox Picture { get; set; }     // The picture box of the current tile which is added to the map
        public int Height { get; set; }             // height of the current tile
        public int Width { get; set; }              // width of the current tile
        public int UniqueID { get; set; }           // unique id of the tile
        public int PalletteID { get; set; }         // ID of the pallette assigned to this tile


        // Overriden ToString to allow for correct format when saving out to file.
        public override string ToString()
        {
            return "M,"+Height + "," + Width + ","+ UniqueID + ","+ PalletteID;
        }
    }
}
