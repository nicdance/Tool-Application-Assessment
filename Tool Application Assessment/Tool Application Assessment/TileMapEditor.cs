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
        public IMapTools tool { get; set; } = new SmallTool();

        public delegate void AddSpriteSheet(SpriteSheet sheet);
        public event AddSpriteSheet OnAddSpriteSheet;

        public delegate void FillPallette();
        public event FillPallette OnFillPallette;

        public delegate void RefreshMap();
        public event RefreshMap OnRefreshMap;

        public delegate void DrawOnMap( int width, int startPosition);
        public event DrawOnMap OnDrawOnMap;


        public delegate void EditMapTile(int height, int width, int ID, int paletteID);
        public event EditMapTile OnEditMapTile;

        public TileMapEditor()
        {
            InitializeComponent();
            Spritesheet = null;
           // OnDrawOnMap += DrawOnTiles();
        }
        // MapTile[] tileMap, int width, int startPosition, PaletteTile currentTile

        public void DrawOnTiles(int width, int startPosition) {

        }
        private void OnMenuHover(object sender, EventArgs e)
        {

        }


        private void OnMenuExit(object sender, EventArgs e)
        {

        }

        private void LoadMap_MouseClick(object sender, MouseEventArgs e)
        {
            LoadExistingMap();
        }

        public void CheckSaveExisiting() {
            //if (newMapForm != null)
            {
                foreach (Form form in this.MdiChildren)
                {
                    Console.WriteLine(form.GetType().Name);
                    if (form.GetType().Name == "MapEditor")
                    {
                        DialogResult result = MessageBox.Show("Would you like to Save your your current Map?",
                  "Save", MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                SaveCurrentMap();
                                break;
                            case DialogResult.No:
                                break;
                        };
                        newMapForm = null;
                        MapEditor mapEditor = form as MapEditor;
                        mapEditor.ClearListeners();
                    }
                    form.Close();
                    form.Dispose();

                }    
            }
        }

        private void CreateNewMap_Click(object sender, EventArgs e)
        {
            int mapWidth = 20;
            int mapHeight = 20;
            int size = 0;

            CheckSaveExisiting();

            newMapForm = new NewMapForm();
            newMapForm.ShowDialog();

            mapWidth = newMapForm.width;
            mapHeight = newMapForm.height;
            size = newMapForm.size;

            //Create new window
            MapEditor newMapEditor = new MapEditor(this);

            newMapEditor.Text = newMapForm.name;
            newMapEditor.Show();
            newMapEditor.NewMap(mapWidth, mapHeight, size);

            this.welcomePanel.Visible = false;
            this.saveMapToolStripMenuItem.Enabled = true;
            this.importTilesToolStripMenuItem.Enabled = true;
            this.importSingleTileToolStripMenuItem.Enabled = true;
            this.modifySelectedTileToolStripMenuItem.Enabled = true;
        }

        private void GettingStarted_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://chaosshard.com.au/TileMapEditorAssessment/");
        }

        private void importTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportTiles tileImport = new ImportTiles();

            // Set MDI parent
            tileImport.MdiParent = this;

            tileImport.Show();
        }

        public void LoadExistingMap()
        {
            CheckSaveExisiting();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        string data;
                        FileStream fsSource = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                        using (StreamReader sr = new StreamReader(fsSource))
                        {
                            //Create new window
                            MapEditor newMapEditor = new MapEditor(this);

                            int height = 0;
                            int width = 0;
                            string name = "";
                            int size = 0;
                            while ((data = sr.ReadLine()) != null)
                            {
                                string[] strList = data.Split(',');
                                switch (strList[0])
                                {
                                    case ("N"):
                                        width = int.Parse(strList[1]);
                                        height = int.Parse(strList[2]);
                                        name = strList[3] + "";
                                        size = int.Parse(strList[4]);
                                        newMapEditor.NewMap(width, height, size);
                                        newMapEditor.Text = name;
                                        break;
                                    case ("F"):
                                        string fileTileMap = strList[2];
                                        if (!File.Exists(fileTileMap)) {
                                            DialogResult result = MessageBox.Show("Unable to find file " + fileTileMap + ".  Would you like to find it?",
                                             "Find File", MessageBoxButtons.YesNo);
                                            switch (result)
                                            {
                                                case DialogResult.Yes:
                                                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                                                    {
                                                        if (openFileDialog.FileName != "")
                                                        {
                                                            fileTileMap = openFileDialog.FileName;
                                                            break;
                                                        }
                                                    }
                                                    MessageBox.Show("Unable to locate file. Map unable to be loaded.");
                                                    break;
                                                case DialogResult.No:
                                                    break;
                                            };
                                        }
                                        SpriteSheet sheet = new SpriteSheet(fileTileMap);
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
                                        break;
                                    case ("s"):
                                        break;
                                    case ("M"):
                                        int tileHeight = int.Parse(strList[1]);
                                        int tileWidth = int.Parse(strList[2]);
                                        int uniqueID = int.Parse(strList[3]);
                                        int palleteID = int.Parse(strList[4]);

                                        if (OnEditMapTile != null)
                                        {
                                            Console.WriteLine("OnEditMapTile");
                                            OnEditMapTile(tileHeight, tileWidth, uniqueID, palleteID);
                                        }

                                        break;
                                    default:
                                        break;
                                }
                            }
                            newMapEditor.Show();

                            this.welcomePanel.Visible = false;
                            this.saveMapToolStripMenuItem.Enabled = true;
                            this.importTilesToolStripMenuItem.Enabled = true;
                            this.importSingleTileToolStripMenuItem.Enabled = true;
                            this.modifySelectedTileToolStripMenuItem.Enabled = true;
                            sr.Close();
                            fsSource.Close();
                        }
                    }
                    catch (Exception)
                    {
                        DialogResult result = MessageBox.Show("Unable to load file. Would you like to try again?",
                        "Save", MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                LoadExistingMap();
                                break;
                            case DialogResult.No:
                                if (newMapForm != null)
                                {
                                    foreach (Form form in this.MdiChildren)
                                    {
                                        newMapForm = null;
                                        form.Close();
                                        form.Dispose();
                                    }
                                }
                                break;
                        };
                    }
                    
                }
            }

        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            LoadExistingMap();
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

        public void SaveCurrentMap() {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string file = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        FileStream fs = (FileStream)saveFileDialog.OpenFile();

                        Form[] forms = this.MdiChildren;
                        byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                       // Console.WriteLine(forms.Length + " child forms.");
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
                    catch (Exception)
                    {
                        DialogResult result = MessageBox.Show("Unable to save file. Would you like to try again?",
                       "Save", MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                SaveCurrentMap();
                                break;
                            case DialogResult.No:
                                break;
                        };
                    }
                }

            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentMap();
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = null;
            tool = new FloodTool();
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = null;
            tool = new SmallTool();

        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = null;
            tool = new MediumTool();

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importSingleTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists == true)
                    {
                        SpriteSheet sheet = new SpriteSheet(openFileDialog.FileName);
                        sheet.GridHeight = sheet.Image.Size.Height;
                        sheet.GridWidth = sheet.Image.Size.Width;
                        AddSheet(sheet);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to import file.");
            }
        }
    }
}
