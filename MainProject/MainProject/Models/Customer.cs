using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Collections.ObjectModel;

namespace MainProject.Models
{
    public class Customer
    {
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public ObservableCollection<Product> customerproducts = new ObservableCollection<Product>();
        public int? Id { get; set; }

        public string? National_Code;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
       
        public string? PhoneNumber { get; set; }

        public double Wallet;

        public string? UserName;

        public string? Password;

        //public static Customer GetCustomer(string id)
        //{
        //    return customers.First(x => x.ID == id); // Exception if not found : InvalidOperationException
        //}
        //public static Customer GetCustomer(string username, string password)
        //{
        //    return customers.First(x => x.UserName == username && x.Password == password); // Exception if not found : InvalidOperationException
        //}
        //public string GetInfo()
        //{
        //    string strinfo = FirstName + " " + LastName + "\n" + Email
        //        + "\n" + PhoneNumber
        //        + "\n" + ID;
        //    return strinfo;
        //}

        //Write a Code to generate the username and pass

        public void SendMail()
        {
            //you perform generating here
            //Password = pass.generated();
            //UserName = user.generated();

            string fromMail = "swiftordercompany@gmail.com"; //sender gmail
            string Password = "uyxakhpyhfgqehjs"; //app password you made in gamil in two factor

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(new MailAddress("gholamiali41379@gmail.com"));//destination email

            message.Subject = "Your Username and Password in MOBALI";
            message.Body = $"<p>Welcome <br>Here is Your Username and PassWord <br>Username :{this.UserName} <br>Password :{this.Password} </p>";
            
            message.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, Password),
                EnableSsl = true,
            };

            smtp.Send(message);
        }



    }
}
