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
    public partial class NewMapForm : Form
    {
        // This section removes the right hand corner window controls.
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        public string name;                 // The name of the new map
        public int height, width, size;     // height  width and tile size of the new map

        public NewMapForm()
        {
            InitializeComponent();
        }

        // Checks all values before closing the window to create the new map.
        private void createMapButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "" || widthBox.Text == "" || heightBox.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            try
            {
                name = nameBox.Text;
                width = int.Parse(widthBox.Text.ToString());
                height = int.Parse(heightBox.Text.ToString());
                size = 64;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Height and Width must be numbers.");
            }
        }
    }
}
