using System;
using System.Collections.Generic;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using MainProject.Models;


namespace MainProject.EmployeePanelFiles.Pages
{
    /// <summary>
    /// Interaction logic for Wallet.xaml
    /// </summary>
    public partial class Wallet : Page
    {
        public Customer activeCustomer;

        bool cardnumber_authorized = false;
        bool cvv_authorized = false;
        bool amountauthorized = false;

        public Wallet()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cardnumber_authorized == false)
            {
                cardnumber_err.Visibility = Visibility.Visible;
             
            }
            if (dpExpirationDate.SelectedDate == null)
            {
                expdate_err.Visibility = Visibility.Visible;
            }
            if (cvv_authorized == false)
            {
                cvv_err.Visibility = Visibility.Visible;
            }
            if (amountauthorized == false)
            {
                amount_err.Visibility = Visibility.Visible;
            }
            if (cardnumber_authorized && dpExpirationDate.SelectedDate != null && cvv_authorized && amountauthorized)
            {
                try
                {
                    
                    if (MainProject.Controller.dbFunctions.UpdateCustomerWallet(activeCustomer.National_Code, activeCustomer.Wallet + (double.Parse(txtAmount.Text)/1000)))
                    {
                        string amount = txtAmount.Text;
                        DateTime tdate = DateTime.Now;
                        activeCustomer.Wallet += double.Parse(txtAmount.Text)/1000;
                        txt_wallet.Text = (activeCustomer.Wallet * 1000).ToString();
                        CustomMessageBox.MessageBoxCustom message = new CustomMessageBox.MessageBoxCustom("would you like to save Transaction?", CustomMessageBox.MessageType.Success, CustomMessageBox.MessageButtons.YesNo);
                        message.isSuccessfultransaction = true;
                        message.ShowDialog();
                        if (message.btnyes_clicked)
                        {
                            Document document = new Document();
                            string filePath = $"{tdate.Year}-{tdate.Month}-{tdate.Day}_{tdate.Hour}-{tdate.Minute}-{tdate.Second}.pdf";
                            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                            document.Open();
                            document.Add(new iTextSharp.text.Paragraph("Transaction Info"));
                            document.Add(new iTextSharp.text.Paragraph("Customer UserName: " + activeCustomer.UserName));
                            document.Add(new iTextSharp.text.Paragraph("Amount Charged: " + amount));
                            document.Add(new iTextSharp.text.Paragraph("Charge Date and Time: " + tdate.ToString()));
                            document.Add(new iTextSharp.text.Paragraph("Current Balance: " + activeCustomer.Wallet*1000));
                            document.Close();
                        }
                    }
                    else
                    {
                        new CustomMessageBox.MessageBoxCustom("an Error Occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();
                    }
                }
                catch
                {
                    new CustomMessageBox.MessageBoxCustom("an Error Occured, try again", CustomMessageBox.MessageType.Error, CustomMessageBox.MessageButtons.Ok).ShowDialog();

                }
            }

          


            //if (!UInt64.TryParse(txtCardNumber.Text, out var number))
            //{
            //    cardnumber_err.Text = "Invalid Card Number";
            //}
            //else if (string.IsNullOrEmpty(dpExpirationDate.Text))
            //{
            //    expdate_err.Text = "Pick EXP Time";
            //}
            //else if (string.IsNullOrEmpty(txtCVV.Text))
            //{
            //    cvv_err.Text = "Please Enter Card CVV";
            //}
            //else if (!UInt64.TryParse(txtAmount.Text, out var amount))
            //{
            //    amount_err.Text = "Invalid Money Amount";
            //}


        }
        //public string OpenFolderBrowserDialog()
        //{
        //    // Create a new instance of FolderBrowserDialog
           
        //    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        //    // Show the dialog and check if the user clicked the OK button
        //    DialogResult result = folderBrowserDialog.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        // Return the selected folder path
        //        return folderBrowserDialog.SelectedPath;
        //    }

        //    // Return an empty string if no folder was selected
        //    return string.Empty;
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txt_wallet.Text = (activeCustomer.Wallet*1000).ToString();
        }

        private void txtCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCardNumber.Text == "")
            {
                cardnumber_err.Text = "empty!!!";
                cardnumber_err.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.IsCardValid(txtCardNumber.Text))
                {
                    cardnumber_err.Visibility = Visibility.Hidden;
                }
                else
                {
                    cardnumber_err.Text = "invalid card number";
                    cardnumber_err.Visibility = Visibility.Visible;
                }
            }
        }

        private void txtCardNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cardnumber_err.Visibility == Visibility.Hidden) cardnumber_authorized = true ;
            else
            {
                cardnumber_err.Visibility = Visibility.Hidden;
                cardnumber_authorized = false;
            }
        }

        

        private void dpExpirationDate_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dpExpirationDate.SelectedDate != null)
                expdate_err.Visibility = Visibility.Hidden;
            else expdate_err.Visibility = Visibility.Visible;
        }

        private void txtCVV_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCVV.Text == "")
            {
                cvv_err.Text = "empty!!!";
                cvv_err.Visibility = Visibility.Visible;
            }
            else
            {
                if (ValidationClass.CVV_Validate(txtCVV.Text))
                {
                    cvv_err.Visibility = Visibility.Hidden;
                }
                else
                {
                    cvv_err.Text = "invalid cvv";
                    cvv_err.Visibility = Visibility.Visible;
                }
            }
        }

        private void txtCVV_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cvv_err.Visibility == Visibility.Hidden) cvv_authorized = true;
            else
            {
                cvv_err.Visibility = Visibility.Hidden;
                cvv_authorized = false;
            }
        }

        private void txtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtAmount.Text == "")
            {
                amount_err.Text = "empty!!!";
                amount_err.Visibility = Visibility.Visible;
            }
            else
            {
                if(IsNumber(txtAmount.Text))
                {
                    amount_err.Visibility = Visibility.Hidden;
                }
                else
                {
                    amount_err.Text = "invalid amount";
                    amount_err.Visibility = Visibility.Visible;
                }
            }
        }
        private static bool IsNumber(string input)
        {
            Regex regex = new Regex(@"^(?:-?\d+|-?\d+\.\d+)$");
            return regex.IsMatch(input);
        }

        private void txtAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (amount_err.Visibility == Visibility.Hidden) amountauthorized = true;
            else
            {
                amount_err.Visibility = Visibility.Visible;
                amountauthorized = false;
            }
        }

        
    }
}