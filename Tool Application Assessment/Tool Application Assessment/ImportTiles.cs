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
    public partial class ImportTiles : Form
    {
        public Spritesheet Spritesheet { get; private set; }
        public Bitmap drawArea;
        public PictureBox pictureBox;

        public Point CurrentTile { get; private set; } = new Point();

        public string Filename
        {
            get { return (Spritesheet != null) ? Spritesheet.Filename : string.Empty; }
        }

        public ImportTiles()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(0, 0);
            pictureBox.MouseDown += new MouseEventHandler(PictureBoxClicked);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    Spritesheet = new Spritesheet(dlg.FileName);
                    Bitmap image = new Bitmap(dlg.FileName);
                    pictureBox.Image = image;
                    pictureBox.Size = new Size(image.Width, image.Height);
                    drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
                    spritePanel.Controls.Add(pictureBox);
                    drawGrid();
                }
            }
        }
        private void drawGrid()
        {
            pictureBox.DrawToBitmap(drawArea, pictureBox.Bounds);

            Graphics g;
            g = Graphics.FromImage(drawArea);

            g.Clear(Color.White);

            if (Spritesheet == null)
                return;


            g.DrawImage(Spritesheet.Image, 0, 0);

            Pen pen = new Pen(Brushes.Black);

            int height = pictureBox.Height;
            int width = pictureBox.Width;
            for (int y = 0; y < height; y += Spritesheet.GridHeight + Spritesheet.Spacing)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x < width; x += Spritesheet.GridWidth + Spritesheet.Spacing)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight, CurrentTile.X * (Spritesheet.GridWidth + Spritesheet.Spacing),
                CurrentTile.Y * (Spritesheet.GridHeight + Spritesheet.Spacing),
                Spritesheet.GridWidth + Spritesheet.Spacing, Spritesheet.GridHeight + Spritesheet.Spacing);

            g.Dispose();

            pictureBox.Image = drawArea;
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            int width;
            if (int.TryParse(textBoxWidth.Text, out width) == true)
            {
                Spritesheet.GridWidth = width;
                drawGrid();
            }

            textBoxWidth.Text = Spritesheet.GridWidth.ToString();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            int height;
            if (int.TryParse(textBoxHeight.Text, out height) == true)
            {
                Spritesheet.GridHeight = height;
                drawGrid();
            }

            textBoxHeight.Text = Spritesheet.GridHeight.ToString();
        }

        private void textBoxSpacing_TextChanged(object sender, EventArgs e)
        {
            int spacing;
            if (int.TryParse(textBoxSpacing.Text, out spacing) == true)
            {
                Spritesheet.Spacing = spacing;
                drawGrid();
            }

            textBoxSpacing.Text = Spritesheet.Spacing.ToString();
        }

        private void SpriteSheetForm_Shown(object sender, EventArgs e)
        {
            drawGrid();
        }

        private void PictureBoxClicked(object sender, EventArgs e)
        {
            if (Spritesheet == null)
                return;

            // get tile coordinate of click
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;
                CurrentTile = new Point(mouse.X / (Spritesheet.GridWidth + Spritesheet.Spacing),
                    mouse.Y / (Spritesheet.GridHeight + Spritesheet.Spacing));
                drawGrid();
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (Spritesheet == null)
                return;
            TileMapEditor parent = this.MdiParent as TileMapEditor;
            parent.Spritesheet = Spritesheet;
            this.Close();
        }

        private void textBoxWide_TextChanged(object sender, EventArgs e)
        {
            int wide;
            if (int.TryParse(textBoxWide.Text, out wide) == true)
            {
                Console.WriteLine(wide);
                Spritesheet.TilesWide = wide;
            }
        }

        private void textBoxHigh_TextChanged(object sender, EventArgs e)
        {
            int high;
            if (int.TryParse(textBoxHigh.Text, out high) == true)
            {
                Console.WriteLine(high);
                Spritesheet.TilesHigh = high;
            }
        }
    }
}