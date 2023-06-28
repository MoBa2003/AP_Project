using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace EssentialClasses
{
    public class Customer
    {
        public static List<Customer> customers = new List<Customer>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ID { get; set; }
        public string PhoneNumber { get; set; }
        
        public string UserName;

        public string Password;

        public static Customer GetCustomer(string id)
        {
            return customers.First(x => x.ID == id); // Exception if not found : InvalidOperationException
        }
        public static Customer GetCustomer(string username, string password)
        {
            return customers.First(x => x.UserName == username && x.Password == password); // Exception if not found : InvalidOperationException
        }
        public string GetInfo()
        {
            string strinfo = FirstName + " " + LastName + "\n" + Email
                + "\n" + PhoneNumber
                + "\n" + ID;
            return strinfo;
        }

        //Write a Code to generate the username and pass

    }
}
