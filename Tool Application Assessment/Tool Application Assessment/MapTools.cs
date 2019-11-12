using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_Application_Assessment
{

    public abstract class MapTools
    {
        public abstract void PaintTiles(ref MapTile[] map, int width, int startPosition, PaletteTile CurrentTile);
        public MapTools() { }
    }
}
