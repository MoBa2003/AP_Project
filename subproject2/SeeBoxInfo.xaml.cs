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
    /// Interaction logic for SeeBoxInfo.xaml
    /// </summary>
    public partial class SeeBoxInfo : Window
    {
        public SeeBoxInfo()
        {

            InitializeComponent();
            //Here We will Give it the data Based ON the Search Button that Was Used If it was a employee or a customer and we get data based on that
            dataGrid.ItemsSource = "" /*some Name*/;
        }
    }
}
