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

namespace MainProject
{
    /// <summary>
    /// Interaction logic for CustomerPanel.xaml
    /// </summary>
    public partial class CustomerPanel : Window
    {
        public CustomerPanel()
        {
            InitializeComponent();
        }
        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btn_ChangeUserPass_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btn_ChangeUserPass;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Change Username Password";
            }
        }

        private void btn_ChangeUserPass_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btn_Wallet_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btn_Wallet;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Wallet";
            }
        }

        private void btn_Wallet_MouseLeave(object sender, MouseEventArgs e)
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

        private void btn_ChangeUserPass_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/ChangeUserPass.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_Wallet_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/Wallet.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btn_advanced_Search_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/AdvancedSearch.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btn_order_info_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("EmployeePanelFiles/Pages/OrderInfo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MenuItem_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
