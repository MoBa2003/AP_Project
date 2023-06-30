

using MainProject.Controller;
using MainProject.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using CustomMessageBox;



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
            
            // Employee employee = new Employee(null, NumericTextBox.Text, txt_firstname.Text, txt_lastname.Text, txt_Email.Text, txt_username.Text, txt_password.Password);
            ////MessageBox.Show(dbFunctions.SignUp_Employee(employee).ToString());
            // new CustomMessageBox.MessageBoxCustom(dbFunctions.SignUp_Employee(employee).ToString(), CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).Show();
           
        }
    }
}
