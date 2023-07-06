using System;
using System.Collections.Generic;
using System.Data;
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

namespace MainProject.EmployeePanelFiles.Pages
{
    /// <summary>
    /// Interaction logic for AdvancedSearch.xaml
    /// </summary>
    public partial class AdvancedSearch : Page
    {

        public bool isEmployee = false;
        public Customer Activecustomer;

        bool sender_national_code_authorized = false;


        public AdvancedSearch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string condition = "";
            if (SearchBynationalCode_Checkbox.IsChecked == true)
            {
                if (sender_national_code_authorized == true)
                {
                    condition += $"sender_national_code = '{txt_sender_national_code.Text}' and ";


                    string contenttype = "";
                    if (SearchByContentType_A_Checkbox.IsChecked == true) contenttype += "'object', ";
                    if (SearchByContentType_B_Checkbox.IsChecked == true) contenttype += "'document', ";
                    if (SearchByContentType_C_Checkbox.IsChecked == true) contenttype += "'breakable', ";
                    if (contenttype != "")
                    {
                        condition += $"content_type in ({contenttype.Substring(0, contenttype.Length - 2)}) and ";
                    }
                    if (SearchByPrice_Checkbox.IsChecked == true)
                    {
                        condition += $"price>{Slider1.Value} and price<{Slider2.Value} and ";
                    }
                    if (SearchByWeight_Checkbox.IsChecked == true)
                    {
                        condition += $"weight>{Slider3.Value} and weight<{Slider4.Value} and ";
                    }
                    string typeofdelivery = "";
                    if (checkbox_ordinary.IsChecked == true)
                    {
                        typeofdelivery += "'ordinary', ";
                    }
                    if (checkbox_swift.IsChecked == true) typeofdelivery += "'swift', ";
                    if (typeofdelivery != "")
                    {
                        condition += $"send_type in ({typeofdelivery.Substring(0, typeofdelivery.Length - 2)}) and ";
                    }
                    if (isEmployee == false)
                    {
                        condition += $"sender_national_code = {Activecustomer.National_Code} and  ";
                    }
                   
                    DataTable dt;
                    if (condition != "")
                    { 

                        dt = MainProject.Controller.dbFunctions.QueryOnOrders(condition.Substring(0, condition.Length - 4));
                        datagrid1.ItemsSource = dt.DefaultView;

                    }
                    else
                    {
                       
                        dt = MainProject.Controller.dbFunctions.QueryOnOrders("");
                        datagrid1.ItemsSource = dt.DefaultView;
                    }
                    DateTime mynow = DateTime.Now;
                    ValidationClass.SaveDataTableToCsv(dt, $"{mynow.Year}-{mynow.Month}-{mynow.Day}_{mynow.Hour}-{mynow.Minute}-{mynow.Second}.csv");
                }
                else
                {
                    lbl_sender_national_code_warning.Visibility = Visibility.Visible;
                }
            }
            else
            {
                string contenttype = "";
                if (SearchByContentType_A_Checkbox.IsChecked == true) contenttype += "'object', ";
                if (SearchByContentType_B_Checkbox.IsChecked == true) contenttype += "'document', ";
                if (SearchByContentType_C_Checkbox.IsChecked == true) contenttype += "'breakable', ";
                if (contenttype != "")
                {
                    condition += $"content_type in ({contenttype.Substring(0, contenttype.Length - 2)}) and ";
                }
                if (SearchByPrice_Checkbox.IsChecked == true)
                {
                    condition += $"price>{Slider1.Value} and price<{Slider2.Value} and ";
                }
                if (SearchByWeight_Checkbox.IsChecked == true)
                {
                    condition += $"weight>{Slider3.Value} and weight<{Slider4.Value} and ";
                }
                string typeofdelivery = "";
                if (checkbox_ordinary.IsChecked == true)
                {
                    typeofdelivery += "'ordinary', ";
                }
                if (checkbox_swift.IsChecked == true) typeofdelivery += "'swift', ";
                if (typeofdelivery != "")
                {
                    condition += $"send_type in ({typeofdelivery.Substring(0, typeofdelivery.Length - 2)}) and ";
                }
                if (isEmployee == false)
                {
                    condition += $"sender_national_code = '{Activecustomer.National_Code}' and ";
                }
              
                DataTable dt;

                if (condition != "")
                {

                    dt = MainProject.Controller.dbFunctions.QueryOnOrders(condition.Substring(0, condition.Length - 4));
                    datagrid1.ItemsSource = dt.DefaultView;
                }
                else
                {
                 
                    dt = MainProject.Controller.dbFunctions.QueryOnOrders("");
                    datagrid1.ItemsSource = dt.DefaultView;
                }
                DateTime mynow = DateTime.Now;
                ValidationClass.SaveDataTableToCsv(dt, $"{mynow.Year}-{mynow.Month}-{mynow.Day}_{mynow.Hour}-{mynow.Minute}-{mynow.Second}.csv");
            }
        }

        private void txt_sender_national_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                if (txt_sender_national_code.Text != "")
                {
                    if (ValidationClass.IDValidate(txt_sender_national_code.Text))
                    {
                    lbl_sender_national_code_warning.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                    lbl_sender_national_code_warning.Text = "invalid national code";
                    lbl_sender_national_code_warning.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                lbl_sender_national_code_warning.Text = "empty!!!";
                lbl_sender_national_code_warning.Visibility = Visibility.Visible;
                }
           
        }

        private void txt_sender_national_code_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lbl_sender_national_code_warning.Visibility == Visibility.Hidden) sender_national_code_authorized = true;
            else
            {
                sender_national_code_authorized = false;
                lbl_sender_national_code_warning.Visibility = Visibility.Hidden;
            }
        }

        private void Slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
                if (Slider2.Value < Slider1.Value) Slider2.Value = e.OldValue;
           
           
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Slider2 != null)
            {
                if (Slider1.Value > Slider2.Value) Slider1.Value = e.OldValue;

            }
        }

        private void Slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Slider4 != null)
            {
                if (Slider3.Value > Slider4.Value) Slider3.Value = e.OldValue;

            }
        }

        private void Slider4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Slider4.Value < Slider3.Value) Slider4.Value = e.OldValue;
        }

        private void SearchBynationalCode_Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl_sender_national_code_warning.Visibility = Visibility.Hidden;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (isEmployee == false)
            {
                SearchBynationalCode_Checkbox.IsEnabled = false;
            }
        }
    }
}
