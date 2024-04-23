using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoReminder
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            pictureBoxHelp.Image = Image.FromFile("C:\\Users\\Fia\\Pictures\\IMG_0527.jpg");
            lblPicture.Text = "Balaton, Hungary";
        }

        private void pictureBoxHelp_Click(object sender, EventArgs e)
        {

        }

        private void lblPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
