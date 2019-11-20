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
        public int size = 64;
        public MapTile[] map;
        public List<PaletteTile> paletteTiles = new List<PaletteTile>();
        public List<PictureBox> tiles = new List<PictureBox>();
        public List<SpriteSheet> sheets = new List<SpriteSheet>();
        int mapWidth = 0;
        int mapHeight = 0;


        public PaletteTile CurrentTile { get; private set; }
        public bool Painting { get; private set; } = false;

        public MapEditor(TileMapEditor parentForm)
        {
            this.MdiParent = parentForm;
            InitializeComponent();
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;

            // assign to event listeners
            parentForm.OnAddSpriteSheet += AddNewSheet;
            parentForm.OnFillPallette += PopulatePalette;
            parentForm.OnRefreshMap += RefreshMap;
            parentForm.OnEditMapTile += EditMapTile;
           

        }
        // Destructor
        public void ClearListeners()
        {
            Console.WriteLine("ClearListeners.");
            TileMapEditor parentForm = this.MdiParent as TileMapEditor;
            // assign to event listeners
            parentForm.OnAddSpriteSheet -= AddNewSheet;
            parentForm.OnFillPallette -= PopulatePalette;
            parentForm.OnRefreshMap -= RefreshMap;
            parentForm.OnEditMapTile -= EditMapTile;
        }

        public void AddNewSheet(SpriteSheet sheet) {
             sheet.UniqueID = sheets.Count;
             sheets.Add(sheet);
             PopulatePalette();
         }
         public void EditMapTile(int height, int width, int ID, int paletteID)
         {
            Console.WriteLine("EditMapTile");
            Console.WriteLine(map.Length  +":" + ID);
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
                 //Console.WriteLine(" No of elements: " + sheets[ii].TilesHigh * sheets[ii].TilesWide);
                 //Console.WriteLine(sheets[ii].TilesWide);
                 //Console.WriteLine(sheets[ii].TilesHigh);

                 for (int i = 0; i < sheets[ii].TilesHigh * sheets[ii].TilesWide; i++)
                 {
                     //Console.WriteLine(i);
                     PaletteTile palette = new PaletteTile();
                     palette.UniqueID = paletteTiles.Count;
                     palette.SpriteSheetID = sheets[ii].UniqueID;

                     PictureBox box = new PictureBox();
                     Bitmap drawArea = new Bitmap(size, size);
                     box.Size = new Size(size, size);
                     box.SizeMode = PictureBoxSizeMode.Zoom;
                     box.Image = drawArea;
                     box.Enabled = true;
                     box.MouseDown += new MouseEventHandler(TileMouseDown);
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

         public void NewMap(int width, int height, int mapSize)
         {
             mapWidth = width;
             mapHeight = height;
             size = mapSize;
             MapPanel.Padding = new Padding(0);
             Bitmap image = new Bitmap("img\\BlackSquare.png");
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
                 tile.Picture.Image = image;
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
             

        private void MapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Painting = true;
                OnTileClick(sender, e);
            }
        }

        private void MapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Painting)
            {
                Painting = false;
            }
        }

        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Painting)
            {
                OnTileClick(sender, e);
            }
        }
        public override string ToString()
        {
            return "N," + mapWidth + "," + mapHeight + "," + Text + "," + size;
        }
    }
    
}