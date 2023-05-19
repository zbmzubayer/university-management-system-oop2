using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Management_System.Data_Access_Layer.Entities
{
    class Teacher
    {
        public int TeacherId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String DateOfBirth { get; set; }
        public String Phone { get; set; }
        public String Gender { get; set; }
        public String BloodGroup { get; set; }
        public String Address { get; set; }
        public String Department { get; set; }
        public String Designation { get; set; }
    }
}
