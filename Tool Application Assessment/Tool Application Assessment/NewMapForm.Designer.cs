namespace Tool_Application_Assessment
{
    partial class NewMapForm
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
            this.mapName = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createMapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapName
            // 
            this.mapName.AutoSize = true;
            this.mapName.Location = new System.Drawing.Point(32, 29);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(59, 13);
            this.mapName.TabIndex = 0;
            this.mapName.Text = "Map Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(97, 26);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 1;
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(97, 52);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(100, 20);
            this.widthBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(97, 78);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(100, 20);
            this.heightBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // createMapButton
            // 
            this.createMapButton.Location = new System.Drawing.Point(71, 119);
            this.createMapButton.Name = "createMapButton";
            this.createMapButton.Size = new System.Drawing.Size(75, 23);
            this.createMapButton.TabIndex = 6;
            this.createMapButton.Text = "Create Map";
            this.createMapButton.UseVisualStyleBackColor = true;
            this.createMapButton.Click += new System.EventHandler(this.createMapButton_Click);
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 169);
            this.Controls.Add(this.createMapButton);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.mapName);
            this.Name = "NewMapForm";
            this.Text = "Create New Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createMapButton;
    }
}