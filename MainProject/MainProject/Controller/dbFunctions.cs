using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MainProject.Models;
using Npgsql;


namespace MainProject.Controller
{
    internal class dbFunctions
    {

        public static Product getOrderById(int id)
        {
            dbConnection connection = new dbConnection();
            NpgsqlDataReader reader =  connection.ExecuteQuery($"select * from tbl_orders where id={id}");
            if (reader.Read())
            {
                string customercomment = null;
                if (!reader.IsDBNull(10)) customercomment= reader.GetString(10);
                string customerphonenumber = null;
                if (!reader.IsDBNull(11)) customerphonenumber= reader.GetString(11);

                Product order = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), (ContentType)Enum.Parse(typeof(ContentType), reader.GetString(4),true), reader.GetBoolean(5), reader.GetDouble(6), (TypeOfDelivery)Enum.Parse(typeof(TypeOfDelivery), reader.GetString(7),true), reader.GetDouble(8), (Status)Enum.Parse(typeof(Status), reader.GetString(9),true), customercomment, customerphonenumber);
                reader.Close();
                connection.CloseTunnel();
                return order;
             
               




            }
            else {
                reader.Close();
                connection.CloseTunnel();
                return null; 
            }

        }
        public static Employee getEmployeeByUsernamePassword(string username,string password)
        {
            dbConnection connection = new dbConnection();
            NpgsqlDataReader reader =  connection.ExecuteQuery($"select * from tbl_employee where username='{username}' and password='{password}'");
            if (reader.Read()==false) return null;
            Employee result = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
            reader.Close();
            connection.CloseTunnel();
            return result;
        }
        public static bool UpdateCustomerWallet(string national_code, double wallet)
        {
            try
            {
                dbConnection connection = new dbConnection();
                connection.ExecuteNoneQuery($"update tbl_customer set wallet={wallet} where national_code='{national_code}'");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateOrderStatus(int id,Status status)
        {
            try
            {
                dbConnection connection = new dbConnection();
                connection.ExecuteNoneQuery($"update tbl_orders set status='{status.ToString().ToLower()}' where id={id}");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateOrderCustomerComment(int id, string customercomment)
        {
            try
            {
                dbConnection connection = new dbConnection();
                connection.ExecuteNoneQuery($"update tbl_orders set customer_comment='{customercomment}' where id={id}");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool UpdateCustomerUserPass(string nationalcode,string newusername,string newpassword)
        {
            try
            {
                dbConnection connection = new dbConnection();
                connection.ExecuteNoneQuery($"update tbl_customer set username='{newusername}' , password = '{newpassword}' where national_code='{nationalcode}'");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RegisterOrder(Product order)
        {
            try {
                dbConnection connection = new dbConnection();
                if (order.ReceiverPhoneNumber == null)
                {
                    connection.ExecuteNoneQuery($"insert into tbl_orders(sender_national_code,sender_address,receiver_address,content_type,has_expensive_object,weight,send_type,price,status) values ('{order.Sender_National_code}', '{order.Sender_Address}', '{order.Receiver_address}', '{order.ContentType.ToString().ToLower()}',{order.Has_Expensive_object},{order.Weight}, '{order.typeOfDelivery.ToString().ToLower()}',{order.Price}, '{order.status.ToString().ToLower()}')");

                }
               else connection.ExecuteNoneQuery($"insert into tbl_orders(sender_national_code,sender_address,receiver_address,content_type,has_expensive_object,weight,send_type,price,status,receiver_phone_number) values ('{order.Sender_National_code}', '{order.Sender_Address}', '{order.Receiver_address}', '{order.ContentType.ToString().ToLower()}',{order.Has_Expensive_object},{order.Weight}, '{order.typeOfDelivery.ToString().ToLower()}',{order.Price}, '{order.status.ToString().ToLower()}', '{order.ReceiverPhoneNumber}')");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
            }
        public static Customer getCustomerbyNationalCode(string national_code)
        {
            dbConnection connection = new dbConnection();
            NpgsqlDataReader reader = connection.ExecuteQuery($"select * from tbl_customer where national_code = '{national_code}'");
            if (reader.Read())
            {
                Customer result = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDouble(6), reader.GetString(7), reader.GetString(8));
                reader.Close();
                connection.CloseTunnel();
                return result;
            }
            else
            {
                reader.Close();
                connection.CloseTunnel();
                return null;
            }
        }
        public static Customer getCustomerByUsernamePassword(string username, string password)
        {
            dbConnection connection = new dbConnection();
            NpgsqlDataReader reader = connection.ExecuteQuery($"select * from tbl_customer where username='{username}' and password='{password}'");
            if (reader.Read() == false) return null;
            Customer result = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDouble(6),reader.GetString(7),reader.GetString(8));
            reader.Close();
            connection.CloseTunnel();
            return result;
        }
        public static bool SignUp_Employee(Employee employee)
        {
            try {
                dbConnection connection = new dbConnection();
                connection.ExecuteNoneQuery($"insert into tbl_employee(personnel_number,first_name,last_name,email,username,password) values ('{employee.PersonnelNumber}','{employee.FirstName}','{employee.LastName}','{employee.Email}','{employee.UserName}','{employee.Password}')");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
            }
        public static bool IsUsernameUnique(string username)
        {
            dbConnection connection = new dbConnection();
            NpgsqlDataReader reader =  connection.ExecuteQuery($"select * from tbl_employee where username='{username}'");
            if (reader.Read()) { reader.Close();connection.CloseTunnel(); return false; }
            else
            {
                reader.Close();
                connection.CloseTunnel();
                connection = new dbConnection();
                reader = connection.ExecuteQuery($"select * from tbl_customer where username='{username}'");
                if (reader.Read()) { reader.Close(); connection.CloseTunnel(); return false; }
                else
                {
                    reader.Close();
                    connection.CloseTunnel();
                    return true;
                }
            }
        }
        public static bool isPersonnelNumberUnique(string personnelnumber)
        {
            dbConnection connection = new dbConnection();
           NpgsqlDataReader reader  = connection.ExecuteQuery($"select * from tbl_employee where personnel_number='{personnelnumber}'");
            if (reader.Read())
            {
                reader.Close();
                connection.CloseTunnel();
                return false;
            }
            else
            {
                reader.Close();
                connection.CloseTunnel();
                return true;
            }
        }

        internal static bool isNationalCodeUnique(string nationalcode)
        {
            dbConnection connection = new dbConnection();
           NpgsqlDataReader reader = connection.ExecuteQuery($"select * from tbl_customer where national_code='{nationalcode}'");
            if(reader.Read())
            {
                reader.Close();
                connection.CloseTunnel();
                return false;
            }
            else
            {
                reader.Close();
                connection.CloseTunnel();
                return true;
            }
        }
        public static bool SignUp_Customer(Customer customer)
        {
            try {
                dbConnection connection = new dbConnection();
                connection.ExecuteNoneQuery($"insert into tbl_customer(national_code,first_name,last_name,email,phone_number,wallet,username,password) values('{customer.National_Code}','{customer.FirstName}','{customer.LastName}','{customer.Email}','{customer.PhoneNumber}',{customer.Wallet},'{customer.UserName}','{customer.Password}')");
                connection.CloseTunnel();
                return true;
            }
            catch
            {
                return false;
            }
            }
        public static DataTable QueryOnOrders(string query)
        {
            List<Product> orders = new List<Product>();
            dbConnection connection = new dbConnection();
            NpgsqlDataReader reader;
            if (query != "") reader = connection.ExecuteQuery($"select * from tbl_orders where {query}");
            else reader = connection.ExecuteQuery($"select * from tbl_orders");
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.CloseTunnel();
            return dataTable;
        }
        
    }
}
