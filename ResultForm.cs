using System.Drawing.Imaging;

using ImageMagick;

namespace ImageCombiner;

public partial class ResultForm : Form
{
	private readonly Image _leftImage, _rightImage;
	private readonly char _orientation;
	private MagickImage _resultImg;

	public ResultForm(Image leftImage, Image rightImage, char orientation)
	{
		_leftImage = leftImage;
		_rightImage = rightImage;
		_orientation = orientation;
		_resultImg = new MagickImage();

		if (orientation == 'h')
			InitializeComponentHorizontal();
		else
			InitializeComponent();

		try
		{
			imgCombineResult.Image = Properties.Resources.PleaseWait;
			Toggle_btnSave(false);
			ThreadStart ts = CombineImage;
			ts += delegate
			{
				imgCombineResult.Image = _resultImg.ToBitmap();
				Toggle_btnSave(true);
			};
			Thread t = new Thread(ts);
			t.Start();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	~ResultForm()
	{
		if (_resultImg is not null)
			_resultImg.Dispose();
		Dispose();
	}

	private void Toggle_btnSave(bool enable)
	{
		if (btnSave.InvokeRequired)
		{
			void SafeToggle()
			{
				Toggle_btnSave(true);
			}

			btnSave.Invoke((Action)SafeToggle);
		}
		else
			btnSave.Enabled = enable;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Are you sure you want to discard your combined image?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			if (_resultImg is not null)
				_resultImg.Dispose();
			DialogResult = DialogResult.No;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		using SaveFileDialog saveFileDialog = new();
		saveFileDialog.Filter = "Image Files ( *.JPG; *.PNG; *.BMP;)|*.JPG; *.PNG; *.BMP";
		saveFileDialog.Title = "Save Combined Image...";
		saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		saveFileDialog.FileName = "Result.jpg";
		saveFileDialog.RestoreDirectory = true;
		if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
		try
		{
			using FileStream fs = new(saveFileDialog.FileName, FileMode.Create);
			// TODO: Right now saving as JPEG, but would like to get the format from the provided images
			//       or give an option.
			Image image = _resultImg.ToBitmap();
			// Get the date taken of the right/top image and give it to the result image
			if (Array.IndexOf(_rightImage.PropertyIdList, 36867) > -1 && _rightImage.GetPropertyItem(36867) is not null)
			{
				var date = _rightImage.GetPropertyItem(36867);
				if (date != null) image.SetPropertyItem(date);
			}
			image.Save(fs, ImageFormat.Jpeg);
			image.Dispose(); _resultImg.Dispose();
			DialogResult = DialogResult.Yes;
		}
		catch (IOException)
		{
			MessageBox.Show("There was an error saving the image. \n\nPlease try again or select a new file name or save location.", "Saving Error", MessageBoxButtons.OK);
		}
	}

	private void CombineImage()
	{
		try
		{
			using MagickImageCollection collection = new();
			collection.Add(new MagickImage(new MagickFactory().Image.Create(new Bitmap(_leftImage))));
			collection.Add(new MagickImage(new MagickFactory().Image.Create(new Bitmap(_rightImage))));
			if (_orientation == 'h')
				_resultImg = (MagickImage)collection.AppendHorizontally();
			else
			{
				// Vertical append composes the images opposite of desired order
				collection.Reverse();
				_resultImg = (MagickImage)collection.AppendVertically();
			}
		}
		catch (Exception)
		{
			DialogResult = DialogResult.Abort;
		}
	}
}