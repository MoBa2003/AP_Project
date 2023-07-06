using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MainProject.Controller;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MainProject.Models
{
    public static class ValidationClass
    {
        public static bool NameValidate(this string name)
        {
            Regex regex = new Regex("^[A-Za-z\\s]{3,32}$");
            if (regex.IsMatch(name)) return true;
            return false;
        }


        public static bool EmailValidate(this string name)
        {
            Regex regex = new Regex("^[A-Za-z0-9]{3,32}@[A-Za-z]{3,32}\\.[A-Za-z]{2,3}$");
            if (regex.IsMatch(name)) return true;
            return false;
        }
        public static bool PassWordValidate(this string name)
        {
            Regex regex = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,32}$");
            if (regex.IsMatch(name)) return true;
            return false;
        }

        public static bool IDValidate(this string id)
        {
            Regex regex = new Regex("^00[0-9]{8}$");
            if (!regex.IsMatch(id)) return false;
            return true;
            
        }
        public static bool SSNValidate(this string ssn)
        {
            Regex regex = new Regex("^[0-9]{2}9[0-9]{2}$");
            if (!regex.IsMatch(ssn)) return false;
            return true;
           
        }

        //public static void UserNameValidate(this string id)
        //{
        //    foreach (var emp in Employee.employees) if (emp.UserName == id) throw new Exception("This Username is already in use!");
        //    foreach (var emp in Customer.customers) if (emp.UserName == id) throw new Exception("This Username is already in use!");
        //}

        internal static bool validateEmployeePassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,32}$");
            if (regex.IsMatch(password)) return true;
            return false;
           
        }


        public static bool PhoneValidate(this string s)
        {
            Regex regex = new Regex("^09[0-9]{9}$");
            if (regex.IsMatch(s)) return true;
            return false;
        }



        public static bool CVV_Validate(this string entry)
        {
            Regex regex = new Regex("^[0-9]{3,4}$");
            if (regex.IsMatch(entry))
                return true;
            return false;
        }

        public static bool IsExpired(this DateTime date)
        {
            DateTime now = DateTime.Now;
            if (date.CompareTo(now) < 0)
                return true;
            return false;
        }

        public static bool IsCardValid(this string code)
        {
            int sum = 0;

            for (int i = 0; i < code.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum += int.Parse(code[i].ToString());
                }
                else
                {
                    sum += int.Parse(code[i].ToString()) * 2;
                }
            }
            if (sum % 10 == 0)
                return true;
            return false;
        }

        public static string GenerateUsername()
        {
            Random r = new Random();
            while (true)
            {
                string username = "user" + r.Next(0, 9999);
                if (dbFunctions.IsUsernameUnique(username)) return username;
            }
        }
        public static string GeneratePassword()
        {
            Random r = new Random();
            return  r.Next(1000, 9999).ToString() + r.Next(1000, 9999).ToString();
        }
        //public static bool SendEmail(string originEmail, string destinationEmail, string message,string subject)
        //{
        //    // Configure the SMTP client
        //    SmtpClient client = new SmtpClient(" smtp.gmail.com", 465); // Replace with your SMTP server and port
        //    client.EnableSsl = true; // Enable SSL if required
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new NetworkCredential("mohammadmahdisharafbayani@gmail.com", "090244788611651382"); // Replace with your email credentials

        //    // Create the email message
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress(originEmail);
        //    mail.To.Add(new MailAddress(destinationEmail));
        //    mail.Subject = subject;
        //    mail.Body = message;


        //    try
        //    {
        //        client.Send(mail);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public static bool SendEmail(string recipientEmail, string subject, string body)
        {

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
            email.To.Add(new MailboxAddress("Receiver Name", "receiver@email.com"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<b>Hello all the way from the land of C#</b>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("smtp_username", "smtp_password");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }



    //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    //        smtpClient.EnableSsl = true;
    //        smtpClient.UseDefaultCredentials = false;

    //        // Set up your Gmail credentials
    //        string senderEmail = "mohammadmahdisharafbayani@gmail.com";
    //        string senderPassword = "090244788611651382";

    //        // Set up sender's email address and password
    //        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

    //        // Create a new email message
    //        MailMessage mailMessage = new MailMessage();
    //        mailMessage.From = new MailAddress(senderEmail);
    //        mailMessage.To.Add(recipientEmail);
    //        mailMessage.Subject = subject;
    //        mailMessage.Body = body;

           
    //            smtpClient.Send(mailMessage);
    //            return true;
    //        //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
       }

    }

}
