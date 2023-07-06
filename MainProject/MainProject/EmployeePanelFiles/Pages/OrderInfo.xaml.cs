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
    /// Interaction logic for OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Page
    {
        public bool IsEmployee;
        public Customer ActiveCustomer;

        bool Id_warning = false;
        Product order;


        public OrderInfo()
        {
            InitializeComponent();
        }
        private void ResetPage()
        {
            txt_sender_national_code.Text = "";
            txt_receiver_phone_number.Text = "";
            txt_sender_address.Text = "";
            txt_receiver_address.Text = "";
            txt_weight.Text = "";
            txt_Customer_comment.Text = "";
            txt_Customer_comment.IsReadOnly = true;
            combo_contenttype.SelectedItem = null;
            combo_typeofdelivery.SelectedItem = null;
            checkbox_has_expensive_object.IsChecked = false;

            radio_Registered.IsEnabled = false;
            radio_ReadytoSend.IsEnabled = false;
            radio_Sending.IsEnabled = false;
            radio_Delivered.IsEnabled = false;
            radio_Registered.IsChecked = false;
            radio_ReadytoSend.IsChecked = false;
            radio_Sending.IsChecked = false;
            radio_Delivered.IsChecked = false;

            btn_update.Visibility = Visibility.Hidden;

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txt_sender_national_code.IsReadOnly = true;
            txt_receiver_phone_number.IsReadOnly = true;
            txt_sender_address.IsReadOnly = true;
            txt_receiver_address.IsReadOnly = true;
            txt_weight.IsReadOnly = true;
            txt_Customer_comment.IsReadOnly = true;
            checkbox_has_expensive_object.IsEnabled = false;
            combo_contenttype.IsEnabled = false;
            combo_typeofdelivery.IsEnabled = false;

                radio_Registered.IsEnabled = false;
                radio_ReadytoSend.IsEnabled = false;
                radio_Sending.IsEnabled = false;
                radio_Delivered.IsEnabled = false;

            btn_update.Visibility = Visibility.Hidden;
          


        }

        private void txt_Id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!isNumbericText(txt_Id.Text)) e.Handled = true;
        }

        private bool isNumbericText(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            ResetPage();
            try
            {
                if (Id_warning == true)
                {
                    lbl_id_warning.Text = "empty!!!";
                    lbl_id_warning.Visibility = Visibility.Visible;
                }
                else
                {
                    order = dbFunctions.getOrderById(int.Parse(txt_Id.Text));
                    if (order != null)
                    {
                        if (IsEmployee == true || (IsEmployee == false && order.Sender_National_code == ActiveCustomer.National_Code))
                        {
                            txt_sender_national_code.Text = order.Sender_National_code;
                            txt_receiver_phone_number.Text = order.ReceiverPhoneNumber;
                            txt_sender_address.Text = order.Sender_Address;
                            txt_receiver_address.Text = order.Receiver_address;
                            txt_weight.Text = order.Weight.ToString();
                            combo_contenttype.SelectedIndex = (int)order.ContentType;
                            combo_typeofdelivery.SelectedIndex = (int)order.typeOfDelivery;
                            checkbox_has_expensive_object.IsChecked = order.Has_Expensive_object;
                            if (order.status == Status.Registered) radio_Registered.IsChecked = true;
                            else if (order.status == Status.Ready_To_Send) radio_ReadytoSend.IsChecked = true;
                            else if (order.status == Status.Sending) radio_Sending.IsChecked = true;
                            else radio_Delivered.IsChecked = true;
                            if (order.Customer_comment != null) txt_Customer_comment.Text = order.Customer_comment;

                            if (IsEmployee&&order.status!=Status.Delivered)
                            {
                                radio_Registered.IsEnabled = true;
                                radio_ReadytoSend.IsEnabled = true;
                                radio_Sending.IsEnabled = true;
                                radio_Delivered.IsEnabled = true;
                                btn_update.Visibility = Visibility.Visible;
                                btn_update.Content = "Update Status";
                            }
                            else if(IsEmployee==false&&(order.Customer_comment==null||order.Customer_comment==""))
                            {
                                if (radio_Delivered.IsChecked == true && (order.Customer_comment == null || order.Customer_comment == ""))
                                {
                                    txt_Customer_comment.IsReadOnly = false;
                                    btn_update.Visibility = Visibility.Visible;
                                    btn_update.Content = "Update Customer Comment";
                                }
                            }
                        }
                        else
                        {
                            lbl_id_warning.Text = "you don`t have access to this Order";
                            lbl_id_warning.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        lbl_id_warning.Text = "this id does not exist";
                        lbl_id_warning.Visibility = Visibility.Visible;
                    }
                }
            }
            catch
            {
                new CustomMessageBox.MessageBoxCustom("an Error Occured",CustomMessageBox.MessageType.Error,CustomMessageBox.MessageButtons.Ok).ShowDialog();
            }

        }

        private void txt_Id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Id.Text == "")
            {
                lbl_id_warning.Text = "empty!!!";
                lbl_id_warning.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_id_warning.Visibility = Visibility.Hidden;
            }
        }

        private void txt_Id_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_id_warning.Visibility == Visibility.Hidden) Id_warning = false;
            else
            {
                lbl_id_warning.Visibility = Visibility.Hidden;
                Id_warning=true;
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (IsEmployee)
            {
                    Status newstatus = Status.Registered;
                    if (radio_Registered.IsChecked == true) newstatus = Status.Registered;
                    else if (radio_ReadytoSend.IsChecked == true) newstatus = Status.Ready_To_Send;
                    else if (radio_Sending.IsChecked == true) newstatus = Status.Sending;
                    else if (radio_Delivered.IsChecked == true) newstatus = Status.Delivered;
                if (!dbFunctions.UpdateOrderStatus((int)order.Id, newstatus))
                    new CustomMessageBox.MessageBoxCustom("an Error Occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                else new CustomMessageBox.MessageBoxCustom("Status Changed Successfully", CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).ShowDialog();
               
            }
            else
            {

                if (!dbFunctions.UpdateOrderCustomerComment((int)order.Id, txt_Customer_comment.Text))
                    new CustomMessageBox.MessageBoxCustom("an Error Occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                else new CustomMessageBox.MessageBoxCustom("Customer Comment Changed Successfully", CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.Ok).ShowDialog();
            }
        }
    }
}
