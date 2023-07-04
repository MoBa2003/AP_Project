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
            Username_err.Content = "";
            password_err.Content = "";
            txtUser.BorderBrush = new SolidColorBrush(Colors.DarkGray);
            txtPass.BorderBrush = new SolidColorBrush(Colors.DarkGray);
            bool IsValid = true;
            if (string.IsNullOrEmpty(txtUser.Text))//check if it exist check if it is valid
            {
                Username_err.Content = "Username Invalid";
                txtUser.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txtPass.Password))
            {
                password_err.Content = "Password Invalid";
                txtPass.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }

            if (IsValid)
            {
                foreach (var employee in Employee.employees)
                {
                    if (txtUser.Text == employee.UserName && txtPass.Password == employee.Password)
                    {
                        var empPanel = new EmployeePanel(employee);
                        this.Close();
                        empPanel.ShowDialog();


                    }
                }
                foreach (var customer in Customer.customers)
                {
                    if (txtUser.Text == customer.UserName && txtPass.Password == customer.Password)
                    {
                        var custPanel = new CustomerPanel(customer);
                        this.Close();
                        custPanel.ShowDialog();

                    }
                }
            }

            //Employee em = dbFunctions.getEmployeeByUsernamePassword(txtUser.Text, txtPass.Password);
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
    }
}
