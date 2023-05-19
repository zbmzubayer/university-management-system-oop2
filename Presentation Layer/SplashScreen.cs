using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System.Presentation_Layer
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void splashScreenTimer_Tick(object sender, EventArgs e)
        {
            splashScreenProgressBar.Increment(4);
            if(splashScreenProgressBar.Value == 100)
            {
                splashScreenTimer.Enabled = false;
                LogIn login = new LogIn();
                login.Show();
                this.Hide();
            }
        }
    }
}
