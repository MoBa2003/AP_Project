using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EssentialClasses
{
    public static class ValidationClass
    {
        public static bool NameValidate(this string name)
        {
            Regex regex = new Regex("^[A-Za-z]{3,32}$");
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

        public static void IDValidate(this string id)
        {
            Regex regex = new Regex("^00[0-9]{8}$");
            if (!regex.IsMatch(id)) throw new Exception("Invalid SSN!");
            
        }
        public static void SSNValidate(this string ssn)
        {
            Regex regex = new Regex("^[0-9]{2}9[0-9]{2}$");
            if (!regex.IsMatch(ssn)) throw new Exception("Invalid ID!");
           
        }
        //public static void UserNameValidate(this string id)
        //{
        //    foreach (var emp in Employee.employees) if (emp.UserName == id) throw new Exception("This Username is already in use!");
        //    foreach (var emp in Customer.customers) if (emp.UserName == id) throw new Exception("This Username is already in use!");
        //}

        public static bool PhoneValidate(this string s)
        {
            Regex regex = new Regex("^09[0-9]{9}$");
            if (regex.IsMatch(s)) return true;
            return false;
        }

        public static bool CVV_Validate(this string s)
        {
            Regex regex = new Regex("^[0-9]{3,4}$");
            if (regex.IsMatch(s)) return true;
            return false;
        }

        public static bool IsExpired(this DateTime date)
        {
            DateTime now = DateTime.Now;
            if (date.CompareTo(now) < 0) return true;
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
            if (sum % 10 == 0) return true;
            return false;
        }

    }
}
