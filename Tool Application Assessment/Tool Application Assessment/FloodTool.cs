using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_Application_Assessment
{
    public class FloodTool : IMapTools
    {
        // Iplements paint tiles to flood the map passed in with the specific tile.
        public void PaintTiles(ref MapTile[] map, int width, int startPosition, PaletteTile CurrentTile)
        {
            for (int i = 0; i < map.Length; i++)
            { 
                map[i].Picture.Image = null;
                map[i].Picture.Image = CurrentTile.Picture.Image;
                map[i].PalletteID = CurrentTile.UniqueID;
            }
        }

        public FloodTool() { }
    }
}
