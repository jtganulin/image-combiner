namespace ImageCombiner;

public partial class ImageCombiner : Form
{
    private char _orientation = 'h';
    private Image? _leftImage;
    private Image? _rightImage;
        
    public ImageCombiner()
    {
        InitializeComponent();
    }

    ~ImageCombiner()
    { 
        Dispose(true);
    }

    private void horizontalRadio_CheckedChanged(object sender, EventArgs e)
    {
        if (horizontalRadio.Checked)
        {
            // Switch to Horizontal Mode
            img1Lbl.Text = "Left Image";
            img2Lbl.Text = "Right Image";
            _orientation = 'h';
        }
        else if (verticalRadio.Checked)
        {
            // Switch to Vertical Mode
            img1Lbl.Text = "Bottom Image";
            img2Lbl.Text = "Top Image";
            _orientation = 'v';
        }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        // Reset images
        ClearImage(sender, e);
    }

    private void btnAbout_Click(object sender, EventArgs e)
    {
        new AboutForm().ShowDialog();
    }

    private void btnCombine_Click(object sender, EventArgs e)
    {
        if (_leftImage is null || _rightImage is null)
        {
            MessageBox.Show(
                _orientation == 'h'
                    ? "Please add both a left and right image."
                    : "Please add both a bottom and top image.", "Missing an Image", MessageBoxButtons.OK);
        }
        else
        {
            // Begin the combination by passing the images to ResultForm
            ResultForm resultForm = new ResultForm(_leftImage, _rightImage, _orientation);
            DialogResult result = resultForm.ShowDialog(this);
            // There was an error with a file path or orientation flag
            if (result == DialogResult.Abort)
                MessageBox.Show(
                    new ArgumentException("There was an error combining the images.\n" +
                                          "Please ensure both images still exist and try again.").Message);
        }
    }

    private void ToggleImageClearButton(object pb)
    {
        // Show the Clear button under the PictureBox
        switch (((PictureBox)pb).Tag as string)
        {
            case "pbLeftImage":
                if (btnClearLeftImage.Visible && _leftImage is null)
                    btnClearLeftImage.Visible = false;
                else
                    btnClearLeftImage.Visible = true;
                break;
            case "pbRightImage":
                if (btnClearRightImage.Visible && _rightImage is null)
                    btnClearRightImage.Visible = false;
                else
                    btnClearRightImage.Visible = true;
                break;
        }
    }

    private void ClearImage(object sender, EventArgs e)
    {
        switch (((Button)sender).Tag as string)
        {
            case "btnReset":
                pbLeftImage.Image = Properties.Resources.DefaultImg;
                btnClearLeftImage.Visible = false;
                pbRightImage.Image = Properties.Resources.DefaultImg;
                btnClearRightImage.Visible = false;
                _leftImage = _rightImage = null;
                break;
            case "btnClearLeftImage":
                pbLeftImage.Image = Properties.Resources.DefaultImg;
                btnClearLeftImage.Visible = false;
                _leftImage = null;
                break;
            case "btnClearRightImage":
                pbRightImage.Image = Properties.Resources.DefaultImg;
                btnClearRightImage.Visible = false;
                _rightImage = null;
                break;
        }
        ToggleImageSwapButton();
    }

    private void SelectImageWithFileDialog(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files ( *.JPG; *.PNG; *.BMP;)|*.JPG; *.PNG; *.BMP";
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        try
        {
            LoadImageAndFixOrientation(sender, openFileDialog.FileName);
            ToggleImageClearButton(sender);
        }
        catch (IOException ex)
        {
            MessageBox.Show("There was an error:\n" + ex.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
        }
    }

    private void LoadImageAndFixOrientation(object sender, string filepath)
    {
        // Load the images into memory
        try
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                fs.CopyTo(ms);
            }
            Image image = Image.FromStream(ms);
                
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

            // Show the orientation-normalized image in the correct PictureBox
            ((PictureBox)sender).Image = image;
            // and store it for later use
            if (((PictureBox)sender).Tag as string == "pbLeftImage")
                _leftImage = image;
            else
                _rightImage = image;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void DragEnterEffects(object sender, DragEventArgs e)
    {
        if (e.Data is not null && (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.StringFormat)))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }

    private void DragDropLoad(object sender, DragEventArgs e)
    {
        if (e.Data is null) return;
        string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        if (filenames.Length < 1)
        {
            MessageBox.Show("Please drop a valid image onto the box.");
            return;
        }

        // Check the extension
        string[] exts = { ".JPG", ".PNG", ".BMP" };

        foreach (string ext in exts)
        {
            // There should only be one file, but if more were dropped, choose first one
            if (!Path.GetExtension(filenames[0]).ToUpper().Equals(ext)) continue;
            try
            {
                LoadImageAndFixOrientation(sender, filenames[0]);
                ToggleImageClearButton((PictureBox)sender);
                ToggleImageSwapButton();
            }
            catch (IOException ex)
            {
                MessageBox.Show("There was an error:\n" + ex.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
            }
        }
    }

    private void ToggleImageSwapButton()
    {
        if (_leftImage is null || _rightImage is null)
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
        (pbLeftImage.Image, pbRightImage.Image) = (pbRightImage.Image, pbLeftImage.Image);
        (_leftImage, _rightImage) = (_rightImage, _leftImage);
    }
}