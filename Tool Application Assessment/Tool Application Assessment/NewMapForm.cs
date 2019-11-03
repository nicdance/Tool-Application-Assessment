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
        public string name;
        public int height, width, size;
        public NewMapForm()
        {
            InitializeComponent();
        }

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
