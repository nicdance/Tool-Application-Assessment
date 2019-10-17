namespace Tool_Application_Assessment
{
    partial class StartScreen
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
            this.GettingStarted = new System.Windows.Forms.Button();
            this.CreateNewMap = new System.Windows.Forms.Button();
            this.LoadMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HeadingLavel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GettingStarted
            // 
            this.GettingStarted.BackColor = System.Drawing.SystemColors.Highlight;
            this.GettingStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GettingStarted.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GettingStarted.Location = new System.Drawing.Point(282, 391);
            this.GettingStarted.Name = "GettingStarted";
            this.GettingStarted.Size = new System.Drawing.Size(202, 47);
            this.GettingStarted.TabIndex = 11;
            this.GettingStarted.Text = "Getting Started";
            this.GettingStarted.UseVisualStyleBackColor = false;
            // 
            // CreateNewMap
            // 
            this.CreateNewMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.CreateNewMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateNewMap.Location = new System.Drawing.Point(282, 315);
            this.CreateNewMap.Name = "CreateNewMap";
            this.CreateNewMap.Size = new System.Drawing.Size(202, 47);
            this.CreateNewMap.TabIndex = 10;
            this.CreateNewMap.Text = "Create New Map";
            this.CreateNewMap.UseVisualStyleBackColor = false;
            // 
            // LoadMap
            // 
            this.LoadMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.LoadMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadMap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoadMap.Location = new System.Drawing.Point(282, 237);
            this.LoadMap.Name = "LoadMap";
            this.LoadMap.Size = new System.Drawing.Size(202, 47);
            this.LoadMap.TabIndex = 9;
            this.LoadMap.Text = "Load Exisiting Map";
            this.LoadMap.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 185);
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
            this.HeadingLavel.Location = new System.Drawing.Point(193, 123);
            this.HeadingLavel.Name = "HeadingLavel";
            this.HeadingLavel.Size = new System.Drawing.Size(399, 26);
            this.HeadingLavel.TabIndex = 7;
            this.HeadingLavel.Text = "Welcome to the Epic Tile Map Editor";
            this.HeadingLavel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.GettingStarted);
            this.Controls.Add(this.CreateNewMap);
            this.Controls.Add(this.LoadMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeadingLavel);
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GettingStarted;
        private System.Windows.Forms.Button CreateNewMap;
        private System.Windows.Forms.Button LoadMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HeadingLavel;
    }
}