using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_Application_Assessment
{
    public class MediumTool : IMapTools
    {
        public void PaintTiles(ref MapTile[] map, int width, int startPosition, PaletteTile CurrentTile)
        {

            map[startPosition].Picture.Image = null;
            map[startPosition].Picture.Image = CurrentTile.Picture.Image;
            map[startPosition].PalletteID = CurrentTile.UniqueID;

            if ((startPosition%width) != width - 1)
            {
                map[startPosition + 1].Picture.Image = null;
                map[startPosition + 1].Picture.Image = CurrentTile.Picture.Image;
                map[startPosition + 1].PalletteID = CurrentTile.UniqueID;
            }

            if ((startPosition % width) != 0)
            {
                map[startPosition - 1].Picture.Image = null;
                map[startPosition - 1].Picture.Image = CurrentTile.Picture.Image;
                map[startPosition - 1].PalletteID = CurrentTile.UniqueID;
            }

            if ((startPosition / width) != (map.Length/width) - 1)
            {
                map[startPosition + width].Picture.Image = null;
                map[startPosition + width].Picture.Image = CurrentTile.Picture.Image;
                map[startPosition + width].PalletteID = CurrentTile.UniqueID;
            }

            if ((startPosition / width) != 0)
            {
                map[startPosition - width].Picture.Image = null;
                map[startPosition - width].Picture.Image = CurrentTile.Picture.Image;
                map[startPosition - width].PalletteID = CurrentTile.UniqueID;
            }
        }

        public MediumTool() {
        }
    }
}
