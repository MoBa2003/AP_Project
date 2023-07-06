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
using System.Text.RegularExpressions;

namespace MainProject.EmployeePanelFiles.Pages
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        bool sender_nationnalcode_authorized = false;
        bool receiver_phonenumber_authorized = true;
        bool sender_address_authorized = false;
        bool receiver_address_authorized = false;
        bool weight_authorized = false;
        bool content_type_authorized = false;
        bool type_of_delivery_authorized = false;

        public Order()
        {
            InitializeComponent();
        }

        private void combo_contenttype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            content_type_authorized = true;
            lbl_contenttype_warning.Visibility = Visibility.Hidden;
        }

        private void combo_typeofdelivery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type_of_delivery_authorized = true;
            lbl_typeofdelivery_warning.Visibility = Visibility.Hidden;
        }

        private void txt_sender_nationalcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_sender_nationalcode.Text == "")
            {
                lbl_senderNationalCode_warning.Text = "empty!!!";
                lbl_senderNationalCode_warning.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.IDValidate(txt_sender_nationalcode.Text))
                {
                    lbl_senderNationalCode_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_senderNationalCode_warning.Text = "invalid national code";
                    lbl_senderNationalCode_warning.Visibility = Visibility.Visible;
                }
            }
        }

        private void txt_sender_nationalcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_senderNationalCode_warning.Visibility == Visibility.Hidden) sender_nationnalcode_authorized = true;
            else
            {
                lbl_senderNationalCode_warning.Visibility = Visibility.Hidden;
                sender_nationnalcode_authorized = false;
            }
        }

        private void txt_receiver_phonenumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_receiver_phonenumber.Text == "")
            {
                lbl_receiverPhonenumber_warning.Visibility = Visibility.Hidden;
                receiver_phonenumber_authorized = true;
            }
            else
            {
                if (ValidationClass.PhoneValidate(txt_receiver_phonenumber.Text))
                {
                    //lbl_receiverPhonenumber_warning.Text = "/*invalid phone number"*/;
                    lbl_receiverPhonenumber_warning.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_receiverPhonenumber_warning.Visibility = Visibility.Visible;
                }
            }
        }
        private void txt_receiver_phonenumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if(lbl_receiverPhonenumber_warning.Visibility==Visibility.Hidden)receiver_phonenumber_authorized = true;
            else
            {
                lbl_receiverPhonenumber_warning.Visibility = Visibility.Hidden;
                receiver_phonenumber_authorized = false;
            }
        }

        private void txt_sender_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_sender_address.Text == "")
            {
                lbl_sender_address_warning.Text = "empty!!!";
                lbl_sender_address_warning.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_sender_address_warning.Visibility = Visibility.Hidden;
            }
        }

        private void txt_sender_address_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_sender_address_warning.Visibility == Visibility.Hidden) sender_address_authorized = true;
            else
            {
                lbl_sender_address_warning.Visibility = Visibility.Hidden;
                sender_address_authorized = false;
            }
        }

        private void txt_receiver_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_receiver_address.Text == "")
            {
                lbl_receiver_address_warning.Text = "empty!!!";
                lbl_receiver_address_warning.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_receiver_address_warning.Visibility = Visibility.Hidden;
            }
        }

        private void txt_receiver_address_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_receiver_address_warning.Visibility == Visibility.Hidden) receiver_address_authorized = true;
            else
            {
                lbl_receiver_address_warning.Visibility = Visibility.Hidden;
                receiver_address_authorized = false;
            }
        }

        private void txt_weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_weight.Text == "")
            {
                lbl_weight_warning.Text = "empty!!!";
                lbl_weight_warning.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_weight_warning.Visibility = Visibility.Hidden;
            }
        }

        private void txt_weight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_weight_warning.Visibility == Visibility.Hidden) weight_authorized = true;
            else
            {
                lbl_weight_warning.Visibility = Visibility.Hidden;
                weight_authorized = false;
            }
        }

        private bool IsTextNumeric(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender_nationnalcode_authorized == false) lbl_senderNationalCode_warning.Visibility = Visibility.Visible;
            if(receiver_phonenumber_authorized == false)lbl_receiverPhonenumber_warning.Visibility = Visibility.Visible;
            if(sender_address_authorized==false)lbl_sender_address_warning.Visibility = Visibility.Visible;
            if (receiver_address_authorized == false) lbl_receiver_address_warning.Visibility = Visibility.Visible;
            if (weight_authorized == false) lbl_weight_warning.Visibility = Visibility.Visible;
            if (content_type_authorized == false) lbl_contenttype_warning.Visibility = Visibility.Visible;
            if(type_of_delivery_authorized==false)lbl_typeofdelivery_warning.Visibility = Visibility.Visible;
           
            if(sender_nationnalcode_authorized == true&& receiver_phonenumber_authorized == true && sender_address_authorized == true && receiver_address_authorized == true && weight_authorized==true&& content_type_authorized==true&& type_of_delivery_authorized==true)
            {
               

              
               Customer customer =  dbFunctions.getCustomerbyNationalCode(txt_sender_nationalcode.Text);
                if (customer == null)
                {
                    new CustomMessageBox.MessageBoxCustom("there is no customer with this national code", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                }
                else
                {
                    try
                    {
                        double final_price = Product.calculatePrice((ContentType)combo_contenttype.SelectedIndex, (bool)checkbox_has_expensive_object.IsChecked, double.Parse(txt_weight.Text), (TypeOfDelivery)combo_typeofdelivery.SelectedIndex);
                        CustomMessageBox.MessageBoxCustom message = new CustomMessageBox.MessageBoxCustom($"Total Price : {final_price * 1000}", CustomMessageBox.MessageType.Info, CustomMessageBox.MessageButtons.RegisterCancel);
                        message.ShowDialog();
                        if (message.btnok_Clicked == true)
                        {
                            if (customer.Wallet >= final_price)
                            {
                                if (dbFunctions.UpdateCustomerWallet(customer.National_Code, customer.Wallet - final_price))
                                {
                                    Product order;
                                    if (txt_receiver_phonenumber.Text == "") order = new Product(null, txt_sender_nationalcode.Text, txt_sender_address.Text, txt_receiver_address.Text, (ContentType)combo_contenttype.SelectedIndex, (bool)checkbox_has_expensive_object.IsChecked, double.Parse(txt_weight.Text), (TypeOfDelivery)combo_typeofdelivery.SelectedIndex, final_price, Status.Registered, null, null);
                                    else order = new Product(null, txt_sender_nationalcode.Text, txt_sender_address.Text, txt_receiver_address.Text, (ContentType)combo_contenttype.SelectedIndex, (bool)checkbox_has_expensive_object.IsChecked, double.Parse(txt_weight.Text), (TypeOfDelivery)combo_typeofdelivery.SelectedIndex, final_price, Status.Registered, null, txt_receiver_phonenumber.Text);

                                    if (dbFunctions.RegisterOrder(order)) new CustomMessageBox.MessageBoxCustom("Registered Successfully", CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                                    else
                                    {
                                        new CustomMessageBox.MessageBoxCustom("an error occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                                        dbFunctions.UpdateCustomerWallet(customer.National_Code, customer.Wallet);
                                    }
                                }
                                else new CustomMessageBox.MessageBoxCustom("an error occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                            }
                            else
                            {
                                new CustomMessageBox.MessageBoxCustom("Insufficient Balance", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                            }
                        }
                    }
                    catch
                    {
                        new CustomMessageBox.MessageBoxCustom("an error occured", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                    }
                  
                    
                }
                
            }
        }

        private void txt_receiver_phonenumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true;
            }
        }

        private void txt_sender_nationalcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true;
            }
        }

       
    }
}
