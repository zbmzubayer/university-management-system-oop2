using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using University_Management_System.Presentation_Layer;

namespace University_Management_System
{
    public partial class MenuTeacher : Form
    {
        public MenuTeacher()
        {
            InitializeComponent();
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public void ShowThisForm(object form)
        {
            panelMain.Controls.Clear();
            Form f = form as Form;
            f.TopLevel = false;
            panelMain.Controls.Add(f);
            panelMain.Tag = f;
            labelTitle.Text = f.Text;
            f.Show();
        }

        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {
            ShowThisForm(new AddTeacher());
        }

        private void buttonUpdateTeacher_Click(object sender, EventArgs e)
        {
            ShowThisForm(new UpdateTeacherInfo());
        }

        private void buttonSearchTeacher_Click(object sender, EventArgs e)
        {
            ShowThisForm(new SearchTeacherInfo());
        }

        private void buttonSearchTeacherCategory_Click(object sender, EventArgs e)
        {
            ShowThisForm(new SearchTeacherByCategory());
        }

        private void buttonRemoveTeacher_Click(object sender, EventArgs e)
        {
            ShowThisForm(new RemoveTeacher());
        }
        private void buttonManageSettings_Click(object sender, EventArgs e)
        {
            ShowThisForm(new ManageSettings());
        }
        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }
    }
}
