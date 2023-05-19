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
    public partial class UpdateTeacherInfo : Form
    {
        public UpdateTeacherInfo()
        {
            InitializeComponent();
        }

        private void UpdateStudentInfo_FormClosing(object sender, FormClosingEventArgs e)
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
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            TeacherDataAccess teacherDataAccess = new TeacherDataAccess();
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Give name");
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Give email");
            }
            else if (dateTimePickerBirth.Text == "")
            {
                MessageBox.Show("Give date of birth");
            }
            else if (textBoxPhone.Text == "")
            {
                MessageBox.Show("Give phone number");
            }
            else if (radioButtonMale.Checked == false && radioButtonFemale.Checked == false)
            {
                MessageBox.Show("Give gender");
            }
            else if (comboBoxBloodGroup.Text == "")
            {
                MessageBox.Show("Give blood group");
            }
            else if (textBoxAddress.Text == "")
            {
                MessageBox.Show("Give address");
            }
            else if (comboBoxDepartment.Text == "")
            {
                MessageBox.Show("Give department");
            }
            else if (comboBoxDesignation.Text == "")
            {
                MessageBox.Show("Give designation");
            }
            else
            {
                Teacher teacher = new Teacher();
                teacher.Name = textBoxName.Text;
                teacher.Email = textBoxEmail.Text;
                teacher.DateOfBirth = dateTimePickerBirth.Text;
                teacher.Phone = textBoxPhone.Text;
                if (radioButtonMale.Checked)
                {
                    teacher.Gender = "Male";
                }
                else
                {
                    teacher.Gender = "Female";
                }
                teacher.BloodGroup = comboBoxBloodGroup.Text;
                teacher.Address = textBoxAddress.Text;
                teacher.Department = comboBoxDepartment.Text;
                teacher.Designation = comboBoxDesignation.Text;

                if (teacherDataAccess.UpdateTeacher(textBoxId.Text, teacher.Name, teacher.Email, teacher.DateOfBirth, teacher.Phone, teacher.Gender, teacher.BloodGroup, teacher.Address, teacher.Department, teacher.Designation))
                {
                    MessageBox.Show("Teacher info updated");
                }

                else
                {
                    MessageBox.Show("ID not found");
                }
                ClearFields();
            }
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
    }
}
