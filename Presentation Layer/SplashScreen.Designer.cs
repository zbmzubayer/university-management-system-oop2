
namespace University_Management_System.Presentation_Layer
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.splashScreenPictureBox = new System.Windows.Forms.PictureBox();
            this.splashScreenProgressBar = new System.Windows.Forms.ProgressBar();
            this.splashScreenTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splashScreenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenPictureBox
            // 
            this.splashScreenPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splashScreenPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("splashScreenPictureBox.Image")));
            this.splashScreenPictureBox.Location = new System.Drawing.Point(0, 0);
            this.splashScreenPictureBox.Name = "splashScreenPictureBox";
            this.splashScreenPictureBox.Size = new System.Drawing.Size(1264, 681);
            this.splashScreenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.splashScreenPictureBox.TabIndex = 0;
            this.splashScreenPictureBox.TabStop = false;
            // 
            // splashScreenProgressBar
            // 
            this.splashScreenProgressBar.BackColor = System.Drawing.Color.Chartreuse;
            this.splashScreenProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.splashScreenProgressBar.Location = new System.Drawing.Point(432, 614);
            this.splashScreenProgressBar.Name = "splashScreenProgressBar";
            this.splashScreenProgressBar.Size = new System.Drawing.Size(400, 10);
            this.splashScreenProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.splashScreenProgressBar.TabIndex = 1;
            // 
            // splashScreenTimer
            // 
            this.splashScreenTimer.Enabled = true;
            this.splashScreenTimer.Tick += new System.EventHandler(this.splashScreenTimer_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splashScreenProgressBar);
            this.Controls.Add(this.splashScreenPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AIUB MANAGEMENT SYSTEM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splashScreenPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox splashScreenPictureBox;
        private System.Windows.Forms.ProgressBar splashScreenProgressBar;
        private System.Windows.Forms.Timer splashScreenTimer;
    }
}