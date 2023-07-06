using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public enum ContentType
    {
        Object=0,
        Document=1,
        Breakable=2
    }
    public enum TypeOfDelivery
    {
        Ordinary=0,
        Swift=1
    }
    public enum Status
    {
        Registered=0,
        Ready_To_Send=1,
        Sending=2,
        Delivered=3
    }
    public class Product
    {
      

        public int? Id;
       public string Sender_National_code;
        public string Sender_Address { get; set; }
        public string Receiver_address { get; set; }
        public ContentType ContentType;
        public bool Has_Expensive_object { get; set; }
        public double Weight { get; set; }

        public TypeOfDelivery typeOfDelivery;
        public double Price { get; set; }

        public Status status;

        public string? Customer_comment;
        public string? ReceiverPhoneNumber;

        public Product(int? id,string sender_national_code,string sender_address,string receiver_address , ContentType contenttype,bool has_expensive_object,double weight, TypeOfDelivery typeOfdelivery,double price, Status status,string? customer_comment, string? phonenumber = null)
        {
            this.Id = id;
            this.Sender_National_code = sender_national_code;
            this.Sender_Address = sender_address;

            this.Receiver_address = receiver_address;
            this.ContentType = contenttype;
            this.Has_Expensive_object = has_expensive_object;
            this.Weight = weight;
            this.typeOfDelivery = typeOfdelivery;
            this.Price = price;
            this.status = status;
            this.Customer_comment = customer_comment;
            this.ReceiverPhoneNumber = phonenumber;

        }
        public static double calculatePrice(ContentType contenttype,bool hasexpensiveobject,double weight,TypeOfDelivery deliverytype)
        {
            double first_price = 10;
            double zarib = 1;
            if (contenttype == ContentType.Document)zarib += 0.5;
            else if (contenttype == ContentType.Breakable)zarib += 1;
            if (hasexpensiveobject == true) zarib += 2;
            zarib += ((weight - 0.5) / 0.5) * 1.2;
            if (deliverytype == TypeOfDelivery.Swift) zarib += 1.5;
            return first_price * zarib;

        }

    }
}
