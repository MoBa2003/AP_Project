﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class Customer
    {
        public int? Id { get; set; }

        public string National_Code;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       
        public string PhoneNumber { get; set; }

        public double Wallet;

        public string? UserName;

        public string? Password;

        public Customer(int? id, string national_Code, string firstName, string lastName, string email, string phoneNumber, double wallet, string? userName, string? password)
        {
            Id = id;
            National_Code = national_Code;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Wallet = wallet;
            UserName = userName;
            Password = password;
        }



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



    }
}
