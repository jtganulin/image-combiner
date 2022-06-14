using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCombiner
{
    public partial class ResultForm : Form
    {
        private string leftImagePath, rightImagePath;
        private char orientation;

        //public FormCombineHorizontal()
        //{
        //    InitializeComponent();
        //}

        public ResultForm(string? leftImagePath, string? rightImagePath, char orientation)
        {
            this.leftImagePath = (leftImagePath is not null) ? leftImagePath : "";
            this.rightImagePath = (rightImagePath is not null) ? rightImagePath : "";
            this.orientation = orientation;

            if (orientation == 'h')
            {
                InitializeComponentHorizontal();
            }
            else if (orientation == 'v')
            {
                InitializeComponent();
            }
            else
            {
                var e =  new ArgumentException("Invalid orientation flag. Please try again,");
                MessageBox.Show(e.Message.ToString());
            }


            CombineImage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Dispose of resources and close form
            this.Close();
        }

        private void CombineImage()
        {
            if (String.IsNullOrEmpty(this.leftImagePath) || String.IsNullOrEmpty(this.rightImagePath))
            {
                //Exception e = new ArgumentNullException("The combinatinon failed because a provided image path was invalid.\nPlease re-select the image and try again.");
                //MessageBox.Show(e.Message.ToString());
                MessageBox.Show("The combinatinon failed because a provided image path was invalid.\nPlease re-select the image and try again.", "Invalid Image Path", MessageBoxButtons.OK);
                //this.Close();
            }
            else
            {

            }
        }
    }
}
