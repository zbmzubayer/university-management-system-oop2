using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Data_Access_Layer.Entities;

namespace University_Management_System.Data_Access_Layer
{
    class StudentDataAccess: DataAccess
    {
        public bool AddStudent(string name, string email, string dateOfBirth, string phone, string gender, string bloodGroup, string address, string department, string program)
        {
            string sql = "INSERT INTO Students(Name, Email, DateOfBirth, Phone, Gender, BloodGroup, Address, Department, Program) VALUES('" + name + "','" + email + "','" + dateOfBirth + "','" + phone + "', '" + gender + "', '" + bloodGroup + "', '" + address + "', '" + department + "', '" + program + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool UpdateStudent(string studentId, string name, string email, string dateOfBirth, string phone, string gender, string bloodGroup, string address, string department, string program)
        {
            string sql = "UPDATE Students SET Name='" + name + "', Email='" + email + "', DateOfBirth='" + dateOfBirth + "', Phone='" + phone + "', Gender='" + gender + "', Bloodgroup='" + bloodGroup + "', Address='" + address + "', Department='" + department + "', Program='" + program + "' WHERE StudentId=" +  studentId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        public Student SearchStudentInfo(string studentId)
        {
            string sql = "SELECT * FROM Students WHERE StudentId=" + studentId;
            SqlDataReader reader = this.GetData(sql);
            if (reader.HasRows)
            {
                reader.Read();
                Student student = new Student();
                student.StudentId = (int)reader["StudentId"];
                student.Name = reader["Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.DateOfBirth = reader["DateOfBirth"].ToString();
                student.Phone = reader["Phone"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.BloodGroup= reader["BloodGroup"].ToString();
                student.Address = reader["Address"].ToString();
                student.Department = reader["Department"].ToString();
                student.Program = reader["Program"].ToString();
                return student;
            }
            else
                return null;
        }
        public List<Student> GetStudents()
        {
            string sql = "SELECT * FROM Students";
            SqlDataReader reader = this.GetData(sql);
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student= new Student();
                student.StudentId = (int)reader["StudentId"];
                student.Name = reader["Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.DateOfBirth = reader["DateOfBirth"].ToString();
                student.Phone = reader["Phone"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.BloodGroup = reader["BloodGroup"].ToString();
                student.Address = reader["Address"].ToString();
                student.Department = reader["Department"].ToString();
                student.Program = reader["Program"].ToString();
                students.Add(student);
            }
            return students;
        }
        public List<Student> SearchStudentByCategory(string department, string program)
        {
            string sql = "SELECT * FROM Students WHERE Department='" + department + "' OR Program='" + program + "'";
            SqlDataReader reader = this.GetData(sql);
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student();
                student.StudentId = (int)reader["StudentId"];
                student.Name = reader["Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.DateOfBirth = reader["DateOfBirth"].ToString();
                student.Phone = reader["Phone"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.BloodGroup = reader["BloodGroup"].ToString();
                student.Address = reader["Address"].ToString();
                student.Department = reader["Department"].ToString();
                student.Program = reader["Program"].ToString();
                students.Add(student);
            }
            return students;
        }
        public bool DeleteStudent(string studentId)
        {
            string sql = "DELETE FROM Students WHERE StudentId=" + studentId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
