using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_Application_Assessment
{
    // The interface class which is implemented in each tool
    public interface IMapTools
    {
        void PaintTiles(ref MapTile[] map, int width, int startPosition, PaletteTile CurrentTile);
    }
}
