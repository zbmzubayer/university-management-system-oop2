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
    public partial class SearchStudentInfo : Form
    {
        public SearchStudentInfo()
        {
            InitializeComponent();
        }

        private void SearchStudentInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string pdfText = "AMERICAN INTERNATIONAL UNIVERSITY-BANGLADESH\n\n";
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
                    pdfText += labelId.Text + ": " + student.StudentId + "\n"
                        + labelName.Text + ": " + student.Name + "\n"
                        + labelEmail.Text + ": " + student.Email + "\n"
                        + labelDateOfBirth.Text + ": " + student.DateOfBirth + "\n"
                        + labelPhone.Text + ": " + student.Phone + "\n"
                        + labelGender.Text + ": " + student.Gender + "\n"
                        + labelBloodGroup.Text + ": " + student.BloodGroup + "\n"
                        + labelAddress.Text + ": " + student.Address + "\n"
                        + labelDepartment.Text + ": " + student.Department + "\n"
                        + labelProgram.Text + ": " + student.Program + "\n";
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
