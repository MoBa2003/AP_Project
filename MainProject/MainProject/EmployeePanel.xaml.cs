using MainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainProject.Models;
using WPFModernVerticalMenu.Pages;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for EmployeePanel.xaml
    /// </summary>
    public partial class EmployeePanel : Window
    {
        Employee ActiveEmployee;
        public EmployeePanel()
        {
            InitializeComponent();
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btn_Register_Customer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btn_Register_Customer;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Register Customer";
            }
        }

        private void btn_Register_Customer_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btn_Order_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btn_Order;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Order";
            }
        }

        private void btn_Order_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btn_advanced_Search_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btn_advanced_Search;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Advanced Search";
            }
        }

        internal void getemployee(Employee employee)
        {
            ActiveEmployee = employee;
        }

        private void btn_advanced_Search_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btn_order_info_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btn_order_info;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Order Info";
            }
        }

        private void btn_order_info_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

     

  

    

      
       

        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            LoginForm lg = new LoginForm();
            lg.Show();
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void btn_Register_Customer_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_Order_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/Order.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btn_advanced_Search_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/AdvancedSearch.xaml", UriKind.RelativeOrAbsolute));
            
        }
        private void btn_order_info_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/OrderInfo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_name.Content = ActiveEmployee.FirstName + " " + ActiveEmployee.LastName;
        }

        private void fContainer_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if(e.Content is MainProject.EmployeePanelFiles.Pages.AdvancedSearch advancedsearch){
                advancedsearch.isEmployee = true;
            }
           else if(e.Content is MainProject.EmployeePanelFiles.Pages.OrderInfo orderinfo)
            {
                orderinfo.IsEmployee = true;
            }
        }
    }
}
