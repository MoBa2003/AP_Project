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
using MainProject.Models;
using MainProject.Controller;

namespace MainProject.EmployeePanelFiles.Pages
{
    /// <summary>
    /// Interaction logic for ChangeUserPass.xaml
    /// </summary>
    public partial class ChangeUserPass : Page
    {
        public Customer activeCustomer;

        bool newusername_authorized;
        bool newpassword_authorized;

        public ChangeUserPass()
        {
            InitializeComponent();
        }

        private void txt_newusername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_newusername.Text == "")
            {
                lbl_newusername_warning.Text = "empty!!!";
                lbl_newusername_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (txt_newusername.Text == activeCustomer.UserName)
                {
                    lbl_newusername_warning.Text = "same as old username";
                    lbl_newusername_warning.Visibility = Visibility.Visible;
                }
                else
                {
                    if (dbFunctions.IsUsernameUnique(txt_newusername.Text))
                    {
                        lbl_newusername_warning.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lbl_newusername_warning.Text = "already taken";
                        lbl_newusername_warning.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void txt_newusername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_newusername_warning.Visibility == Visibility.Hidden) newusername_authorized = true;
            else
            {
                lbl_newusername_warning.Visibility = Visibility.Hidden;
                newusername_authorized = false;
            }
        }

        private void txt_newpassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_newpassword.Text == "")
            {
                lbl_newpassword_warning.Text = "empty!!!";
                lbl_newpassword_warning.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_newpassword_warning.Visibility = Visibility.Hidden;
            }
        }

        private void txt_newpassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_newpassword_warning.Visibility == Visibility.Hidden) newpassword_authorized = true;
            else
            {
                lbl_newpassword_warning.Visibility = Visibility.Hidden;
                newpassword_authorized = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (newusername_authorized && newpassword_authorized){
                if (dbFunctions.UpdateCustomerUserPass(activeCustomer.National_Code,txt_newusername.Text, txt_newpassword.Text))
                {
                    activeCustomer.UserName = txt_newusername.Text;
                    activeCustomer.Password = txt_newpassword.Text;
                    new CustomMessageBox.MessageBoxCustom("your info updated successfully",CustomMessageBox.MessageType.Success,CustomMessageBox.MessageButtons.Ok).ShowDialog();

                }
                else
                {
                    new CustomMessageBox.MessageBoxCustom("an Error occured, try again",CustomMessageBox.MessageType.Error,CustomMessageBox.MessageButtons.Ok).ShowDialog();
                }
            }
            else
            {
                if (!newusername_authorized) lbl_newusername_warning.Visibility = Visibility.Visible;
                else lbl_newpassword_warning.Visibility = Visibility.Visible;
            }
        }
    }
}
