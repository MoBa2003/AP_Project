using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainProject.Models;
using MainProject.Controller;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {

       bool fname_authorized = false;
        bool lname_authorized = false;
        bool national_code_authorized = false;
        bool email_authorized = false;
        bool phone_number_authorized = false;

        public Home()
        {
            InitializeComponent();
        }

        private void txt_firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_firstname.Text == "")
            {
                lbl_firstname_warning.Text = "empty!!!";
                lbl_firstname_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.NameValidate(txt_firstname.Text))
                {
                    lbl_firstname_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_firstname_warning.Text = "name should be 3-32 letters";
                    lbl_firstname_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_firstname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_firstname_warning.Visibility == Visibility.Hidden) fname_authorized = true;
            else
            {
                lbl_firstname_warning.Visibility = Visibility.Hidden;
                fname_authorized = false;
             }
        }

        private void txt_lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_lastname.Text == "")
            {
                lbl_lastname_warning.Text = "empty!!!";
                lbl_lastname_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.NameValidate(txt_lastname.Text))
                {
                    lbl_lastname_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_lastname_warning.Text = "name should be 3-32 letters";
                    lbl_lastname_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_lastname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_lastname_warning.Visibility == Visibility.Hidden) lname_authorized = true;
            else
            {
                lbl_lastname_warning.Visibility = Visibility.Hidden;
                lname_authorized = false;
            }
        }

        private void txt_nationalcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_nationalcode.Text == "")
            {
                lbl_nationalcode_warning.Text = "empty!!!";
                lbl_nationalcode_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.IDValidate(txt_nationalcode.Text))
                {
                    if (dbFunctions.isNationalCodeUnique(txt_nationalcode.Text))
                    {
                        lbl_nationalcode_warning.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lbl_nationalcode_warning.Text = "already taken";
                        lbl_nationalcode_warning.Visibility = Visibility.Visible;
                    }
                }

                else
                {
                    lbl_nationalcode_warning.Text = "invalid national code";
                    lbl_nationalcode_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_nationalcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_nationalcode_warning.Visibility == Visibility.Hidden) national_code_authorized = true;
            else
            {
                lbl_nationalcode_warning.Visibility = Visibility.Hidden;
                national_code_authorized = false;
            }
        }

        private void txt_Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Email.Text == "")
            {
                lbl_email_warning.Text = "empty!!!";
                lbl_email_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.EmailValidate(txt_Email.Text))
                {
                        lbl_email_warning.Visibility = Visibility.Hidden;
                }

                else
                {
                    lbl_email_warning.Text = "invalid email";
                    lbl_email_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_email_warning.Visibility == Visibility.Hidden) email_authorized = true;
            else
            {
                lbl_email_warning.Visibility = Visibility.Hidden;
                email_authorized = false;
            }
        }

        private void txt_phonenumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_phonenumber.Text == "")
            {
                lbl_phonenumber_warning.Text = "empty!!!";
                lbl_phonenumber_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.PhoneValidate(txt_phonenumber.Text))
                {
                    lbl_phonenumber_warning.Visibility = Visibility.Hidden;
                }

                else
                {
                    lbl_phonenumber_warning.Text = "invalid phone number";
                    lbl_phonenumber_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_phonenumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_phonenumber_warning.Visibility == Visibility.Hidden) phone_number_authorized = true;
            else
            {
                lbl_phonenumber_warning.Visibility = Visibility.Hidden;
                phone_number_authorized = false;
            }
        }

       

        private void txt_nationalcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsTextNumeric(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void txt_phonenumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fname_authorized == false)
            {
                lbl_firstname_warning.Visibility = Visibility.Visible;
            }
            if (lname_authorized == false)
            {
                lbl_lastname_warning.Visibility = Visibility.Visible;
            }
            if (national_code_authorized == false)
            {
                lbl_nationalcode_warning.Visibility = Visibility.Visible;
            }
            if (email_authorized == false)
            {
                lbl_email_warning.Visibility = Visibility.Visible;
            }
            if (phone_number_authorized == false)
            {
                lbl_phonenumber_warning.Visibility = Visibility.Visible;
            }
            if (fname_authorized == true && lname_authorized == true && national_code_authorized == true && email_authorized == true && phone_number_authorized == true)
            {
                string generatedUsername = ValidationClass.GenerateUsername();
                string generatedPassword = ValidationClass.GeneratePassword();
                Customer customer = new Customer(null, txt_nationalcode.Text, txt_firstname.Text, txt_lastname.Text, txt_Email.Text, txt_phonenumber.Text, 0, generatedUsername, generatedPassword);
                if (dbFunctions.SignUp_Customer(customer))
                {
                    new CustomMessageBox.MessageBoxCustom("Customer Signed up successfully", CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                    ValidationClass.SendEmail(customer.Email,"Welcome",$"username : {customer.UserName}\nPassword : {customer.Password}");
                }
                else
                {
                    new CustomMessageBox.MessageBoxCustom("an Error occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                }
            }

        }
    }
}
