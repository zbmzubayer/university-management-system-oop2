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
using University_Management_System.Data_Access_Layer.Entities;

namespace University_Management_System.Presentation_Layer
{
    public partial class ManageSettings : Form
    {
        public ManageSettings()
        {
            InitializeComponent();
        }


        private void ManageSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Give username");
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Give password");
            }
            else
            {
                AdminDataAccess adminDataAccess = new AdminDataAccess();
                Admin admin = adminDataAccess.AdminInfoLoad(textBoxUsername.Text, textBoxPassword.Text);
                if (admin == null)
                {
                    MessageBox.Show("admin not found");
                }
                else
                {
                    textBoxId.Text = admin.AdminId.ToString();
                    textBoxName.Text = admin.Name;
                    textBoxEmail.Text = admin.Email;
                    textBoxPhone.Text = admin.Phone;
                    textBoxAddress.Text = admin.Address;
                    comboBoxAdminType.Text = admin.AdminType;
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AdminDataAccess adminDataAccess = new AdminDataAccess();
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Give name");
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
            else
            {
                Admin admin = new Admin();
                admin.AdminId = Convert.ToInt32(textBoxId.Text);
                admin.Name = textBoxName.Text;
                admin.Email = textBoxEmail.Text;
                admin.Phone = textBoxPhone.Text;
                admin.Address = textBoxAddress.Text;
                if (adminDataAccess.AdminUpdate(admin.AdminId.ToString(), admin.Name, admin.Email, admin.Phone, admin.Address))
                {
                    MessageBox.Show("Info updated");
                }

                else
                {
                    MessageBox.Show("Error occurred");
                }
            }
        }
    }

}
