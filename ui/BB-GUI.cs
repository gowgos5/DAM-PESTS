using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitsBolts
{
    public partial class Form1 : Form
    {
        static string image_path;
        static bool live = true;
        static string senState = "OFF";

        public Form1()
        {
            InitializeComponent();

            cb_cameralist.SelectedItem = null;
            cb_cameralist.Text = "---Select---";

            // Find latest picture for camera 16
            var directory = new DirectoryInfo("C:/Users/Vernon/Desktop/DAM-PESTS/backend");
            image_path = (from f in directory.GetFiles("*.png*")
                          orderby f.LastWriteTime descending
                          select f).First().Name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void LSU_Click(object sender, EventArgs e)
        {

        }

        // Analysis button 
        private void DAN_Click(object sender, EventArgs e)
        {
            this.dat_analysis.Visible = true; // show the frequency of rats captured
            this.pb_blueprint.Image = new Bitmap(BitsBolts.Properties.Resources.analysis);
            this.pb_camera.Visible = false; // hide rat picture
            this.cb_cameralist.Visible = false;
            live = false;

            // renders the chart
            int index = this.dat_analysis.Series["Frequency"].Points.AddXY(1,34);
            this.dat_analysis.Series["Frequency"].Points[index].AxisLabel = "FEB";
            int index1 = this.dat_analysis.Series["Frequency"].Points.AddXY(2, 37);
            this.dat_analysis.Series["Frequency"].Points[index1].AxisLabel = "MAR";
            int index2 = this.dat_analysis.Series["Frequency"].Points.AddXY(3, 25);
            this.dat_analysis.Series["Frequency"].Points[index2].AxisLabel = "APR";
            int index3 = this.dat_analysis.Series["Frequency"].Points.AddXY(4, 17);
            this.dat_analysis.Series["Frequency"].Points[index3].AxisLabel = "MAY";
        }

        // Live Status button
        private void LSU_Click_1(object sender, EventArgs e)
        {
            // THIS IS THE DUMMY BUTTON THAT REPRESENTS A RAT BEING DETECTED
            this.dat_analysis.Visible = false;
            this.pb_blueprint.Visible = true;
            this.pb_camera.Visible = true;
            this.cb_cameralist.Visible = true;
            live = true;
            SensorUpdate("16", senState);

            // AFTER DETECTION CAN AUTORESET OR CAN MAKE IT AS A FORM CLICK EVENT TO RETURN TO DEFAULT I CAN HANDLE ON THAT DAY
        }

        // Images Database button
        private void IMD_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Users/Vernon/Desktop/DAM-PESTS/backend");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCamera = cb_cameralist.SelectedIndex+1;
            Program.getCameraFeed(selectedCamera);
        }

        private void rat_live_Click(object sender, EventArgs e)
        {

        }

        // Update image
        public void ImageUpdate(int selectedCamera)
        {
            if (selectedCamera == 16)
            {
                this.pb_camera.Image = new Bitmap("C:/Users/Vernon/Desktop/DAM-PESTS/backend/" + image_path);
            }
            else
            {
                this.pb_camera.Image = new Bitmap("C:/Users/Vernon/Desktop/DAM-PESTS/ui/Resources/cam" + selectedCamera.ToString() + ".jpeg");
            }
        }

        // Update cameras (only camera 16 for demo purposes)
        public void CameraUpdate(string cam)
        {
            image_path = cam;

            int selectedCamera = 0;
            this.Invoke(new MethodInvoker(delegate () { selectedCamera = cb_cameralist.SelectedIndex+1; }));
            if (selectedCamera == 16)
            {
                ImageUpdate(16);
            }
        }

        // Update sensors (only sensor 16 for demo purposes)
        public void SensorUpdate(string sensorNum, string state)
        {
            if (sensorNum == "16" && live)
            {
                if (state == "ON")
                {
                    this.pb_blueprint.Image = new Bitmap(BitsBolts.Properties.Resources.live_activated);

                }
                else
                {
                    this.pb_blueprint.Image = new Bitmap(BitsBolts.Properties.Resources.live_clean);

                }
                senState = state;
            }
        }
    }
}