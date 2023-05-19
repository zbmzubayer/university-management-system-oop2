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
    public partial class SearchTeacherByCategory : Form
    {
        public SearchTeacherByCategory()
        {
            InitializeComponent();
        }
        private void SearchTeacherByCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        void GridViewUpdate()
        {
            TeacherDataAccess teacherDataAccess = new TeacherDataAccess();
            metroGridStudentCategory.DataSource = teacherDataAccess.GetTeachers();
        }

        

        private void SearchTeacherByCategory_Load(object sender, EventArgs e)
        {
            GridViewUpdate();
            TeacherDataAccess teacherDataAccess = new TeacherDataAccess();
            metroGridStudentCategory.DataSource = teacherDataAccess.GetTeachers();
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            TeacherDataAccess teacherDataAccess = new TeacherDataAccess();
            metroGridStudentCategory.DataSource = teacherDataAccess.SearchTeacherByCategory(comboBoxDepartment.Text, comboBoxDesignation.Text);
        }
    }
}
