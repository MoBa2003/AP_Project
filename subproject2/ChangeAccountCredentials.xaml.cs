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
    /// Interaction logic for ChangeAccountCredentials.xaml
    /// </summary>
    public partial class ChangeAccountCredentials : Window
    {
        public ChangeAccountCredentials()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = txtNewUsername.Text;
            string newPassword = txtNewPassword.Password;

            // Perform logic to change password and username

            MessageBox.Show("Password and username changed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
