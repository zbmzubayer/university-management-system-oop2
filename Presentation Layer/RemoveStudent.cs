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
    public partial class RemoveStudent : Form
    {
        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void RemoveStudent_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (student.Gender == "Male")
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
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("Give an id");
            }
            else
            {
                StudentDataAccess studentDataAccess = new StudentDataAccess();
                if (studentDataAccess.DeleteStudent(textBoxId.Text))
                {
                    MessageBox.Show("Student Deleted");
                }
                else
                {
                    MessageBox.Show("Student not found");
                }
                ClearFields();
            }
        }
    }
}
