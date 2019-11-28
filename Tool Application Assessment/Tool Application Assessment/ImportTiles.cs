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
        public SpriteSheet Spritesheet { get; private set; }            // The sprite sheet been impoted
        public Bitmap drawArea;                                         // USed to determine area to draw grid onto tilemap
        public PictureBox pictureBox;                                   // Picturebox that the imported image is added while determining sizes.


        public bool TilesLoaded { get; private set; } = false;          // Cehck if  a file has been loaded before importina.

        public string Filename                                          // File name of the Spritesheee been imported.
        {
            get { return (Spritesheet != null) ? Spritesheet.Filename : string.Empty; }
        }

        public ImportTiles()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(0, 0);
        }

        // Allows the user to choose the tilemap to import.
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.CheckFileExists == true)
                {
                    Spritesheet = new SpriteSheet(openFileDialog.FileName);
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

        // Draws a grid on the map to visual show how the tiles will be cut up.
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
            g.Dispose();

            pictureBox.Image = drawArea;
        }

        // Called when the width text is changed. the Grid on the map is redrawn
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


        // Called when the height text is changed. the Grid on the map is redrawn
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


        // Called when the spacing text is changed. the Grid on the map is redrawn
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

        //
        private void SpriteSheetForm_Shown(object sender, EventArgs e)
        {
            DrawGrid();
        }

        // Imports the current spritesheet and its settings into the active map.
        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (Spritesheet == null)
                return;
            TileMapEditor parent = this.MdiParent as TileMapEditor;
            parent.AddSheet(Spritesheet);
            this.Close();
        }


        // Called when the box wide  text is changed. The spritesheet details are updated acordingly.
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

        // Called when the box high  text is changed. The spritesheet details are updated acordingly.
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

        // Called when a file si dragged into the map space.
        // If file is an image it will be added
        // if file is not an image an error msg will display.
        private void spritePanel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                //target control will accept data here 
                Panel destination = (Panel)sender;
                String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
                Bitmap bitmap = (Bitmap)e.Data.GetData(typeof(Bitmap));
                Spritesheet = new SpriteSheet(imagePaths[0]);
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
