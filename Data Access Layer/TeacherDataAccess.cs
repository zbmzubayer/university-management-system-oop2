using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Data_Access_Layer.Entities;

namespace University_Management_System.Data_Access_Layer
{
    class TeacherDataAccess: DataAccess
    {
        public bool AddTeacher(string name, string email, string dateOfBirth, string phone, string gender, string bloodGroup, string address, string department, string designation)
        {
            string sql = "INSERT INTO Teachers(Name, Email, DateOfBirth, Phone, Gender, BloodGroup, Address, Department, Designation) VALUES('" + name + "','" + email + "','" + dateOfBirth + "','" + phone + "', '" + gender + "', '" + bloodGroup + "', '" + address + "', '" + department + "', '" + designation + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool UpdateTeacher(string teacherId, string name, string email, string dateOfBirth, string phone, string gender, string bloodGroup, string address, string department, string designation)
        {
            string sql = "UPDATE Teachers SET Name='" + name + "', Email='" + email + "', DateOfBirth='" + dateOfBirth + "', Phone='" + phone + "', Gender='" + gender + "', Bloodgroup='" + bloodGroup + "', Address='" + address + "', Department='" + department + "', Designation='" + designation + "' WHERE TeacherId=" + teacherId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        public Teacher SearchTeacherInfo(string teacherId)
        {
            string sql = "SELECT * FROM Teachers WHERE TeacherId=" + teacherId;
            SqlDataReader reader = this.GetData(sql);
            if (reader.HasRows)
            {
                reader.Read();
                Teacher teacher = new Teacher();
                teacher.TeacherId = (int)reader["TeacherId"];
                teacher.Name = reader["Name"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.DateOfBirth = reader["DateOfBirth"].ToString();
                teacher.Phone = reader["Phone"].ToString();
                teacher.Gender = reader["Gender"].ToString();
                teacher.BloodGroup = reader["BloodGroup"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.Department = reader["Department"].ToString();
                teacher.Designation = reader["Designation"].ToString();
                return teacher;
            }
            else
                return null;
        }
        public List<Teacher> GetTeachers()
        {
            string sql = "SELECT * FROM Teachers";
            SqlDataReader reader = this.GetData(sql);
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherId = (int)reader["TeacherId"];
                teacher.Name = reader["Name"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.DateOfBirth = reader["DateOfBirth"].ToString();
                teacher.Phone = reader["Phone"].ToString();
                teacher.Gender = reader["Gender"].ToString();
                teacher.BloodGroup = reader["BloodGroup"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.Department = reader["Department"].ToString();
                teacher.Designation = reader["Designation"].ToString();
                teachers.Add(teacher);
            }
            return teachers;
        }
        public List<Teacher> SearchTeacherByCategory(string department, string designation)
        {
            string sql = "SELECT * FROM Teachers WHERE Department='" + department + "' OR Designation='" + designation + "'";
            SqlDataReader reader = this.GetData(sql);
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherId = (int)reader["TeacherId"];
                teacher.Name = reader["Name"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.DateOfBirth = reader["DateOfBirth"].ToString();
                teacher.Phone = reader["Phone"].ToString();
                teacher.Gender = reader["Gender"].ToString();
                teacher.BloodGroup = reader["BloodGroup"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.Department = reader["Department"].ToString();
                teacher.Designation = reader["Designation"].ToString();
                teachers.Add(teacher);
            }
            return teachers;
        }
        public bool DeleteTeacher(string teacherId)
        {
            string sql = "DELETE FROM Teachers WHERE TeacherId=" + teacherId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
