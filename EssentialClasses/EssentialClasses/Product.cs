using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EssentialClasses
{
    public enum TypeOfPackage
    {
        Object,
        Document,
        Breakable
    }
    public enum TypeOfDelivery
    {
        Normal,
        Special
    }
    public enum Status
    {
        Registered,
        ReadyToGO,
        OnTheWay,
        Delivered
    }
    public class Product
    {
        public static List<Product> Products = new List<Product>();
        Customer customer;
        public TypeOfPackage typeOfPackage;
        public TypeOfDelivery typeOfDelivery;
        public Status status;
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsExpensive { get; set; }
        public double Weight { get; set; }
        public double FinalPrice { get; set; }

        public Product(Customer customer, TypeOfPackage typeOfPackage, TypeOfDelivery typeOfDelivery, Status status, string addr, string adds, bool b, double weight, string? phonenumber = null)
        {
            this.customer = customer;
            this.typeOfPackage = typeOfPackage;
            this.typeOfDelivery = typeOfDelivery;
            this.status = status;
            this.Origin = addr;
            this.Destination = adds;
            this.PhoneNumber = phonenumber;
            this.Weight = weight;
            this.IsExpensive = b;
            Products.Add(this);
        }

    }
}
