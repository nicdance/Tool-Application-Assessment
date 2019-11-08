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


        public PictureBox CurrentTile { get; private set; }
        public bool Painting { get; private set; } = false;

        public MapEditor(TileMapEditor parentForm)
        {
            this.MdiParent = parentForm;
            InitializeComponent();
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;

            //TileMapEditor parent = this.MdiParent as TileMapEditor;
            parentForm.OnAddSpriteSheet += AddNewSheet;
            parentForm.OnFillPallette += PopulatePalette;

        }

        public void AddNewSheet(SpriteSheet sheet) {
            sheet.UniqueID = sheets.Count;
            sheets.Add(sheet);
            PopulatePalette();
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
            MessageBox.Show(" No of Sheets: " + sheets.Count);
            for (int ii = 0; ii < sheets.Count; ii++) {
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
            // this.DoDragDrop(box.Image, DragDropEffects.All);
        }

        private void TileBlockClicked(object sender, EventArgs e)
        {
            if (CurrentTile != null)
            {
                CurrentTile.BorderStyle = BorderStyle.None;

            }
            if (e.GetType() == typeof(MouseEventArgs))
            {
                PictureBox box = sender as PictureBox;
                CurrentTile = box;
                CurrentTile.BorderStyle = BorderStyle.Fixed3D;
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
                    map[tile].Picture.Image = null;
                    map[tile].Picture.Image = CurrentTile.Image;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //MessageBox.Show("");
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
    }

}