using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_Application_Assessment
{
    public class SmallTool:IMapTools
    {
        // implements IMapTools PaintTiles to reflect a small paint,
        public void PaintTiles(ref MapTile[] map, int width, int startPosition, PaletteTile CurrentTile)
        {
            map[startPosition].Picture.Image = null;
            map[startPosition].Picture.Image = CurrentTile.Picture.Image;
            map[startPosition].PalletteID = CurrentTile.UniqueID;
        }
        public SmallTool() { }
    }
}
