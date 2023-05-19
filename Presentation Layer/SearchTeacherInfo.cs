using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using University_Management_System.Data_Access_Layer;
using University_Management_System.Data_Access_Layer.Entities;

namespace University_Management_System.Presentation_Layer
{
    public partial class SearchTeacherInfo : Form
    {
        public SearchTeacherInfo()
        {
            InitializeComponent();
        }
        private void SearchTeacherInfo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string pdfText = "AMERICAN INTERNATIONAL UNIVERSITY-BANGLADESH\n\n";
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
                    pdfText += labelId.Text + ": " + teacher.TeacherId + "\n"
                        + labelName.Text + ": " + teacher.Name + "\n"
                        + labelEmail.Text + ": " + teacher.Email + "\n"
                        + labelDateOfBirth.Text + ": " + teacher.DateOfBirth + "\n"
                        + labelPhone.Text + ": " + teacher.Phone + "\n"
                        + labelGender.Text + ": " + teacher.Gender + "\n"
                        + labelBloodGroup.Text + ": " + teacher.BloodGroup + "\n"
                        + labelAddress.Text + ": " + teacher.Address + "\n"
                        + labelDepartment.Text + ": " + teacher.Department + "\n"
                        + labelDesignation.Text + ": " + teacher.Designation + "\n";
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF|*.pdf", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                            try
                            {
                                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                doc.Open();
                                doc.Add(new iTextSharp.text.Paragraph(pdfText));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                doc.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
