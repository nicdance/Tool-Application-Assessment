namespace Tool_Application_Assessment
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySelectedTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeadingLavel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadMap = new System.Windows.Forms.Button();
            this.CreateNewMap = new System.Windows.Forms.Button();
            this.GettingStarted = new System.Windows.Forms.Button();
            this.MapEditPanel = new System.Windows.Forms.Panel();
            this.MapPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TilePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.MapEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.newMapToolStripMenuItem,
            this.importTilesToolStripMenuItem,
            this.modifySelectedTileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.newMapToolStripMenuItem.Text = "New Map";
            // 
            // importTilesToolStripMenuItem
            // 
            this.importTilesToolStripMenuItem.Name = "importTilesToolStripMenuItem";
            this.importTilesToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.importTilesToolStripMenuItem.Text = "Import Tiles";
            // 
            // modifySelectedTileToolStripMenuItem
            // 
            this.modifySelectedTileToolStripMenuItem.Name = "modifySelectedTileToolStripMenuItem";
            this.modifySelectedTileToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.modifySelectedTileToolStripMenuItem.Text = "Modify Selected Tile";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "Help ?";
            // 
            // HeadingLavel
            // 
            this.HeadingLavel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HeadingLavel.AutoSize = true;
            this.HeadingLavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingLavel.Location = new System.Drawing.Point(212, 99);
            this.HeadingLavel.Name = "HeadingLavel";
            this.HeadingLavel.Size = new System.Drawing.Size(399, 26);
            this.HeadingLavel.TabIndex = 2;
            this.HeadingLavel.Text = "Welcome to the Epic Tile Map Editor";
            this.HeadingLavel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Where would you like to start?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoadMap
            // 
            this.LoadMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.LoadMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoadMap.Location = new System.Drawing.Point(301, 213);
            this.LoadMap.Name = "LoadMap";
            this.LoadMap.Size = new System.Drawing.Size(202, 47);
            this.LoadMap.TabIndex = 4;
            this.LoadMap.Text = "Load Exisiting Map";
            this.LoadMap.UseVisualStyleBackColor = false;
            this.LoadMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoadMap_MouseClick);
            // 
            // CreateNewMap
            // 
            this.CreateNewMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.CreateNewMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateNewMap.Location = new System.Drawing.Point(301, 291);
            this.CreateNewMap.Name = "CreateNewMap";
            this.CreateNewMap.Size = new System.Drawing.Size(202, 47);
            this.CreateNewMap.TabIndex = 5;
            this.CreateNewMap.Text = "Create New Map";
            this.CreateNewMap.UseVisualStyleBackColor = false;
            this.CreateNewMap.Click += new System.EventHandler(this.CreateNewMap_Click);
            // 
            // GettingStarted
            // 
            this.GettingStarted.BackColor = System.Drawing.SystemColors.Highlight;
            this.GettingStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GettingStarted.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GettingStarted.Location = new System.Drawing.Point(301, 367);
            this.GettingStarted.Name = "GettingStarted";
            this.GettingStarted.Size = new System.Drawing.Size(202, 47);
            this.GettingStarted.TabIndex = 6;
            this.GettingStarted.Text = "Getting Started";
            this.GettingStarted.UseVisualStyleBackColor = false;
            this.GettingStarted.Click += new System.EventHandler(this.GettingStarted_Click);
            // 
            // MapEditPanel
            // 
            this.MapEditPanel.Controls.Add(this.label3);
            this.MapEditPanel.Controls.Add(this.label2);
            this.MapEditPanel.Controls.Add(this.TilePanel);
            this.MapEditPanel.Controls.Add(this.MapPanel);
            this.MapEditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapEditPanel.Location = new System.Drawing.Point(0, 24);
            this.MapEditPanel.Name = "MapEditPanel";
            this.MapEditPanel.Size = new System.Drawing.Size(784, 537);
            this.MapEditPanel.TabIndex = 7;
            this.MapEditPanel.Visible = false;
            // 
            // MapPanel
            // 
            this.MapPanel.AutoScroll = true;
            this.MapPanel.Location = new System.Drawing.Point(3, 61);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(571, 476);
            this.MapPanel.TabIndex = 0;
            // 
            // TilePanel
            // 
            this.TilePanel.AutoScroll = true;
            this.TilePanel.Location = new System.Drawing.Point(580, 61);
            this.TilePanel.Name = "TilePanel";
            this.TilePanel.Size = new System.Drawing.Size(201, 476);
            this.TilePanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(646, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tiles";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MapEditPanel);
            this.Controls.Add(this.GettingStarted);
            this.Controls.Add(this.CreateNewMap);
            this.Controls.Add(this.LoadMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeadingLavel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Start";
            this.Text = "Epic Tile Map Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MapEditPanel.ResumeLayout(false);
            this.MapEditPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySelectedTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label HeadingLavel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadMap;
        private System.Windows.Forms.Button CreateNewMap;
        private System.Windows.Forms.Button GettingStarted;
        private System.Windows.Forms.Panel MapEditPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel TilePanel;
        private System.Windows.Forms.FlowLayoutPanel MapPanel;
    }
}