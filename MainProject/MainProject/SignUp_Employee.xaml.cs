

using MainProject.Controller;
using MainProject.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;


namespace MainProject
{
    /// <summary>
    /// Interaction logic for SignUp_Employee.xaml
    /// </summary>
    public partial class SignUp_Employee : Window
    {
        public SignUp_Employee()
        {
            InitializeComponent();
        }
        private void border_MouseDown(object seneder,MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the input is a numeric value (you can add support for decimal separator if needed)
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true; // Mark the event as handled to prevent the character from being entered
                
            }
        }

        private bool IsTextNumeric(string text)
        {
            // Modify the regex pattern to support decimal separator or negative numbers if needed
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            firstname_err.Content = "";
            lastname_err.Content = "";
            personnelnumber_err.Content = "";
            Email_err.Content = "";
            username_err.Content = "";
            pass_err.Content = "";
            passrepeat_err.Content = "";
            txt_firstname.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            txt_lastname.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            NumericTextBox.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            txt_Email.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            txt_username.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            txt_password.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            txt_repeatPassword.BorderBrush = new SolidColorBrush(Colors.WhiteSmoke);
            bool IsValid = true;
            if (string.IsNullOrEmpty(txt_firstname.Text) && !txt_firstname.Text.NameValidate())
            {
                firstname_err.Content = "Firstname Invalid";
                txt_firstname.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txt_lastname.Text) && !txt_lastname.Text.NameValidate())
            {
                lastname_err.Content = "Lastname Invlaid";
                txt_lastname.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (!UInt64.TryParse(NumericTextBox.Text, out var num) && !NumericTextBox.Text.SSNValidate())
            {
                personnelnumber_err.Content = "Personnel Number Invalid";
                NumericTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txt_Email.Text) && !txt_Email.Text.EmailValidate())
            {
                Email_err.Content = "Email Invalid";
                txt_Email.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txt_username.Text))//use validate here
            {
                username_err.Content = "Username Invalid";
                txt_username.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txt_password.Password) && !txt_password.Password.PassWordValidate())
            {
                pass_err.Content = "Password Invalid";
                txt_password.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (string.IsNullOrEmpty(txt_repeatPassword.Password) && !txt_repeatPassword.Password.PassWordValidate())
            {
                passrepeat_err.Content = "PasswordRepeat Invalid";
                txt_repeatPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                IsValid = false;
            }
            else if (txt_password.Password != txt_repeatPassword.Password)
            {
                passrepeat_err.Content = "Does Not Match The Password";
                IsValid = false;
            }

            if (IsValid)
            {
                Employee emp = new Employee(1, NumericTextBox.Text, txt_firstname.Text, txt_lastname.Text, txt_Email.Text, txt_username.Text, txt_password.Password);
                Employee.employees.Add(emp);
                var LoginPanel = new LoginForm();
                this.Close();
                LoginPanel.ShowDialog();
            }

            // Employee employee = new Employee(null, NumericTextBox.Text, txt_firstname.Text, txt_lastname.Text, txt_Email.Text, txt_username.Text, txt_password.Password);
            ////MessageBox.Show(dbFunctions.SignUp_Employee(employee).ToString());
            // new CustomMessageBox.MessageBoxCustom(dbFunctions.SignUp_Employee(employee).ToString(), CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).Show();

        }
    }
}
