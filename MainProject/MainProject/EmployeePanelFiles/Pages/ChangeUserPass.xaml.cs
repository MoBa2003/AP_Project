﻿using System;
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
    /// Interaction logic for ChangeUserPass.xaml
    /// </summary>
    public partial class ChangeUserPass : Page
    {
        public ChangeUserPass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUsername_err.Content = "";
            Password_err.Content = "";
            if(string.IsNullOrEmpty(txt_newusername.Text))
            {
                NewUsername_err.Content = "New Username Empty";
            }
            else if(string.IsNullOrEmpty(txt_password.Text))
            {
                Password_err.Content = "Password Empty";
            }
        }
    }
}
