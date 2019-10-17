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
    public partial class TileMapEditor : Form
    {
        public TileMapEditor()
        {
            InitializeComponent();
        }

        private void OnMenuHover(object sender, EventArgs e)
        {

        }


        private void OnMenuExit(object sender, EventArgs e)
        {

        }

        private void LoadMap_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void CreateNewMap_Click(object sender, EventArgs e)
        {
            int mapWidth = 15;
            int mapHeight = 15;


            //Create new window
            MapEditor newMapEditor = new MapEditor();

            // Set MDI Marent
            newMapEditor.MdiParent = this;

            // show the window
            newMapEditor.Show();
            newMapEditor.NewMap(mapWidth, mapHeight);

            this.welcomePanel.Visible = false;
            this.saveMapToolStripMenuItem.Enabled = true;
            this.importTilesToolStripMenuItem.Enabled = true;
            this.modifySelectedTileToolStripMenuItem.Enabled = true;
        }

        private void GettingStarted_Click(object sender, EventArgs e)
        {

        }
    }
}
