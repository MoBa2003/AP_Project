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

namespace MainProject.EmployeePanelFiles.Pages
{
    /// <summary>
    /// Interaction logic for Wallet.xaml
    /// </summary>
    public partial class Wallet : Page
    {
        public Wallet()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cardnumber_err.Content = "";
            expdate_err.Content = "";
            cvv_err.Content = "";
            amount_err.Content = "";

            if (!UInt64.TryParse(txtCardNumber.Text,out var number))
            {
                cardnumber_err.Content = "Invalid Card Number";
            }
            else if (string.IsNullOrEmpty(dpExpirationDate.Text))
            {
                expdate_err.Content = "Pick EXP Time";
            }
            else if (string.IsNullOrEmpty(txtCVV.Text))
            {
                cvv_err.Content = "Please Enter Card CVV";
            }
            else if (!UInt64.TryParse(txtAmount.Text,out var amount))
            {
                amount_err.Content = "Invalid Money Amount";
            }


        }
    }
}
