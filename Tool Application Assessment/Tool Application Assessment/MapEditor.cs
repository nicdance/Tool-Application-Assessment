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
        Bitmap drawArea = null;
        PictureBox[,] box;

        public MapEditor()
        {
            InitializeComponent();
            MapPanel.HorizontalScroll.Enabled = true;
            MapPanel.VerticalScroll.Enabled = true;
        }

        public void NewMap(int width, int height) {
            box = new PictureBox[width,height];
            MapPanel.Padding = new Padding(0);
            Bitmap image = new Bitmap("C:\\AIE\\Tool Application Assessment\\Tool Application Assessment\\Tool Application Assessment\\BlackSquare.png");
            //image.s
            for (int y = 0; y < height; y++)
            {
                box = new PictureBox[width,height];
                for (int x = 0; x < width; x++)
                {
                    box[x, y] = new PictureBox();
                    box[x, y].Size = new Size(50,50);
                    box[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    box[x, y].Image = image;
                    int xPos = 0;
                    int yPos = 0;
                    box[x, y].Location = new System.Drawing.Point(xPos+(x*50), yPos + (y * 50));
                    //box[x, y].Parent = MapPanel;
                    MapPanel.Controls.Add(box[x, y]);

                    //MapFlowLayoutPanel.Controls.Add(box[x, y]);
                    //TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(x,y);
                    //mapTableLayoutPanel.SetCellPosition(box[x,y], pos);
                    //mapTableLayoutPanel.SetCellPosition(box[x,y], pos);
                }
                //MapPanel.Controls.Add(new LiteralControl("<br>"));
                //MapFlowLayoutPanel.SetFlowBreak(box[width-1, y], true);
            }
        }
    }
}
