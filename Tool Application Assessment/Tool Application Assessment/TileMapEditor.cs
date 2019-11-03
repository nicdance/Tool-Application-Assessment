using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            int size = 0;

            NewMapForm newMapForm = new NewMapForm();

            newMapForm.ShowDialog();

            mapWidth = newMapForm.width;
            mapHeight = newMapForm.height;
            size = newMapForm.size;

            //Create new window
            MapEditor newMapEditor = new MapEditor();

            newMapEditor.Text = newMapForm.name;

            // Set MDI Marent
            newMapEditor.MdiParent = this;

            // show the window
            newMapEditor.Show();
            newMapEditor.NewMap(mapWidth, mapHeight,size);

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

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string file = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    FileStream fs = (FileStream)saveFileDialog.OpenFile();

                    Form[] forms = this.MdiChildren;
                    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    Console.WriteLine(forms.Length + " child forms.");
                    MapEditor map = forms[0] as MapEditor;
                    for (int i = 0; i < map.paletteTiles.Count; i++)
                    {
                        if (file != map.paletteTiles[i].Picture.ImageLocation)
                        {
                            file = map.paletteTiles[i].Picture.ImageLocation;
                            string fn = "SS:" + file;
                            byte[] fileNameDate = Encoding.Default.GetBytes(fn);
                            fs.Write(fileNameDate, 0, fileNameDate.Length);
                            fs.Write(newline, 0, newline.Length);

                        }
                        byte[] bdata = Encoding.Default.GetBytes(map.paletteTiles[i].ToString());
                        fs.Write(bdata, 0, bdata.Length);
                        fs.Write(newline, 0, newline.Length);
                    }
                    fs.Close();
                    Console.WriteLine("Successfully saved file!");


                    string data;
                    FileStream fsSource = new FileStream(saveFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fsSource))
                    {
                        //data = sr.ReadToEnd();
                        int count = 0;
                        while ((data = sr.ReadLine()) !=null)
                        {
                            string[] strList = data.Split(':');
                            switch (strList[0])
                            {
                                case ("F"):
                                    Console.WriteLine("New File:  " + data);
                                    break;
                                case ("T"):
                                    Console.WriteLine("T   " + data);
                                    break;
                                case ("M"):
                                    Console.WriteLine("M   " + data);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    Console.WriteLine(data);
                    Console.ReadLine();


                }
            }

        }
    }
}
