using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class Employee
    {
        public static ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public int? Id;
        public string PersonnelNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Employee(int? id, string personnelNumber, string firstName, string lastName, string email, string userName, string password)
        {
            Id = id;
            PersonnelNumber = personnelNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
