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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!UInt64.TryParse(txt_phone.Text, out var phoneNumber))
            {
                Phonenumber_err.Content = "Invalid Entry";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            firstname_err.Content = "";
            lastname_err.Content = "";
            code_err.Content = "";
            email_err.Content = "";
            Phonenumber_err.Content = "";

            if (string.IsNullOrEmpty(txt_firstname.Text))
            {
                firstname_err.Content = "Firstname Empty";
            }
            else if (string.IsNullOrEmpty(txt_lastname.Text))
            {
                lastname_err.Content = "Lastname Empty";
            }
            else if(string.IsNullOrEmpty(txt_code.Text))
            {
                code_err.Content = "NationalCode Empty";
            }
            else if(string.IsNullOrEmpty(txt_email.Text))
            {
                email_err.Content = "Email Empty";
            }
            else if(!UInt64.TryParse(txt_phone.Text, out var phoneNumber))
            {
                Phonenumber_err.Content = "Phonenumber Empty";
            }
        }
    }
}
