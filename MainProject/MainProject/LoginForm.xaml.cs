using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainProject.Controller;
using MainProject.Models;
using Npgsql;
using CustomMessageBox;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

           

            Employee employee = dbFunctions.getEmployeeByUsernamePassword(txtUser.Text, txtPass.Password);
            if (employee == null)
            {
                Customer customer =dbFunctions.getCustomerByUsernamePassword(txtUser.Text, txtPass.Password);
                if (customer == null)
                {
                    new MessageBoxCustom("We don`t have such user in our db", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    CustomerPanel customerpanel = new CustomerPanel();
                    customerpanel.getCustomer(customer);
                    customerpanel.Show();
                    this.Close();
                }

            }
            else
            {
                EmployeePanel employeepanel = new EmployeePanel();
                employeepanel.getemployee(employee);
                employeepanel.Show();
                this.Close();
            }
            //MessageBox.Show(em.Email);

            //dbConnection connection = new dbConnection();
            //NpgsqlDataReader reader = connection.ExecuteQuery($"select * from tbl_employee where username='{txtUser.Text}' and password='{txtPass.Password}'");
            //MessageBox.Show(reader.Read().ToString());
            ////Employee result = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
            ////reader.Close();

        }

        private void btn_signupemployee_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            SignUp_Employee window = new SignUp_Employee();
            window.Show();
            this.Close();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUser.Text == "") btnLogin.IsEnabled = false;
            else
            {
                if (txtPass.Password != "") btnLogin.IsEnabled = true;
            }
        }

      

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password == "") btnLogin.IsEnabled = false;
            else
            {
                if (txtUser.Text != "") btnLogin.IsEnabled = true;
            }
        }
    }
}
