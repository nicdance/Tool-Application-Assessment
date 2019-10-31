﻿using System;
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
        public bool Painting { get; private set; } = false;

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
            for (int i = 0; i < width * height; i++)
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
                tile.Picture.Location = new System.Drawing.Point((i % width) * size, ((int)i / height) * size);
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
            TileMapEditor parent = this.MdiParent as TileMapEditor;
            if (parent.Spritesheet != null)
            {
                Console.WriteLine(parent.Spritesheet.TilesHigh + ":" + parent.Spritesheet.TilesWide);
                for (int i = 0; i < parent.Spritesheet.TilesHigh * parent.Spritesheet.TilesWide; i++)
                {
                    PictureBox box = new PictureBox();
                    Bitmap drawArea = new Bitmap(size, size);
                    box.Size = new Size(size, size);
                    box.SizeMode = PictureBoxSizeMode.Zoom;
                    box.Image = drawArea;
                    box.Enabled = true;
                    box.MouseDown += new MouseEventHandler(TileMouseDown);

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
                }
            }
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