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
using System.Windows.Shapes;

namespace subproject2
{
    /// <summary>
    /// Interaction logic for CustomerWallet.xaml
    /// </summary>
    public partial class CustomerWallet : Window
    {
        public CustomerWallet()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected expiration date
            DateTime expirationDate = dpExpirationDate.SelectedDate ?? DateTime.MinValue;

            // Perform the charging logic here
            // ...

            MessageBox.Show("Wallet charged successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
