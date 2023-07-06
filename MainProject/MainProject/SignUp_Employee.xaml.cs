

using MainProject.Controller;
using MainProject.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using CustomMessageBox;
using MaterialDesignThemes.Wpf;



namespace MainProject
{
    /// <summary>
    /// Interaction logic for SignUp_Employee.xaml
    /// </summary>
    public partial class SignUp_Employee : Window
    {

        bool fname_authorized = false;
        bool lname_authorized = false;
        bool personnelnumber_authorized = false;
        bool email_authorized = false;
        bool username_authorized = false;
        bool password_authorized = false;
        bool repeat_password_authorized = false;


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
            LoginForm lg = new LoginForm();
            lg.Show();
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

       

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            if (fname_authorized == false)
            {
                lbl_firstname_warning.Visibility = Visibility.Visible;
            }
            if (lname_authorized == false)
            {
                lbl_lasttname_warning.Visibility = Visibility.Visible;
            }
            if (personnelnumber_authorized == false)
            {
                lbl_Personnelbumber_warning.Visibility = Visibility.Visible;
            }
            if (email_authorized == false)
            {
                lbl_email_warning.Visibility = Visibility.Visible;
            }
            if (username_authorized == false)
            {
                lbl_username_warning.Visibility = Visibility.Visible;
            }
            if (password_authorized == false)
            {
                lbl_password_warning.Visibility = Visibility.Visible;
            }
            if (repeat_password_authorized == false)
            {
                lbl_repeatpassword_warning.Visibility = Visibility.Visible;
            }
            if (fname_authorized == true && lname_authorized == true && personnelnumber_authorized == true && email_authorized == true && username_authorized == true && password_authorized == true && repeat_password_authorized == true)
            {
                try {
                    Employee employee = new Employee(null, NumericTextBox.Text, txt_firstname.Text, txt_lastname.Text, txt_Email.Text, txt_username.Text, txt_password.Password);
                    dbFunctions.SignUp_Employee(employee);
                    new CustomMessageBox.MessageBoxCustom("Employee Signed Up Successfully", CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                    LoginForm lg = new LoginForm();
                    lg.Show();
                    this.Close();
                }
                catch
                {
                    new MessageBoxCustom("an Error occured, try again", MessageType.Error, MessageButtons.Ok);
                }
                }
        }

        private void txt_firstname_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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

        private void txt_lastname_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txt_lastname.Text == "")
            {
                lbl_lasttname_warning.Text = "empty!!!";
                lbl_lasttname_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.NameValidate(txt_lastname.Text))
                {
                    lbl_lasttname_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_lasttname_warning.Text = "name should be 3-32 letters";
                    lbl_lasttname_warning.Visibility = Visibility.Visible;
                }
            }
        }
        private void txt_lastname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_lasttname_warning.Visibility == Visibility.Hidden) lname_authorized = true;
            else
            {
                lbl_lasttname_warning.Visibility = Visibility.Hidden;
                lname_authorized = false;
            }
        }

        private void NumericTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (NumericTextBox.Text == "")
            {
                lbl_Personnelbumber_warning.Text = "empty!!!";
                lbl_Personnelbumber_warning.Visibility = Visibility.Visible;
            }
            else
            {
              
                if (ValidationClass.SSNValidate(NumericTextBox.Text))
                {
                    if (dbFunctions.isPersonnelNumberUnique(NumericTextBox.Text))
                    {
                        lbl_Personnelbumber_warning.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lbl_Personnelbumber_warning.Text = "already taken";
                        lbl_Personnelbumber_warning.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    lbl_Personnelbumber_warning.Text = "Personnel number should be in this format : --9--";
                    lbl_Personnelbumber_warning.Visibility = Visibility.Visible;
                }
               
            }
        }

        private void NumericTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_Personnelbumber_warning.Visibility == Visibility.Hidden) personnelnumber_authorized = true;
            else
            {
                lbl_Personnelbumber_warning.Visibility = Visibility.Hidden;
                personnelnumber_authorized = false;
            }
        }

        private void txt_Email_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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
                    lbl_email_warning.Text = "wrong email";
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

        private void txt_username_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (txt_username.Text == "")
            {
                lbl_username_warning.Text = "empty!!!";
                lbl_username_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (dbFunctions.IsUsernameUnique(txt_username.Text))
                {
                      lbl_username_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_username_warning.Text = "already taken";
                    lbl_username_warning.Visibility = Visibility.Visible;
                }
                //if (ValidationClass.(txt_Email.Text))
                //{
                //}
                //else
                //{
                //    lbl_email_warning.Text = "wrong email";
                //    lbl_email_warning.Visibility = Visibility.Visible;
                //}
            }
        }
        private void txt_username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_username_warning.Visibility == Visibility.Hidden) username_authorized = true;
            else
            {
                lbl_username_warning.Visibility = Visibility.Hidden;
                username_authorized = false;
            }
        }

        private void txt_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txt_password.Password == "")
            {
                lbl_password_warning.Text = "empty!!!";
                lbl_password_warning.Visibility = Visibility.Visible;
                txt_repeatPassword.IsEnabled = false;

            }
            else
            {
                if (ValidationClass.validateEmployeePassword(txt_password.Password))
                {
                    lbl_password_warning.Visibility = Visibility.Hidden;
                    txt_repeatPassword.IsEnabled = true;
                }
                else
                {
                    lbl_password_warning.Text = "invalid password";
                    lbl_password_warning.Visibility = Visibility.Visible;
                    txt_repeatPassword.IsEnabled = false;
                }
            }
        }


        private void txt_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_password_warning.Visibility == Visibility.Hidden) password_authorized = true;
            else
            {
                lbl_password_warning.Visibility = Visibility.Hidden;
                password_authorized = false;
            }
        }

        private void txt_repeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txt_repeatPassword.Password == "")
            {
                lbl_repeatpassword_warning.Text = "empty!!!";
                lbl_repeatpassword_warning.Visibility = Visibility.Visible;

            }
            else
            {
                if (txt_repeatPassword.Password==txt_password.Password)
                {
                    lbl_repeatpassword_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_repeatpassword_warning.Text = "not matched";
                    lbl_repeatpassword_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_repeatPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if(lbl_repeatpassword_warning.Visibility == Visibility.Hidden) repeat_password_authorized = true;
            else
            {
                lbl_repeatpassword_warning.Visibility = Visibility.Hidden;
                repeat_password_authorized = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_firstname_warning.Visibility = Visibility.Hidden;
            lbl_lasttname_warning.Visibility = Visibility.Hidden;
            lbl_Personnelbumber_warning.Visibility = Visibility.Hidden;
            lbl_email_warning.Visibility = Visibility.Hidden;
            lbl_username_warning.Visibility = Visibility.Hidden;
            lbl_password_warning.Visibility = Visibility.Hidden;
            lbl_repeatpassword_warning.Visibility = Visibility.Hidden;
            txt_repeatPassword.IsEnabled = false;
            lbl_firstname_warning.Text = "empty!!!";
            lbl_lasttname_warning.Text = "empty!!!";
            lbl_Personnelbumber_warning.Text = "empty!!!";
            lbl_email_warning.Text = "empty!!!";
            lbl_username_warning.Text = "empty!!!";
            lbl_password_warning.Text = "empty!!!";
            lbl_repeatpassword_warning.Text = "empty!!!";


        }


    }
}
