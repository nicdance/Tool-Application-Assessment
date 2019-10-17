namespace Tool_Application_Assessment
{
    partial class TileMapEditor
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySelectedTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.GettingStarted = new System.Windows.Forms.Button();
            this.CreateNewMap = new System.Windows.Forms.Button();
            this.LoadMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HeadingLavel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapToolStripMenuItem,
            this.newMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.importTilesToolStripMenuItem,
            this.modifySelectedTileToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            this.newMapToolStripMenuItem.ToolTipText = "Create new Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.CreateNewMap_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Enabled = false;
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            // 
            // importTilesToolStripMenuItem
            // 
            this.importTilesToolStripMenuItem.Enabled = false;
            this.importTilesToolStripMenuItem.Name = "importTilesToolStripMenuItem";
            this.importTilesToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.importTilesToolStripMenuItem.Text = "Import Tiles";
            // 
            // modifySelectedTileToolStripMenuItem
            // 
            this.modifySelectedTileToolStripMenuItem.Enabled = false;
            this.modifySelectedTileToolStripMenuItem.Name = "modifySelectedTileToolStripMenuItem";
            this.modifySelectedTileToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.modifySelectedTileToolStripMenuItem.Text = "Modify Selected Tile";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "Help ?";
            // 
            // welcomePanel
            // 
            this.welcomePanel.Controls.Add(this.GettingStarted);
            this.welcomePanel.Controls.Add(this.CreateNewMap);
            this.welcomePanel.Controls.Add(this.LoadMap);
            this.welcomePanel.Controls.Add(this.label1);
            this.welcomePanel.Controls.Add(this.HeadingLavel);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(0, 24);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(784, 537);
            this.welcomePanel.TabIndex = 9;
            // 
            // GettingStarted
            // 
            this.GettingStarted.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GettingStarted.BackColor = System.Drawing.SystemColors.Highlight;
            this.GettingStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GettingStarted.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GettingStarted.Location = new System.Drawing.Point(282, 379);
            this.GettingStarted.Name = "GettingStarted";
            this.GettingStarted.Size = new System.Drawing.Size(202, 47);
            this.GettingStarted.TabIndex = 11;
            this.GettingStarted.Text = "Getting Started";
            this.GettingStarted.UseVisualStyleBackColor = false;
            // 
            // CreateNewMap
            // 
            this.CreateNewMap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CreateNewMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.CreateNewMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateNewMap.Location = new System.Drawing.Point(282, 303);
            this.CreateNewMap.Name = "CreateNewMap";
            this.CreateNewMap.Size = new System.Drawing.Size(202, 47);
            this.CreateNewMap.TabIndex = 10;
            this.CreateNewMap.Text = "Create New Map";
            this.CreateNewMap.UseVisualStyleBackColor = false;
            this.CreateNewMap.Click += new System.EventHandler(this.CreateNewMap_Click);
            // 
            // LoadMap
            // 
            this.LoadMap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoadMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.LoadMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoadMap.Location = new System.Drawing.Point(282, 225);
            this.LoadMap.Name = "LoadMap";
            this.LoadMap.Size = new System.Drawing.Size(202, 47);
            this.LoadMap.TabIndex = 9;
            this.LoadMap.Text = "Load Exisiting Map";
            this.LoadMap.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Where would you like to start?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HeadingLavel
            // 
            this.HeadingLavel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HeadingLavel.AutoSize = true;
            this.HeadingLavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingLavel.Location = new System.Drawing.Point(193, 111);
            this.HeadingLavel.Name = "HeadingLavel";
            this.HeadingLavel.Size = new System.Drawing.Size(399, 26);
            this.HeadingLavel.TabIndex = 7;
            this.HeadingLavel.Text = "Welcome to the Epic Tile Map Editor";
            this.HeadingLavel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TileMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TileMapEditor";
            this.Text = "Epic Tile Map Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Button GettingStarted;
        private System.Windows.Forms.Button CreateNewMap;
        private System.Windows.Forms.Button LoadMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HeadingLavel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}