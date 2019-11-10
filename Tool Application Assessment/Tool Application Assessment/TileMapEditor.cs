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
        public NewMapForm newMapForm;
        public SpriteSheet Spritesheet { get; set; }

        public delegate void AddSpriteSheet(SpriteSheet sheet);
        public event AddSpriteSheet OnAddSpriteSheet;

        public delegate void FillPallette();
        public event FillPallette OnFillPallette;

        public delegate void RefreshMap();
        public event RefreshMap OnRefreshMap;


        public delegate void EditMapTile(int height, int width, int ID, int paletteID);
        public event EditMapTile OnEditMapTile;

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
            if (newMapForm != null)
            {
                foreach (Form form in this.MdiChildren)
                {
                    //MessageBox.Show(form.GetType().Name);
                    newMapForm = null;
                    form.Close();
                    form.Dispose();

                }

            }

            newMapForm = new NewMapForm();
            newMapForm.ShowDialog();

            mapWidth = newMapForm.width;
            mapHeight = newMapForm.height;
            size = newMapForm.size;

            //Create new window
            MapEditor newMapEditor = new MapEditor(this);

            newMapEditor.Text = newMapForm.name;

            // Set MDI Marent
            // newMapEditor.MdiParent = this;
            // show the window
            newMapEditor.Show();
            newMapEditor.NewMap(mapWidth, mapHeight, size);

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
            tileImport.MdiParent = this;

            tileImport.Show();
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            string file = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    string data;
                    FileStream fsSource = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fsSource))
                    {
                        //Create new window
                        MapEditor newMapEditor = new MapEditor(this);
                        
                        //data = sr.ReadToEnd();
                        int height = 0;
                        int width = 0;
                        int count = 0;
                        string name = "";
                        int size = 0;
                        while ((data = sr.ReadLine()) != null)
                        {
                            string[] strList = data.Split(',');
                            switch (strList[0])
                            {
                                case ("N"):
                                    Console.WriteLine("N:  " + data);
                                    width = int.Parse(strList[1]);
                                    height = int.Parse(strList[2]);
                                    name = strList[3]+ "";
                                    size = int.Parse(strList[4]);
                                    newMapEditor.NewMap(width, height, size);
                                    newMapEditor.Text = name;
                                    break;
                                case ("F"):
                                    Console.WriteLine("F:  " + data);
                                    Console.WriteLine("1: " + strList[6]);
                                    Console.WriteLine("2: " + strList[5]);
                                    SpriteSheet sheet = new SpriteSheet(strList[2]);
                                    sheet.UniqueID = int.Parse(strList[1]);
                                    sheet.GridHeight = int.Parse(strList[3]);
                                    sheet.GridWidth = int.Parse(strList[4]);
                                    sheet.TilesHigh = int.Parse(strList[5]);
                                    sheet.TilesWide = int.Parse(strList[6]);
                                    sheet.Spacing = int.Parse(strList[7]);
                                    newMapEditor.sheets.Add(sheet);
                                    FillCurrentPallette();
                                    break;
                                case ("T"):
                                    Console.WriteLine("T   " + data);
                                    break;
                                case ("s"):
                                    Console.WriteLine("S   " + data);
                                    break;
                                case ("M"):
                                    Console.WriteLine("M   " + data);
                                    int tileHeight = int.Parse(strList[1]);
                                    int tileWidth = int.Parse(strList[2]);
                                    int uniqueID = int.Parse(strList[3]);
                                    int palleteID = int.Parse(strList[4]);

                                    if (OnEditMapTile != null)
                                    {
                                        OnEditMapTile(tileHeight, tileWidth, uniqueID, palleteID);
                                    }

                                    break;
                                default:
                                    break;
                            }
                        }
                        // Set MDI Marent
                        // newMapEditor.MdiParent = this;
                        // show the window
                        newMapEditor.Show();

                        this.welcomePanel.Visible = false;
                        this.saveMapToolStripMenuItem.Enabled = true;
                        this.importTilesToolStripMenuItem.Enabled = true;
                        this.modifySelectedTileToolStripMenuItem.Enabled = true;
                    }
                    Console.WriteLine(data);
                    Console.ReadLine();
                    fsSource.Close();
                }
            }

        }

        public void AddSheet(SpriteSheet sheet)
        {

            if (OnAddSpriteSheet != null)
            {
                OnAddSpriteSheet(sheet);
            }
        }


        public void FillCurrentPallette()
        {
            if (OnFillPallette != null)
            {
                OnFillPallette();
            }
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


                    byte[] ndata = Encoding.Default.GetBytes(map.ToString());
                    fs.Write(ndata, 0, ndata.Length);
                    fs.Write(newline, 0, newline.Length);

                    // Save out Spritesheet details
                    for (int i = 0; i < map.sheets.Count; i++)
                    {
                        byte[] bdata = Encoding.Default.GetBytes(map.sheets[i].ToString());
                        fs.Write(bdata, 0, bdata.Length);
                        fs.Write(newline, 0, newline.Length);
                    }

                    //save out current Palette
                    for (int i = 0; i < map.paletteTiles.Count; i++)
                    {
                        byte[] bdata = Encoding.Default.GetBytes(map.paletteTiles[i].ToString());
                        fs.Write(bdata, 0, bdata.Length);
                        fs.Write(newline, 0, newline.Length);
                    }

                    // Save out current Map
                    for (int i = 0; i < map.map.Length; i++)
                    {
                        byte[] bdata = Encoding.Default.GetBytes(map.map[i].ToString());
                        fs.Write(bdata, 0, bdata.Length);
                        fs.Write(newline, 0, newline.Length);
                    }

                    fs.Close();
                    Console.WriteLine("Successfully saved file!");
                }

            }
        }
    }
}
