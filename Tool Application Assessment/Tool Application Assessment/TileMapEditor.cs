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

        public Spritesheet Spritesheet { get; set; }

        public TileMapEditor()
        {
            InitializeComponent();
            Spritesheet = null;
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
            int mapWidth = 20;
            int mapHeight = 20;

            NewMapForm newMapForm = new NewMapForm();

            newMapForm.ShowDialog();

            mapWidth = newMapForm.width;
            mapHeight = newMapForm.height;

            //Create new window
            MapEditor newMapEditor = new MapEditor();

            newMapEditor.Text = newMapForm.name;

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

        private void importTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportTiles tileImport = new ImportTiles();

            // Set MDI Marent
            tileImport.MdiParent= this;

            tileImport.Show();
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {

        }
    }
}
