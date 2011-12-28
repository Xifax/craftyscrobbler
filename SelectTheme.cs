using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CraftyScrobbler
{
    public partial class SelectTheme : Form
    {
        public SelectTheme()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Infragistics.Win.AppStyling.StyleManager.Load(".//themes//" + comboBox1.SelectedItem.ToString() + ".isl");
        }

    }
}
