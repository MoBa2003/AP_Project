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


namespace MAIL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserLogin_Click(object sender, RoutedEventArgs e)
        {
            buttonpanel.Visibility = Visibility.Visible;
            UserLoginPanel.Visibility = Visibility.Visible;
            AddEmployeePanel.Visibility = Visibility.Collapsed;
        }



        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            buttonpanel.Visibility = Visibility.Visible;
            UserLoginPanel.Visibility = Visibility.Collapsed;
            AddEmployeePanel.Visibility = Visibility.Visible;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //isValid      check if true
            if (true)//is valid check
            {
                if (true)//see if is a employee
                {
                    buttonpanel.Visibility = Visibility.Collapsed;
                    UserLoginPanel.Visibility = Visibility.Collapsed;
                    AddEmployeePanel.Visibility = Visibility.Collapsed;
                    Employeebuttonpanel.Visibility = Visibility.Visible;
                    AddCustomerPanel.Visibility = Visibility.Visible;
                }
                else if (true)//see if is a person
                {
                    buttonpanel.Visibility = Visibility.Collapsed;
                    UserLoginPanel.Visibility = Visibility.Collapsed;
                    AddEmployeePanel.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                 
            }
        }

        //private void btnClose_Click(object sender, RoutedEventArgs e)
        //{
        //
        //}

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            //we have to make an employee here and make sure to validate the data
            //string email = tb_Email.Text;
            //string password = tb_password.Text;
        }

        private void btn_IDSearch_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerPanel.Visibility = Visibility.Collapsed;
            AddOrderPanelFirstPage.Visibility = Visibility.Collapsed;
            AdvancedSearchPanel.Visibility = Visibility.Collapsed;
            IDSearch.Visibility = Visibility.Visible;
        }

        private void btn_AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerPanel.Visibility = Visibility.Collapsed;
            AddOrderPanelFirstPage.Visibility = Visibility.Collapsed;
            AdvancedSearchPanel.Visibility = Visibility.Visible;
            IDSearch.Visibility = Visibility.Collapsed;
        }

        private void btn_AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerPanel.Visibility = Visibility.Collapsed;
            AddOrderPanelFirstPage.Visibility = Visibility.Visible;
            AdvancedSearchPanel.Visibility = Visibility.Collapsed;
            IDSearch.Visibility = Visibility.Collapsed;
        }

        private void btn_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            Employeebuttonpanel.Visibility = Visibility.Visible;
            AddCustomerPanel.Visibility = Visibility.Visible;
            AddOrderPanelFirstPage.Visibility = Visibility.Collapsed;
            AdvancedSearchPanel.Visibility = Visibility.Collapsed;
            IDSearch.Visibility = Visibility.Collapsed;
        }

        private void btn_Employeeback_Click(object sender, RoutedEventArgs e)
        {
            buttonpanel.Visibility = Visibility.Visible;
            UserLoginPanel.Visibility = Visibility.Visible;
            AddEmployeePanel.Visibility = Visibility.Collapsed;
            Employeebuttonpanel.Visibility = Visibility.Collapsed;
            AddCustomerPanel.Visibility = Visibility.Collapsed;
            AddOrderPanelFirstPage.Visibility = Visibility.Collapsed;
            AdvancedSearchPanel.Visibility = Visibility.Collapsed;
            IDSearch.Visibility = Visibility.Collapsed;
        }

        private void btn_CreatCustomer_Click(object sender, RoutedEventArgs e)
        {
            //validatate wether the inputs are valid or not thn send an email
            //for validity make a input like (ISVALID = true) then make a function which validates and returns the ISVALID value

            //var mailto = new Uri("mailto:?to=" + emails + "&subject=" + subject + "&body=" + body);
            //await Windows.System.Launcher.LaunchUriAsync(mailto);
            if (/*ISVALID*/true)
            {
                MessageBox.Show("Created Succesfully");
            }
        }

        private void btn_AddOrderSearch_Click(object sender, RoutedEventArgs e)
        {
            if (true)//AddOrderSearch.Text if it exist
            {
                AddOrderPanelFirstPage.Visibility = Visibility.Collapsed;
                AddOrderPanelSecondPage.Visibility = Visibility.Visible;
            }
        }
    }
}
