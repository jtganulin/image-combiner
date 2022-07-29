namespace ImageCombiner
{

    // TODO: Add Documentation
    // TODO: Clean up variables, fields, and control IDs
    // TODO: Ensure combination is complete before allowing save

    public partial class ImageCombiner : Form
    {
        private string leftImgFilePath = "";
        private string rightImgFilePath = "";
        private char orientation = 'h';

        public ImageCombiner()
        {
            InitializeComponent();
        }

        ~ImageCombiner()
        {
            this.Dispose(true);
        }

        private void horizontalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (horizontalRadio.Checked)
            {
                // Switch to Horizontal Mode
                img1Lbl.Text = "Left Image";
                img2Lbl.Text = "Right Image";
                orientation = 'h';
            }
            else if (verticalRadio.Checked)
            {
                // Switch to Vertical Mode
                img1Lbl.Text = "Bottom Image";
                img2Lbl.Text = "Top Image";
                orientation = 'v';
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            // Reset images
            ClearImage(sender, e);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void combineBtn_Click(object sender, EventArgs e)
        {
            // Need to check if both images are populated and valid
            if (string.IsNullOrEmpty(leftImgFilePath) || string.IsNullOrEmpty(rightImgFilePath))
            {
                if (orientation == 'h')
                    MessageBox.Show("Please add both a left and right image.", "Missing an Image", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Please add both a bottom and top image.", "Missing an Image", MessageBoxButtons.OK);
            }
            else
            {
                ResultForm resultForm = new ResultForm(leftImgFilePath, rightImgFilePath, orientation);
                DialogResult result = resultForm.ShowDialog(this);
                switch (result)
                {
                    case DialogResult.Yes:
                        // User saved the image
                        MessageBox.Show("Saving completed.");
                        resultForm.Close();
                        break;
                    case DialogResult.No:
                        // User closed the dialog without saving
                        resultForm.Close();
                        break;
                    case DialogResult.Abort:
                        // There was an error with a file path or orientation flag
                        MessageBox.Show(new ArgumentException("There was an error combinging the images.\nPlease ensure both images still exist and try again.").Message.ToString());
                        break;
                }
            }
        }

        private void ToggleImageClearButton(PictureBox pb)
        {
            if (pb.Tag as string == "leftImg")
            {
                if (this.clearLeftBtn.Visible)
                    this.clearLeftBtn.Visible = false;
                else
                    this.clearLeftBtn.Visible = true;
            }
            else if (pb.Tag as string == "rightImg")
            {
                if (this.clearRightBtn.Visible)
                    this.clearRightBtn.Visible = false;
                else
                    this.clearRightBtn.Visible = true;
            }
        }

        public void ClearImage(object sender, EventArgs e)
        {
            string t = ((Button)sender).Tag as string ?? "";
            if (t == "resetBtn")
            {
                leftImg.Image = Properties.Resources.DefaultImg;
                clearLeftBtn.Visible = false;
                rightImg.Image = Properties.Resources.DefaultImg;
                clearRightBtn.Visible = false;
                leftImgFilePath = rightImgFilePath = "";
            }
            else if (t == "clearLeftBtn")
            {
                leftImg.Image = Properties.Resources.DefaultImg;
                clearLeftBtn.Visible = false;
                leftImgFilePath = "";
            }
            else
            {
                rightImg.Image = Properties.Resources.DefaultImg;
                clearRightBtn.Visible = false;
                rightImgFilePath = "";
            }
            ToggleImageSwapButton();
        }

        private void SelectImageWithFileDialog(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files ( *.JPG; *.GIF; *.PNG; *.BMP;)|*.JPG; *.GIF; *.PNG; *.BMP";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadImageAndFixOrientation(sender, openFileDialog.FileName);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("There was an error:\n" + ex.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void LoadImageAndFixOrientation(object sender, string filepath)
        {
            try
            {
                Image image;
                using (var bmpTemp = new Bitmap(filepath))
                {
                    image = new Bitmap(bmpTemp);
                }

                // Get the EXIF info from the image, check its orientation, and display it properly in the PictureBox
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (Array.IndexOf(image.PropertyIdList, 274) > -1 && image.GetPropertyItem(274).Value[0] >= 1 && image.GetPropertyItem(274).Value[0] <= 8)
                {
                    switch (image.GetPropertyItem(274).Value[0])
                    {
                        case 2:
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            break;
                        case 3:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 4:
                            image.RotateFlip(RotateFlipType.Rotate180FlipX);
                            break;
                        case 5:
                            image.RotateFlip(RotateFlipType.Rotate90FlipX);
                            break;
                        case 6:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 7:
                            image.RotateFlip(RotateFlipType.Rotate270FlipX);
                            break;
                        case 8:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    image.RemovePropertyItem(274);
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                ((PictureBox)sender).Image = image;

                if (((PictureBox)sender).Tag as string == "leftImg")
                    leftImgFilePath = filepath;
                else
                    rightImgFilePath = filepath;

                ToggleImageClearButton((PictureBox)sender);
                ToggleImageSwapButton();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void DragEnterEffects(object sender, DragEventArgs e)
        {
            if (e.Data is not null && (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.StringFormat)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DragDropLoad(object sender, DragEventArgs e)
        {
            if (e.Data is not null)
            {
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (filenames.Length < 1)
                {
                    MessageBox.Show("Please drop a valid image onto the box.");
                    return;
                }
                // There should only be one file, but if more were dropped, choose first one
                // leftImgFilePath = filenames[0];
                // Check the extension
                string[] exts = new[] { ".JPG", ".PNG", ".BMP" };

                foreach (string ext in exts)
                {
                    if (Path.GetExtension(filenames[0]).ToUpper().Equals(ext))
                    {
                        try
                        {
                            LoadImageAndFixOrientation(sender, filenames[0]);
                            ToggleImageClearButton((PictureBox)sender);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("There was an error:\n" + ex.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void ToggleImageSwapButton()
        {
            if (leftImgFilePath == "" || rightImgFilePath == "")
            {
                btnSwapImages.Visible = false;
                btnSwapImages.Enabled = false;
            }
            else
            {
                btnSwapImages.Visible = true;
                btnSwapImages.Enabled = true;
            }
        }


        private void btnSwapImages_Click(object sender, EventArgs e)
        {
            // Swap left and right images
            var temp = leftImg.Image;
            leftImg.Image = rightImg.Image;
            rightImg.Image = temp;

            string tempPath = leftImgFilePath;
            leftImgFilePath = rightImgFilePath;
            rightImgFilePath = tempPath;
        }
    }
}
