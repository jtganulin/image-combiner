using System.Diagnostics;

namespace ImageCombiner;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo 
        {
            FileName = "https://github.com/dlemstra/Magick.NET/",
            UseShellExecute = true
        });
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "mailto:jtganulin@jgproductions.x10.bz",
            UseShellExecute = true
        });
    }

    private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/jtganulin/image-combiner",
            UseShellExecute = true
        });
    }
}