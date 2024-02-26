using AForge.Video.DirectShow;
using System;
using System.Windows.Forms;

namespace WebcamSetting
{
    public partial class MainForm : Form
    {
        FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            foreach (FilterInfo videoDevice in videoDevices)
            {
                comboBox1.Items.Add(videoDevice.Name);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                button1.Enabled = false;
            }

            base.OnShown(e);
        }

        private void ShowSetting(VideoCaptureDevice videoCaptureDevice)
        {
            Hide();
            videoCaptureDevice.DisplayPropertyPage(IntPtr.Zero);
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoCaptureDevice videoCaptureDevice = null;

            foreach (FilterInfo videoDevice in videoDevices)
            {
                if (videoDevice.Name == comboBox1.Text)
                {
                    videoCaptureDevice = new VideoCaptureDevice(videoDevice.MonikerString);
                    break;
                }
            }

            if (videoCaptureDevice != null)
            {
                ShowSetting(videoCaptureDevice);
            }
        }
    }
}
