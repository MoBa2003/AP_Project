using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Employee
    {
        public static List<Employee> employees = new List<Employee>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SSN { get; set; }

        public static Employee GetEmployee(string username, string password)
        {
            return employees.First(x => x.UserName == username && x.Password == password); // Exception if not found : InvalidOperationException
        }
        public string GetInfo()
        {
            string strinfo = FirstName + " " + LastName + "\n" + Email 
                + "\n" + UserName
                + "\n" + SSN;
            return strinfo;
        }
    }
}
