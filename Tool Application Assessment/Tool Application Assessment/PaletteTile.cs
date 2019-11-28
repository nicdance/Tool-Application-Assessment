using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tool_Application_Assessment
{
    public class PaletteTile
    {
        public PictureBox Picture { get; set; }     // TRhe picturebox of the paleyye
        public int Height { get; set; }             // Heiught of the tile
        public int Width { get; set; }              // Width of the tile
        public int XStartPosition { get; set; }     // x positiong of th etop left  pixel in the image
        public int YStartPosition { get; set; }     // y positiong of th etop left  pixel in the image
        public int UniqueID { get; set; }           // Uniqyue Pallete ID
        public int SpriteSheetID { get; set; }      // ID of the spritesheet the image is from
        public bool Multiple { get; set; }          // Is there multiple tile images in the sprite,

        // Returns S or T is a Sheet or Tile
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

        // Overriden ToString to allow for correct format when saving out to file.
        public override string ToString()
        {
            return IsMultiple() + "," + Height + "," + Width + "," + XStartPosition + "," + YStartPosition + "," + UniqueID + "," + SpriteSheetID;
        }
    }
}
