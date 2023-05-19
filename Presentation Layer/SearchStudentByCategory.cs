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

namespace University_Management_System.Presentation_Layer
{
    public partial class SearchStudentByCategory : Form
    {
        public SearchStudentByCategory()
        {
            InitializeComponent();
        }
        private void SearchStudentByCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void SearchStudentByCategory_Load(object sender, EventArgs e)
        {
            GridViewUpdate();
            StudentDataAccess studentDataAccess = new StudentDataAccess();
            metroGridStudentCategory.DataSource = studentDataAccess.GetStudents();
        }
        void GridViewUpdate()
        {
            StudentDataAccess studentDataAccess = new StudentDataAccess();
            metroGridStudentCategory.DataSource = studentDataAccess.GetStudents();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            StudentDataAccess studentDataAccess = new StudentDataAccess();
            metroGridStudentCategory.DataSource = studentDataAccess.SearchStudentByCategory(comboBoxDepartment.Text, comboBoxProgram.Text);
        }
    }
}
