using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using University_Management_System.Data_Access_Layer;

namespace University_Management_System.Presentation_Layer
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text == "")
            {
                MessageBox.Show("Give valid username");
            }
            else if(textBoxPassword.Text == "")
            {
                MessageBox.Show("Give valid password");
            }
            else if (comboBoxAdminType.Text == "")
            {
                MessageBox.Show("Select valid admin type");
            }
            else
            {
                AdminDataAccess adminDataAccess = new AdminDataAccess();
                if(adminDataAccess.ValidateLogin(textBoxUsername.Text, textBoxPassword.Text, comboBoxAdminType.Text))
                {
                    if (comboBoxAdminType.Text == "Students Manager")
                    {
                        MenuStudent menuStudent = new MenuStudent();
                        this.Hide();
                        menuStudent.Show();
                    }
                    else
                    {
                        MenuTeacher menuTeacher = new MenuTeacher();
                        this.Hide();
                        menuTeacher.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid info");
                }
            }
        }
        private void linkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }
    }
}
