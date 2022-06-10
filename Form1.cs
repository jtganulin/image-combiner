namespace ImageCombiner
{
	public partial class Form1 : Form
	{
		private string leftImgFileName = "";
		private string rightImgFileName = "";
		private string orientation = "+append"; // IM has +append = Horizontal and -append = Vertical

		public Form1()
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
				orientation = "+append";
			}
		}

		private void verticalRadio_CheckedChanged(object sender, EventArgs e)
		{
			if (verticalRadio.Checked)
			{
				// Switch to Vertical Mode
				img1Lbl.Text = "Bottom Image";
				img2Lbl.Text = "Top Image";
				orientation = "-append";
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
			if (String.IsNullOrEmpty(leftImgFileName) || String.IsNullOrEmpty(rightImgFileName))
            {
				if (orientation == "+append")
                {
					MessageBox.Show("Please add both a left and right image", "Missing an Image", MessageBoxButtons.OK);
                } else
                {
					MessageBox.Show("Please add both a bottom and top image", "Missing an Image", MessageBoxButtons.OK);
                }
            } else
            {
				MessageBox.Show("Combining " + leftImgFileName + " and " + rightImgFileName);
				

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
			loadImage((PictureBox)sender);
		}

		private void leftImg_DoubleClick(object sender, EventArgs e)
		{
			loadImage((PictureBox)sender);
		}

		private void loadImage(PictureBox sender)
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
							leftImgFileName = openFileDialog.FileName;
						} catch (IOException e)
                        {
							MessageBox.Show("There was an error:\n" + e.Message + "\n\nPlease try again or use a different image.", "Loading Error", MessageBoxButtons.OK);
                        }
					}
					else if (sender.Tag as string == "rightImg")
					{
						try
						{
							rightImgFileName = openFileDialog.FileName;
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

        private void leftImg_DragDrop(object sender, DragEventArgs e)
        {
			if (e.Data != null)
			{
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				// There should only be one file, but if more were dropped, choose first one
				if (filenames.Length > 0) {
					leftImgFileName = filenames[0];
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
					rightImgFileName = filenames[0];
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
    }
}