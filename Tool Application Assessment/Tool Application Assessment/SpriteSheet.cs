
using System.Drawing;

namespace Tool_Application_Assessment
{
    public class SpriteSheet
    {
        public int UniqueID { get; set; }               // ID of the spritresheet
        public string Path { get; private set; }        // Path to the filesheet image
        public int GridWidth { get; set; } = 32;        // width of the tile
        public int GridHeight { get; set; } = 32;       // height of the tile
        public int TilesHigh { get; set; } = 1;         // number of tiles high
        public int TilesWide { get; set; } = 1;         // number of tiles wide
        public int Spacing { get; set; } = 1;           // any spacing between tiles

        public string Filename                          // retreives the file name out of the path
        {
            get { return Path.Substring(Path.LastIndexOf('\\')); }
        }

        public Image Image
        {
            get; private set;
        }

        public int Width
        {
            get
            {
                return (Image != null) ? Image.Width : 0;
            }
        }
        public int Height
        {
            get
            {
                return (Image != null) ? Image.Height : 0;
            }
        }

        // add try catch incase of file not found
        public SpriteSheet(string path)
        {
            Path = path;
            Image = Image.FromFile(path);
        }


        // Overriden ToString to allow for correct format when saving out to file.
        public override string ToString()
        {
            return "F," + UniqueID + "," + Path + "," + GridWidth + "," + GridHeight + "," + TilesHigh + "," + TilesWide + "," + Spacing;
        }

    }
}
