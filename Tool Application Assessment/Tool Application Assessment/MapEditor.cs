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
       // Bitmap drawArea = null;
        //PictureBox[,] box;
        MapTile[] map;
        List<PictureBox> tiles = new List<PictureBox>();
        int mapWidth = 0;
        int mapHeight = 0;

        public MapEditor()
        {
            InitializeComponent();
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;
        }

        public void NewMap(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            MapPanel.Padding = new Padding(0);
            Bitmap image = new Bitmap("img\\BlackSquare.png");
            map = new MapTile[width * height];
            for (int i = 0; i < width*height; i++)
            {
                int xPos = 0;
                int yPos = 0;
                MapTile tile = new MapTile();
                tile.Width = width;
                tile.Height = height;
                tile.UniqueID = i;
                tile.Picture = new PictureBox();
                tile.Picture.Size = new Size(size, size);
                tile.Picture.SizeMode = PictureBoxSizeMode.Zoom;
                tile.Picture.Image = image;
                tile.Picture.Location = new System.Drawing.Point((i%width)*size, ((int)i/height)*size);
                map[i] = tile;
                MapPanel.Controls.Add(tile.Picture);
                tile.Picture.Enabled = false;
            }

            MapPanel.MouseDown += new MouseEventHandler(OnTileClick);
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;
        }

        void OnTileClick(object sender, MouseEventArgs e)
        {
            Point scrolledPoint = new Point(e.X - MapPanel.AutoScrollPosition.X,
                                       e.Y- MapPanel.AutoScrollPosition.Y);
            Console.WriteLine(scrolledPoint.ToString());
            int tile = ((int)(scrolledPoint.X / size + scrolledPoint.Y / size*mapWidth));
            Console.WriteLine(tile);
            Console.WriteLine("Tile ID: " + map[tile].UniqueID);
            Bitmap image = new Bitmap("img\\green.png");
            map[tile].Picture.Image = null;
            map[tile].Picture.Image = image;

        }

        private void MapEditor_Enter(object sender, EventArgs e)
        {
            TileMapEditor parent = this.MdiParent as TileMapEditor;
            if (parent.Spritesheet != null)
            {
                Console.WriteLine(parent.Spritesheet.TilesHigh+ ":"+ parent.Spritesheet.TilesWide);
                for (int i = 0; i < parent.Spritesheet.TilesHigh* parent.Spritesheet.TilesWide; i++)
                {
                    PictureBox box = new PictureBox();
                    Bitmap drawArea = new Bitmap(size, size);
                    box.Size = new Size(size, size);
                    box.SizeMode = PictureBoxSizeMode.Zoom;
                    box.Image = drawArea;
                    tiles.Add(box);

                    Graphics g = Graphics.FromImage(drawArea);
                    g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);

                    Rectangle dest = new Rectangle(0, 0, size, size);

                    Rectangle source = new Rectangle(
                                    (i % parent.Spritesheet.TilesWide) * (parent.Spritesheet.GridWidth + parent.Spritesheet.Spacing),
                                    ((int)i / parent.Spritesheet.TilesWide) * (parent.Spritesheet.GridHeight + parent.Spritesheet.Spacing),
                                    parent.Spritesheet.GridWidth,
                                    parent.Spritesheet.GridHeight);
                    g.DrawImage(parent.Spritesheet.Image, dest, source, GraphicsUnit.Pixel);

                    box.Image = drawArea;
                    g.Dispose();

                    tileFlowPanel.Controls.Add(box);

                }
                /*
                 * 
                 * 
                                    0 * (parent.Spritesheet.GridWidth + parent.Spritesheet.Spacing),
                                    0 * (parent.Spritesheet.GridHeight + parent.Spritesheet.Spacing),


                PictureBox box = new PictureBox();
                Bitmap drawArea = new Bitmap(size,size);
                box.Size = new Size(size, size);
                box.SizeMode = PictureBoxSizeMode.Zoom;
                box.Image = drawArea;
                Graphics g = Graphics.FromImage(drawArea);
                g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);
                
                Rectangle dest = new Rectangle(0, 0,size,size);

                Rectangle source = new Rectangle(
                                0 * (parent.Spritesheet.GridWidth + parent.Spritesheet.Spacing),
                                0 * (parent.Spritesheet.GridHeight + parent.Spritesheet.Spacing),
                                parent.Spritesheet.GridWidth,
                                parent.Spritesheet.GridHeight);
                //source.Size = new Size(size,size);
                g.DrawImage(parent.Spritesheet.Image, dest, source, GraphicsUnit.Pixel);

                box.Image = drawArea;
                g.Dispose();

                tileFlowPanel.Controls.Add(box);
                */
            }
        }
        }




    /*
    Gets coords of current tile
    CurrentTile = new Point(mouse.X / (Spritesheet.GridWidth + Spritesheet.Spacing), 
                mouse.Y / (Spritesheet.GridHeight + Spritesheet.Spacing));


            Rectangle source = new Rectangle(
            layer.TileCoordinates.X * (spritesheet.GridWidth + spritesheet.Spacing),
            layer.TileCoordinates.Y * (spritesheet.GridHeight + spritesheet.Spacing),
            spritesheet.GridWidth,
                    spritesheet.GridHeight);

*/




}
