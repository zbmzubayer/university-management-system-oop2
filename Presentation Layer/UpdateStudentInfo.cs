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
    public partial class UpdateStudentInfo : Form
    {
        public UpdateStudentInfo()
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
            comboBoxProgram.Text = string.Empty;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            StudentDataAccess studentDataAccess = new StudentDataAccess();
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
            else if (comboBoxProgram.Text == "")
            {
                MessageBox.Show("Give program");
            }
            else
            {
                Student student = new Student();
                student.Name = textBoxName.Text;
                student.Email = textBoxEmail.Text;
                student.DateOfBirth = dateTimePickerBirth.Text;
                student.Phone = textBoxPhone.Text;
                if (radioButtonMale.Checked)
                {
                    student.Gender = "Male";
                }
                else
                {
                    student.Gender = "Female";
                }
                student.BloodGroup = comboBoxBloodGroup.Text;
                student.Address = textBoxAddress.Text;
                student.Department = comboBoxDepartment.Text;
                student.Program = comboBoxProgram.Text;
                
                if (studentDataAccess.UpdateStudent(textBoxId.Text, student.Name, student.Email, student.DateOfBirth, student.Phone, student.Gender, student.BloodGroup, student.Address, student.Department, student.Program))
                {
                    MessageBox.Show("Student info updated");
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
                StudentDataAccess studentDataAccess = new StudentDataAccess();
                Student student = studentDataAccess.SearchStudentInfo(textBoxId.Text);
                if (student == null)
                {
                    MessageBox.Show("Student not found");
                }
                else
                {
                    textBoxName.Text = student.Name;
                    textBoxEmail.Text = student.Email;
                    dateTimePickerBirth.Text = student.DateOfBirth;
                    textBoxPhone.Text = student.Phone;
                    if(student.Gender == "Male")
                    {
                        radioButtonMale.Checked = true;
                    }
                    else
                    {
                        radioButtonFemale.Checked = true;
                    }
                    comboBoxBloodGroup.Text = student.BloodGroup;
                    textBoxAddress.Text = student.Address;
                    comboBoxDepartment.Text = student.Department;
                    comboBoxProgram.Text = student.Program;
                }
            }
        }
    }
}
