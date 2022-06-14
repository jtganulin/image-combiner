namespace ImageCombiner
{
	public partial class ImageCombiner : Form
	{
		private string leftImgFilePath = "";
		private string rightImgFilePath = "";
		private char orientation = 'h';

		public ImageCombiner()
		{
			InitializeComponent();

		}

		private void horizontalRadio_CheckedChanged(object sender, EventArgs e)
		{
			if(horizontalRadio.Checked)
			{
				// Switch to Horizontal Mode
				img1Lbl.Text = "Left Image";
				img2Lbl.Text = "Right Image";
				orientation ='h';
			}
		}

		private void verticalRadio_CheckedChanged(object sender, EventArgs e)
		{
			if (verticalRadio.Checked)
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
			clearLeftBtn_Click(sender, e);
			clearRightBtn_Click(sender, e);
		}

		private void combineBtn_Click(object sender, EventArgs e)
		{
			// Combine images
			// Need to check if both images are populated and valid
			if (String.IsNullOrEmpty(leftImgFilePath) || String.IsNullOrEmpty(rightImgFilePath))
            {
				if (orientation == 'h')
                {
					MessageBox.Show("Please add both a left and right image", "Missing an Image", MessageBoxButtons.OK);
                } else
                {
					MessageBox.Show("Please add both a bottom and top image", "Missing an Image", MessageBoxButtons.OK);
                }
            } else
            {
				MessageBox.Show("Combining " + leftImgFilePath + " and " + rightImgFilePath);
				var result = new ResultForm(leftImgFilePath, rightImgFilePath, orientation).ShowDialog(this);
				if (result == DialogResult.Yes)
                {
					// User saved the image

                }
				else
                {
					// User closed the dialog without saving

                }
			}
		}

		private void leftImg_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			// Show the clear button
			clearLeftBtn.Visible = true;
		}

		private void rightImg_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			clearRightBtn.Visible = true;
		}

		private void clearLeftBtn_Click(object sender, EventArgs e)
		{
			leftImg.Image = Properties.Resources.DefaultImg;
			clearLeftBtn.Visible = false;
		}

		private void clearRightBtn_Click(object sender, EventArgs e)
		{
			rightImg.Image = Properties.Resources.DefaultImg;
			clearRightBtn.Visible = false;
		}

		private void rightImg_DoubleClick(object sender, EventArgs e)
		{
			LoadImageWithFileDialog((PictureBox)sender);
		}

		private void leftImg_DoubleClick(object sender, EventArgs e)
		{
			LoadImageWithFileDialog((PictureBox)sender);
		}

		// Would like to use EXIF information to show the image in its correct orientation
		private void LoadImageWithFileDialog(PictureBox sender)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files ( *.JPG; *.GIF; *.PNG; *.BMP;)|*.JPG; *.GIF; *.PNG; *.BMP";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (sender.Tag as string == "leftImg")
					{
						try
						{
							leftImg.LoadAsync(openFileDialog.FileName);
							leftImgFilePath = openFileDialog.FileName;
						} catch (IOException e)
                        {
							MessageBox.Show("There was an error:\n" + e.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
                        }
					}
					else if (sender.Tag as string == "rightImg")
					{
						try
						{
							rightImgFilePath = openFileDialog.FileName;
							rightImg.LoadAsync(openFileDialog.FileName);
						}
						catch (IOException e)
						{
							MessageBox.Show("There was an error:\n" + e.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
						}
						
					}
				}
			}		
		}

        private void leftImg_DragEnter(object sender, DragEventArgs e)
        {
			if (e.Data is not null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
				e.Effect = DragDropEffects.Copy;
            } else
            {
				e.Effect = DragDropEffects.None;
            }
        }

        private void rightImg_DragEnter(object sender, DragEventArgs e)
        {
			if (e.Data is not null && e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		// Could condense both dragdrops
        private void leftImg_DragDrop(object sender, DragEventArgs e)
        {
			if (e.Data != null)
			{
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				// There should only be one file, but if more were dropped, choose first one
				if (filenames.Length > 0) {
					leftImgFilePath = filenames[0];
					try
					{
						leftImg.LoadAsync(filenames[0]);
					} catch (IOException ex)
					{
						MessageBox.Show("There was an error:\n" + ex.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
					}
				}
			}
        }

        private void rightImg_DragDrop(object sender, DragEventArgs e)
        {
			if (e.Data != null)
			{
				string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				// There should only be one file, but if more were dropped, choose first one
				if (filenames.Length > 0)
				{
					rightImgFilePath = filenames[0];
					try
					{
						rightImg.LoadAsync(filenames[0]);
					}
					catch (IOException ex)
					{
						MessageBox.Show("There was an error:\n" + ex.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
					}
				}
			}
		}

        private void btnAbout_Click(object sender, EventArgs e)
        {
			new AboutForm().ShowDialog();
        }
    }
}