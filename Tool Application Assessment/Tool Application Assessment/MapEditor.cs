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


        public PictureBox CurrentTile { get; private set; }

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
            MapPanel.AllowDrop = true;
            MapPanel.MouseDown += new MouseEventHandler(OnTileClick);
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;
        }

        private void TileMouseDown(object sender, MouseEventArgs e)
        {
            PictureBox box = sender as PictureBox;
            //Console.WriteLine(box.Location);
            //Console.WriteLine(box.Image.ToString());
            //var control = sender as Control;
            // this.DoDragDrop(control.Name, DragDropEffects.Move);
             this.DoDragDrop(box.Image, DragDropEffects.All);

        }

        private void PanelDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }


        private void panelDragDrop(object sender, DragEventArgs e)
        {            
            //Console.WriteLine("sender is" +((Panel)sender).Name);
            //PictureBox box = (PictureBox)e.Data.GetData(typeof(PictureBox));
            //Bitmap bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            // Console.WriteLine("e is" + box.Name);
            //Control p = (Panel)sender;

            //Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            //if (c != null)
            //{
            //    c.Location = this.MapPanel.PointToClient(new Point(e.X, e.Y));
            //    this.MapPanel.Controls.Add(c);
            //}
            Point dragPoint = new Point(e.X,e.Y);
            Console.WriteLine(dragPoint.ToString());

            Point scrolledPoint = new Point(dragPoint.X - MapPanel.AutoScrollPosition.X,
                                       dragPoint.Y - MapPanel.AutoScrollPosition.Y);
            //int tile = ((int)(scrolledPoint.X / size + scrolledPoint.Y / size * mapWidth));
            int tile = ((int)(dragPoint.X / size + dragPoint.Y / size * mapWidth));
            Console.WriteLine("Tile: "+ tile);
            //Bitmap image = new Bitmap("img\\green.png");
            map[tile].Picture.Image = null;
            map[tile].Picture.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
        }
        private void TileBlockClicked(object sender, EventArgs e)
        {
            if (CurrentTile != null)
                CurrentTile.BorderStyle = BorderStyle.None;
            {

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
            Point scrolledPoint = new Point(e.X - MapPanel.AutoScrollPosition.X,
                                       e.Y- MapPanel.AutoScrollPosition.Y);
            Console.WriteLine(scrolledPoint.ToString());
            int tile = ((int)(scrolledPoint.X / size + scrolledPoint.Y / size*mapWidth));
            Console.WriteLine(tile);
            map[tile].Picture.Image = null;
            map[tile].Picture.Image = CurrentTile.Image;

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
                    box.Enabled = true;
                    box.MouseDown += new MouseEventHandler(TileMouseDown);
                   // tiles.Add(box);

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

                    box.MouseDown += new MouseEventHandler(TileBlockClicked);
                    g.Dispose();

                    tileFlowPanel.Controls.Add(box);
                    //MapPanel.DragDrop += new DragEventHandler(panelDragDrop);
                    //MapPanel.DragEnter += new DragEventHandler(PanelDragEnter);
                }
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
