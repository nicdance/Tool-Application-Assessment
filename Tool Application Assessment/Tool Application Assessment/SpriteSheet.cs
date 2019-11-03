
using System.Drawing;

namespace Tool_Application_Assessment
{
    public class Spritesheet
    {
        public int UniqueID { get; set; }        public string Path { get; private set; }

        public int GridWidth { get; set; } = 32;
        public int GridHeight { get; set; } = 32;
        public int TilesHigh { get; set; } = 1;
        public int TilesWide { get; set; } = 1;
        public int Spacing { get; set; } = 1;

        public string Filename
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

        public Spritesheet(string path)
        {
            Path = path;
            Image = Image.FromFile(path);
        }

        public override string ToString()
        {
            return Filename;
        }
    }
}
