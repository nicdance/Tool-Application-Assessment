using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tool_Application_Assessment
{
    public partial class MapEditor : Form
    {
        public int size = 64;                                               // The size of each tile in the map
        public MapTile[] map;                                               // array of each MapTile int he current map
        public List<PaletteTile> paletteTiles = new List<PaletteTile>();    // a list of all PalletteTiles
      //  public List<PictureBox> tiles = new List<PictureBox>();             
        public List<SpriteSheet> sheets = new List<SpriteSheet>();          // the List of all spritesheets used in this map
        int mapWidth = 0;                                                   // How many MapTile's wide the map is
        int mapHeight = 0;                                                  // How many MapTile's Heigh the map is


        public PaletteTile CurrentTile { get; private set; }                // Reference to the current PalleteTile selected
        public bool Painting { get; private set; } = false;                 // check to see if the user is clicked ad dragging there mouse arround the map area to paint.

        public MapEditor(TileMapEditor parentForm)
        {
            this.MdiParent = parentForm;
            InitializeComponent();
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;

            // assign to event listeners
            parentForm.OnAddSpriteSheet += AddNewSheet;
            parentForm.OnFillPallette += PopulatePalette;
            parentForm.OnEditMapTile += EditMapTile;
           

        }
        // Called when current map is closed to ensure any active listeners are removed.
        public void ClearListeners()
        {
            TileMapEditor parentForm = this.MdiParent as TileMapEditor;
            // assign to event listeners
            parentForm.OnAddSpriteSheet -= AddNewSheet;
            parentForm.OnFillPallette -= PopulatePalette;
            parentForm.OnEditMapTile -= EditMapTile;
        }

        // Adds new sheet to the map and poulates the palette
        public void AddNewSheet(SpriteSheet sheet) {
             sheet.UniqueID = sheets.Count;
             sheets.Add(sheet);
             PopulatePalette();
         }

        // Updates a selected maptile with details of its new  palette
         public void EditMapTile(int height, int width, int ID, int paletteID)
         {
            try
            {

                map[ID].Height = height;
                map[ID].Width = width;
                map[ID].UniqueID = ID;
                map[ID].PalletteID = paletteID;

                map[ID].Picture.Image = null;
                map[ID].Picture.Image = paletteTiles[paletteID].Picture.Image;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                //throw;
            }

         }

        /*
         public void RefreshMap()
         {
             foreach (var box in MapPanel.Controls)
             {
                 tileFlowPanel.Controls.Clear();
             }
             for (int ii = 0; ii < map.Length; ii++)
             {
                 MapPanel.Controls.Add(map[ii].Picture);
             }

         }
         */

         // clears the palette and repopulates it with all current tiles.
         public void PopulatePalette()
         {
             foreach (var box in tileFlowPanel.Controls)
             {
                 tileFlowPanel.Controls.Clear();
             }
             for (int ii = 0; ii < paletteTiles.Count; ii++)
             {
                 paletteTiles.Clear();
             }
             for (int ii = 0; ii < sheets.Count; ii++)
             {
                 for (int i = 0; i < sheets[ii].TilesHigh * sheets[ii].TilesWide; i++)
                 {
                     PaletteTile palette = new PaletteTile();
                     palette.UniqueID = paletteTiles.Count;
                     palette.SpriteSheetID = sheets[ii].UniqueID;

                     PictureBox box = new PictureBox();
                     Bitmap drawArea = new Bitmap(size, size);
                     box.Size = new Size(size, size);
                     box.SizeMode = PictureBoxSizeMode.Zoom;
                     box.Image = drawArea;
                     box.Enabled = true;
                     //box.MouseDown += new MouseEventHandler(TileMouseDown);
                     palette.Picture = box;

                     Graphics g = Graphics.FromImage(drawArea);
                     g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);

                     Rectangle dest = new Rectangle(0, 0, size, size);

                     palette.XStartPosition = (i % sheets[ii].TilesWide) * (sheets[ii].GridWidth + sheets[ii].Spacing);
                     palette.YStartPosition = ((int)i / sheets[ii].TilesWide) * (sheets[ii].GridHeight + sheets[ii].Spacing);
                     palette.Height = sheets[ii].GridWidth;
                     palette.Width = sheets[ii].GridHeight;

                     Rectangle source = new Rectangle(palette.XStartPosition, palette.YStartPosition,
                                     palette.Width, palette.Height);
                     g.DrawImage(sheets[ii].Image, dest, source, GraphicsUnit.Pixel);

                     palette.Picture.Image = drawArea;

                     palette.Picture.MouseDown += new MouseEventHandler(TileBlockClicked);
                     g.Dispose();

                     tileFlowPanel.Controls.Add(palette.Picture);
                     paletteTiles.Add(palette);
                 }
             }
         }

        // Sets up the  new map and positions all tiles.
         public void NewMap(int width, int height, int mapSize)
         {
             mapWidth = width;
             mapHeight = height;
             size = mapSize;
             MapPanel.Padding = new Padding(0);
             map = new MapTile[width * height];
             for (int i = 0; i < width * height; i++)
             {
                 MapTile tile = new MapTile();
                 tile.Width = size;
                 tile.Height = size;
                 tile.UniqueID = i;
                 tile.Picture = new PictureBox();
                 tile.Picture.Size = new Size(size, size);
                 tile.Picture.SizeMode = PictureBoxSizeMode.Zoom;
                tile.Picture.BorderStyle = BorderStyle.FixedSingle;
                 tile.Picture.Location = new System.Drawing.Point((i % width) * size, ((int)(i/ width)) * size);
                 map[i] = tile;
                 MapPanel.Controls.Add(tile.Picture);
                 tile.Picture.Enabled = false;
             }
             MapPanel.AllowDrop = true;
             MapPanel.MouseDown += new MouseEventHandler(OnTileClick);
             MapPanel.HorizontalScroll.Enabled = true;
             MapPanel.VerticalScroll.Enabled = true;
         }

         private void TileMouseDown(object sender, MouseEventArgs e)
         {
             PictureBox box = sender as PictureBox;
         }

         // Onclicking a Palette tile  the current tile is set to it and  the border style of the current palette tile clicked is updated.
         private void TileBlockClicked(object sender, EventArgs e)
         {
             if (CurrentTile != null)
             {
                 CurrentTile.Picture.BorderStyle = BorderStyle.None;

             }
             if (e.GetType() == typeof(MouseEventArgs))
             {
                 PictureBox box = sender as PictureBox;
                 for (int i = 0; i < paletteTiles.Count; i++)
                 {
                     if (paletteTiles[i].Picture == box)
                     {
                         CurrentTile = paletteTiles[i];
                         break;
                     }
                 }
                 CurrentTile.Picture.BorderStyle = BorderStyle.Fixed3D;
             }
         }

         // On clicking a tile on the map if there is a current tile then the tle i changed to the current tile.
         void OnTileClick(object sender, MouseEventArgs e)
         {
            try
            {
                if (CurrentTile != null)
                {
                    Point scrolledPoint = new Point(e.X - MapPanel.AutoScrollPosition.X,
                                               e.Y - MapPanel.AutoScrollPosition.Y);
                    int tile = ((int)(scrolledPoint.X / size + scrolledPoint.Y / size * mapWidth));
                    TileMapEditor parent = this.MdiParent as TileMapEditor;
                    parent.tool.PaintTiles(ref map, mapWidth, tile, CurrentTile);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.GetType());
            }
        }

        private void MapEditor_Enter(object sender, EventArgs e)
        {
        }
             

        // On mouse down whjile on map. Painting is set to  true and ontilclick is called
        private void MapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Painting = true;
                OnTileClick(sender, e);
            }
        }

        // when the mouse over the mapo is released painting it set to false. 
        private void MapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Painting)
            {
                Painting = false;
            }
        }

        // While on the map panel and th emouse is moving if the painting is true it will continue to change the tile on hover.
        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Painting)
            {
                OnTileClick(sender, e);
            }
        }

        // Overriden ToString to allow for correct format when saving out to file.
        public override string ToString()
        {
            return "N," + mapWidth + "," + mapHeight + "," + Text + "," + size;
        }
    }
    
}