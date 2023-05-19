using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using University_Management_System.Data_Access_Layer;
using University_Management_System.Data_Access_Layer.Entities;

namespace University_Management_System.Presentation_Layer
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(textBoxEmail.Text, pattern))
            {
                errorProviderEmail.Clear();
            }
            else
            {
                errorProviderEmail.SetError(textBoxEmail, "Provide a valid email");
            }
        }
        private void metroCheckBoxTerms_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBoxTerms.Checked)
            {
                buttonRegister.Enabled = true;
            }
            else
            {
                buttonRegister.Enabled = false;
            }
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            AdminDataAccess adminDataAccess = new AdminDataAccess();
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Give name");
            }
            else if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Give username");
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Give email");
            }
            else if (textBoxPhone.Text == "")
            {
                MessageBox.Show("Give phone number");
            }
            else if (textBoxAddress.Text == "")
            {
                MessageBox.Show("Give address");
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Give password");
            }
            else if (comboBoxAdminType.Text == "")
            {
                MessageBox.Show("Choose admin type");
            }
            else if(textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Password and confirm password must be matched");
            }
            else
            {
                Admin admin = new Admin();
                admin.Name = textBoxName.Text;
                admin.Username = textBoxUsername.Text;
                admin.Email = textBoxEmail.Text;
                admin.Phone = textBoxPhone.Text;
                admin.Address = textBoxAddress.Text;
                admin.Password = textBoxPassword.Text;
                admin.AdminType = comboBoxAdminType.Text;
                if (adminDataAccess.AdminRegister(admin))
                {
                    MessageBox.Show("Account created successfully");
                    LogIn logIn = new LogIn();
                    this.Hide();
                    logIn.Show();
                }
                else
                {
                    MessageBox.Show("Error occurred");
                }
            }
        }
    }
}
