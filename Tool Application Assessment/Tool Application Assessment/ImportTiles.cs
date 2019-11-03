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
    public partial class ImportTiles : Form
    {
        public Spritesheet Spritesheet { get; private set; }
        public Bitmap drawArea;
        public PictureBox pictureBox;

        public Point CurrentTile { get; private set; } = new Point();

        public bool TilesLoaded { get; private set; } = false;

        public string Filename
        {
            get { return (Spritesheet != null) ? Spritesheet.Filename : string.Empty; }
        }

        public ImportTiles()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(0, 0);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == true)
                {
                    Spritesheet = new Spritesheet(openFileDialog.FileName);
                    Bitmap image = new Bitmap(openFileDialog.FileName);
                    pictureBox.Image = image;
                    pictureBox.Size = new Size(image.Width, image.Height);
                    drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
                    spritePanel.Controls.Add(pictureBox);
                    DrawGrid();
                    TilesLoaded = true;
                }
            }
        }
        private void DrawGrid()
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

            if (TilesLoaded)
            {
                int width;
                if (int.TryParse(textBoxWidth.Text, out width) == true)
                {
                    Spritesheet.GridWidth = width;
                    DrawGrid();
                }

                textBoxWidth.Text = Spritesheet.GridWidth.ToString();
            }
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            if (TilesLoaded)
            {
                int height;
                if (int.TryParse(textBoxHeight.Text, out height) == true)
                {
                    Spritesheet.GridHeight = height;
                    DrawGrid();
                }

                textBoxHeight.Text = Spritesheet.GridHeight.ToString();
            }
        }

        private void textBoxSpacing_TextChanged(object sender, EventArgs e)
        {
            if (TilesLoaded)
            {
                int spacing;
                if (int.TryParse(textBoxSpacing.Text, out spacing) == true)
                {
                    Spritesheet.Spacing = spacing;
                    DrawGrid();
                }

                textBoxSpacing.Text = Spritesheet.Spacing.ToString();
            }
        }

        private void SpriteSheetForm_Shown(object sender, EventArgs e)
        {
            DrawGrid();
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
                DrawGrid();
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
            if (TilesLoaded)
            {
                int wide;
                if (int.TryParse(textBoxWide.Text, out wide) == true)
                {
                    Console.WriteLine(wide);
                    Spritesheet.TilesWide = wide;
                }
            }
        }

        private void textBoxHigh_TextChanged(object sender, EventArgs e)
        {
            if (TilesLoaded)
            {
                if (TilesLoaded)
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

        private void spritePanel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Console.WriteLine("Drag Drop");
                //target control will accept data here 
                Panel destination = (Panel)sender;
                String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
                Bitmap bitmap = (Bitmap)e.Data.GetData(typeof(Bitmap));
                Console.WriteLine(imagePaths);
                Console.WriteLine(imagePaths[0]);
                Spritesheet = new Spritesheet(imagePaths[0]);
                Bitmap image = new Bitmap(imagePaths[0]);
                pictureBox.Image = image;
                pictureBox.Size = new Size(image.Width, image.Height);
                drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
                spritePanel.Controls.Add(pictureBox);
                DrawGrid();
                TilesLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Load File, File Must be a image.");
            }
        }

        private void spritePanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
