using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Models;
using Npgsql;


namespace MainProject.Controller
{
    internal class dbFunctions
    {

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


    }
}
