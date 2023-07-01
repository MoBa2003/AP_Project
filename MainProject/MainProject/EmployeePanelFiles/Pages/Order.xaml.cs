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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            code_err.Content = "";
            sender_err.Content = "";
            receiver_err.Content = "";
            weight_err.Content = "";
            content1_err.Content = "";
            content2_err.Content = "";

            if (string.IsNullOrEmpty(txt_code.Text))
            {
                code_err.Content = "NationalCode Empty";
            }
            else if (string.IsNullOrEmpty(txt_sender.Text))
            {
                sender_err.Content = "Address Empty";
            }
            else if (string.IsNullOrEmpty(txt_receiver.Text))
            {
                receiver_err.Content = "Address Empty";
            }
            else if (string.IsNullOrEmpty(txt_weight.Text))
            {
                weight_err.Content = "Weight Empty";
            }
            else if (combofirst.SelectedIndex < 0)
            {
                content1_err.Content = "Please Select";
            }
            else if (combosecond.SelectedIndex < 0)
            {
                content2_err.Content = "Please Select";
            }
        }
    }
}
