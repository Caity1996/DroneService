using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace DroneServiceFrontEnd
{
    /// <summary>
    /// Interaction logic for AddDroneMenu.xaml
    /// </summary>
    public partial class AddDroneMenu : Window
    {
        public AddDroneMenu()
        {
            InitializeComponent();
        }

        public void DisplayStatus(string msg)
        {
            Status2Txt.Text = $"System Status: {msg}";
        }

        public void ServiceCostTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ServiceCostTxt.Text, out double value))
            {
                ServiceCostTxt.Text = value.ToString("F2");
            }
            else
            {
                ServiceCostTxt.Text = "0.00";
            }
        }
    }
}
