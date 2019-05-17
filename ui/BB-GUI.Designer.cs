namespace BitsBolts
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_live = new System.Windows.Forms.Button();
            this.btn_images = new System.Windows.Forms.Button();
            this.btn_analysis = new System.Windows.Forms.Button();
            this.dat_analysis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_cameralist = new System.Windows.Forms.ComboBox();
            this.pb_camera = new System.Windows.Forms.PictureBox();
            this.pb_blueprint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dat_analysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_camera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_blueprint)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_live
            // 
            this.btn_live.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_live.Location = new System.Drawing.Point(927, 25);
            this.btn_live.Name = "btn_live";
            this.btn_live.Size = new System.Drawing.Size(309, 86);
            this.btn_live.TabIndex = 1;
            this.btn_live.Text = "Live Status";
            this.btn_live.UseVisualStyleBackColor = true;
            this.btn_live.Click += new System.EventHandler(this.LSU_Click_1);
            // 
            // btn_images
            // 
            this.btn_images.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_images.Location = new System.Drawing.Point(927, 259);
            this.btn_images.Name = "btn_images";
            this.btn_images.Size = new System.Drawing.Size(309, 86);
            this.btn_images.TabIndex = 2;
            this.btn_images.Text = "Images Database";
            this.btn_images.UseVisualStyleBackColor = true;
            this.btn_images.Click += new System.EventHandler(this.IMD_Click);
            // 
            // btn_analysis
            // 
            this.btn_analysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_analysis.Location = new System.Drawing.Point(927, 141);
            this.btn_analysis.Name = "btn_analysis";
            this.btn_analysis.Size = new System.Drawing.Size(309, 86);
            this.btn_analysis.TabIndex = 3;
            this.btn_analysis.Text = "Analysis";
            this.btn_analysis.UseVisualStyleBackColor = true;
            this.btn_analysis.Click += new System.EventHandler(this.DAN_Click);
            // 
            // dat_analysis
            // 
            chartArea2.Name = "ChartArea1";
            this.dat_analysis.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.dat_analysis.Legends.Add(legend2);
            this.dat_analysis.Location = new System.Drawing.Point(889, 425);
            this.dat_analysis.Name = "dat_analysis";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Frequency";
            this.dat_analysis.Series.Add(series2);
            this.dat_analysis.Size = new System.Drawing.Size(378, 280);
            this.dat_analysis.TabIndex = 4;
            this.dat_analysis.Text = "Data Analysis";
            this.dat_analysis.Visible = false;
            // 
            // cb_cameralist
            // 
            this.cb_cameralist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cameralist.FormattingEnabled = true;
            this.cb_cameralist.Items.AddRange(new object[] {
            "Camera 1",
            "Camera 2",
            "Camera 3",
            "Camera 4",
            "Camera 5",
            "Camera 6",
            "Camera 7",
            "Camera 8",
            "Camera 9",
            "Camera 10",
            "Camera 11",
            "Camera 12",
            "Camera 13",
            "Camera 14",
            "Camera 15",
            "Camera 16",
            "Camera 17",
            "Camera 18",
            "Camera 19"});
            this.cb_cameralist.Location = new System.Drawing.Point(886, 382);
            this.cb_cameralist.Name = "cb_cameralist";
            this.cb_cameralist.Size = new System.Drawing.Size(392, 28);
            this.cb_cameralist.TabIndex = 8;
            this.cb_cameralist.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pb_camera
            // 
            this.pb_camera.BackColor = System.Drawing.SystemColors.Desktop;
            this.pb_camera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb_camera.Image = global::BitsBolts.Properties.Resources.background;
            this.pb_camera.Location = new System.Drawing.Point(886, 425);
            this.pb_camera.Name = "pb_camera";
            this.pb_camera.Padding = new System.Windows.Forms.Padding(5);
            this.pb_camera.Size = new System.Drawing.Size(392, 315);
            this.pb_camera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_camera.TabIndex = 6;
            this.pb_camera.TabStop = false;
            this.pb_camera.Click += new System.EventHandler(this.rat_live_Click);
            // 
            // pb_blueprint
            // 
            this.pb_blueprint.Image = global::BitsBolts.Properties.Resources.live_clean;
            this.pb_blueprint.Location = new System.Drawing.Point(12, 14);
            this.pb_blueprint.Name = "pb_blueprint";
            this.pb_blueprint.Size = new System.Drawing.Size(804, 730);
            this.pb_blueprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_blueprint.TabIndex = 0;
            this.pb_blueprint.TabStop = false;
            this.pb_blueprint.WaitOnLoad = true;
            // 
            // Form1
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1332, 756);
            this.Controls.Add(this.cb_cameralist);
            this.Controls.Add(this.btn_analysis);
            this.Controls.Add(this.btn_images);
            this.Controls.Add(this.btn_live);
            this.Controls.Add(this.pb_camera);
            this.Controls.Add(this.dat_analysis);
            this.Controls.Add(this.pb_blueprint);
            this.Name = "Form1";
            this.Text = "UI";
            ((System.ComponentModel.ISupportInitialize)(this.dat_analysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_camera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_blueprint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_live;
        private System.Windows.Forms.Button btn_images;
        private System.Windows.Forms.Button btn_analysis;
        private System.Windows.Forms.DataVisualization.Charting.Chart dat_analysis;
        private System.Windows.Forms.PictureBox pb_camera;
        private System.Windows.Forms.PictureBox pb_blueprint;
        private System.Windows.Forms.ComboBox cb_cameralist;
    }
}

