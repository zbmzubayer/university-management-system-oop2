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
    public partial class RemoveTeacher : Form
    {
        public RemoveTeacher()
        {
            InitializeComponent();
        }
        private void RemoveTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        void ClearFields()
        {
            textBoxId.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            dateTimePickerBirth.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;
            comboBoxBloodGroup.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            comboBoxDepartment.Text = string.Empty;
            comboBoxDesignation.Text = string.Empty;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("Give an id");
            }
            else
            {
                TeacherDataAccess teacherDataAccess = new TeacherDataAccess();
                Teacher teacher = teacherDataAccess.SearchTeacherInfo(textBoxId.Text);
                if (teacher == null)
                {
                    MessageBox.Show("Teacher not found");
                }
                else
                {
                    textBoxName.Text = teacher.Name;
                    textBoxEmail.Text = teacher.Email;
                    dateTimePickerBirth.Text = teacher.DateOfBirth;
                    textBoxPhone.Text = teacher.Phone;
                    if (teacher.Gender == "Male")
                    {
                        radioButtonMale.Checked = true;
                    }
                    else
                    {
                        radioButtonFemale.Checked = true;
                    }
                    comboBoxBloodGroup.Text = teacher.BloodGroup;
                    textBoxAddress.Text = teacher.Address;
                    comboBoxDepartment.Text = teacher.Department;
                    comboBoxDesignation.Text = teacher.Designation;
                }
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(textBoxId.Text == "")
            {
                MessageBox.Show("Give an id");
            }
            else
            {
                TeacherDataAccess teacherDataAccess = new TeacherDataAccess();
                if (teacherDataAccess.DeleteTeacher(textBoxId.Text))
                {
                    MessageBox.Show("Teacher Deleted");
                }
                else
                {
                    MessageBox.Show("Teacher not found");
                }
                ClearFields();
            }
        }
    }
}
