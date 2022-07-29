using System.Drawing.Imaging;

using ImageMagick;

namespace ImageCombiner
{
	public partial class ResultForm : Form
	{
		private string leftImagePath, rightImagePath;
		private char orientation;
		private MagickImage resultImg;

		public ResultForm(string? leftImagePath, string? rightImagePath, char orientation)
		{
			this.leftImagePath = leftImagePath ?? "";
			this.rightImagePath = rightImagePath ?? "";
			this.orientation = orientation;
			this.resultImg = new MagickImage();

			if (orientation == 'h')
				InitializeComponentHorizontal();
			else
				InitializeComponent();

			try
			{
				imgCombineResult.Image = Properties.Resources.PleaseWait;
				this.btnSave.Enabled = false;
				ThreadStart ts = (() => CombineImage());
				ts += () =>
				{
					// Show combined preview in result PictureBox
					imgCombineResult.Image = Image.FromStream(new MemoryStream(resultImg.ToByteArray()));
					this.btnSave.Enabled = true;
				};
				Thread thread = new Thread(ts) { IsBackground = true };
				thread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		~ResultForm()
		{
			this.Dispose(true);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to discard your combined image?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.No;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new())
			{
				saveFileDialog.Filter = "Image Files ( *.JPG; *.GIF; *.PNG; *.BMP;)|*.JPG; *.GIF; *.PNG; *.BMP";
				saveFileDialog.InitialDirectory = new FileInfo(rightImagePath).DirectoryName;
				saveFileDialog.Title = "Save Combined Image...";
				saveFileDialog.FileName = "Result.jpg";
				saveFileDialog.RestoreDirectory = true;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						using (FileStream fs = new(saveFileDialog.FileName, FileMode.Create))
						{
							// TODO: Right now saving as JPEG, but would like to get the format from the provided images
							//       or give an option.
							Image image = resultImg.ToBitmap();
							image.Save(fs, ImageFormat.Jpeg);
							image.Dispose(); fs.FlushAsync();
							this.DialogResult = DialogResult.Yes;
						}
					}
					catch (IOException)
					{
						MessageBox.Show("There was an error saving the image. \n\nPlease try again or select a new file name or save location.", "Saving Error", MessageBoxButtons.OK);
					}
				}
			}
		}

		// TODO: Would like to retain EXIF date information
		private void CombineImage()
		{
			if ((string.IsNullOrEmpty(leftImagePath) || string.IsNullOrEmpty(rightImagePath) || Array.IndexOf(new[] { 'h', 'v' }, orientation) < 0) && (!File.Exists(leftImagePath) || !File.Exists(rightImagePath)))
			{
				this.DialogResult = DialogResult.Abort;
				return;
			}

			Image leftImage, rightImage;
			try
			{
				using (leftImage = Image.FromFile(leftImagePath))
				using (rightImage = Image.FromFile(rightImagePath))
				using (MagickImageCollection collection = new())
				{
					// TODO: Make sure both images exist
					Image[] images = new[] { leftImage, rightImage };
					foreach (Image img in images)
					{
#pragma warning disable CS8602 // Dereference of a possibly null reference. ...Value[0] won't be accessed if it's not in the property list
						if (Array.IndexOf(img.PropertyIdList, 274) > -1 && (img.GetPropertyItem(274).Value[0] >= 1 && img.GetPropertyItem(274).Value[0] <= 8))
						{
							switch (img.GetPropertyItem(274).Value[0])
							{
								case 2:
									img.RotateFlip(RotateFlipType.RotateNoneFlipX);
									break;
								case 3:
									img.RotateFlip(RotateFlipType.Rotate180FlipNone);
									break;
								case 4:
									img.RotateFlip(RotateFlipType.Rotate180FlipX);
									break;
								case 5:
									img.RotateFlip(RotateFlipType.Rotate90FlipX);
									break;
								case 6:
									img.RotateFlip(RotateFlipType.Rotate90FlipNone);
									break;
								case 7:
									img.RotateFlip(RotateFlipType.Rotate270FlipX);
									break;
								case 8:
									img.RotateFlip(RotateFlipType.Rotate270FlipNone);
									break;
							}
							img.RemovePropertyItem(274);
						}
#pragma warning restore CS8602 // Dereference of a possibly null 
						collection.Add(new MagickImage(new MagickFactory().Image.Create(new Bitmap(img))));
					}

					if (orientation == 'h')
						resultImg = (MagickImage)collection.AppendHorizontally();
					else
					{
						// Vertical append composes the images opposite of desired order
						collection.Reverse();
						resultImg = (MagickImage)collection.AppendVertically();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("There was an error: \n" + e.Message + "\nPlease try again.");
				return;
			}
		}
	}
}
