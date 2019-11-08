using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tool_Application_Assessment
{
    public class PaletteTile
    {
        public PictureBox Picture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int XStartPosition { get; set; }
        public int YStartPosition { get; set; }
        public int UniqueID { get; set; }
        public int SpriteSheetID { get; set; }
        public bool Multiple { get; set; }

        public string IsMultiple()
        {
            if (Multiple)
            {
                return "S";
            }
            return "T";
        }
        public void SetPosition(int xpos, int ypos) {
            //startPosition.posX = xpos;

        }

        public override string ToString()
        {
            return IsMultiple() + ":" + Height + ":" + Width + ":" + XStartPosition + ":" + YStartPosition + ":" + UniqueID + ":" + SpriteSheetID;
        }
    }
}
