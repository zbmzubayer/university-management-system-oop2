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
    public partial class MenuStudent : Form
    {
        public MenuStudent()
        {
            InitializeComponent();
        }
        private void MenuStudent_FormClosing(object sender, FormClosingEventArgs e)
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
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            /*panelMain.Controls.Clear();
            AddStudent addStudent = new AddStudent() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelMain.Controls.Add(addStudent);
            labelTitle.Text = addStudent.Text;
            addStudent.Show();*/
            ShowThisForm(new AddStudent());
        }

        private void buttonUpdateStudent_Click(object sender, EventArgs e)
        {
            /*panelMain.Controls.Clear();
            UpdateStudentInfo updateStudentInfo = new UpdateStudentInfo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelMain.Controls.Add(updateStudentInfo);
            labelTitle.Text = updateStudentInfo.Text;
            updateStudentInfo.Show();
            */
            ShowThisForm(new UpdateStudentInfo());
        }

        private void buttonSearchStudent_Click(object sender, EventArgs e)
        {
            ShowThisForm(new SearchStudentInfo());
        }

        private void buttonSearchStudentCategory_Click(object sender, EventArgs e)
        {
            ShowThisForm(new SearchStudentByCategory());
        }
        private void buttonRemoveStudent_Click(object sender, EventArgs e)
        {
            ShowThisForm(new RemoveStudent());
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }
        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
        }

        private void buttonManageSettings_Click(object sender, EventArgs e)
        {
            ShowThisForm(new ManageSettings());
        }
    }
}
