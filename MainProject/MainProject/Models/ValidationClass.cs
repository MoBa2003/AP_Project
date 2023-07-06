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
using CsvHelper;
using System.Globalization;
using System.Windows.Controls;
using System.Collections;
using System.Data;

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

        public static bool IsCardValid(string creditCardNumber)
        {

            int sum = 0;
            bool alternate = false;

            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(creditCardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = (digit % 10) + 1;
                    }
                }

                sum += digit;
                alternate = !alternate;
            }

            return (sum % 10 == 0);


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
            return r.Next(1000, 9999).ToString() + r.Next(1000, 9999).ToString();
        }
      
        public static bool SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;


                string senderEmail = "mohammadmahdisharafbayani@gmail.com";
                string senderPassword = "mxvzdmyjtybbxqwv";


                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);


                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(senderEmail);
                mailMessage.To.Add(recipientEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;


                smtpClient.Send(mailMessage);
                return true;
            }
            catch { return false; }
        }

        public static void SaveDataGridToCsv(List<Product> orders, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(orders);
            }
        }
        public static void SaveDataTableToCsv(DataTable dataTable, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Append the column names to the CSV content
            foreach (DataColumn column in dataTable.Columns)
            {
                csvContent.Append(column.ColumnName);
                csvContent.Append(",");
            }
            csvContent.AppendLine();

            // Append the data rows to the CSV content
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    csvContent.Append(item.ToString());
                    csvContent.Append(",");
                }
                csvContent.AppendLine();
            }

            // Write the CSV content to the file
            File.WriteAllText(filePath, csvContent.ToString());
        }
    }
}


   


    

