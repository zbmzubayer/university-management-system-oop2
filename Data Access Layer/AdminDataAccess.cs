using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Data_Access_Layer.Entities;

namespace University_Management_System.Data_Access_Layer
{
    class AdminDataAccess: DataAccess
    {
        public bool AdminRegister(Admin admin)
        {
            string sql = "INSERT INTO Admins(Name,Username,Email,Phone,Address,Password,AdminType) VALUES('" + admin.Name + "','" + admin.Username + "','" + admin.Email + "','" + admin.Phone + "','" + admin.Address + "','" + admin.Password + "','" + admin.AdminType + "')";
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
        public bool ValidateLogin(string username, string password, string adminType)
        {
            string sql = "SELECT * FROM Admins WHERE Username='" + username + "' AND Password='" + password + "' AND AdminType='" + adminType + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.HasRows)
                return true;
            else
                return false;
        }
        public Admin AdminInfoLoad(string username, string password)
        {
            string sql = "SELECT * FROM Admins WHERE Username='" + username + "' AND Password='" + password + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.HasRows)
            {
                reader.Read();
                Admin admin = new Admin();
                admin.AdminId = (int)reader["AdminId"];
                admin.Name = reader["Name"].ToString();
                admin.Email = reader["Email"].ToString();
                admin.Phone = reader["Phone"].ToString();
                admin.Address = reader["Address"].ToString();
                admin.AdminType = reader["AdminType"].ToString();
                return admin;
            }
            else
                return null;
        }
        public bool AdminUpdate(string adminId, string name, string email, string phone, string address)
        {
            string sql = "UPDATE Admins SET Name='" + name + "', Email='" + email + "', Phone='" + phone + "', Address='" + address + "' WHERE AdminId=" + adminId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
