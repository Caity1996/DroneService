using DroneService;
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
        private Controller controller;
        private MainWindow mainWindow;
        public AddDroneMenu(Controller controller)
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow as MainWindow;
            this.controller = controller;
        }

        public void DisplayStatus(string msg)
        {
            Status2Txt.Text = $"System Status: {msg}";
        }

        public void ServiceCostTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ServiceCostTxt.Text, out double value))
            {
                ServiceCostTxt.Text = value.ToString("C2");
            }
            else
            {
                ServiceCostTxt.Text = "$0.00";
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            List<System.Windows.Controls.TextBox> textBoxes = new List<System.Windows.Controls.TextBox>
            {
                ClientNameTxt,
                DroneModelTxt,
                ServiceProblemTxt,
                ServiceCostTxt
            };

            bool TextNullCheck = textBoxes.Any(txt => string.IsNullOrWhiteSpace(txt.Text));

            bool RadioButtonUnchecked = !(Regular.IsChecked == true) && !(Express.IsChecked == true);

            if (TextNullCheck || RadioButtonUnchecked) { DisplayStatus("Error! Not all fields are filled, or a service type was not seleted!"); return; }

            double ServiceCost = double.Parse(ServiceCostTxt.Text.Replace("$", "").Replace(",", ""));

            int ServiceTag = controller.IncrementTag();

            if (Regular.IsChecked == true)
            {
                controller.AddRegularDrone(ClientNameTxt.Text, DroneModelTxt.Text, ServiceProblemTxt.Text, ServiceCost, ServiceTag);

                DisplayStatus("Successfully added drone to the regular queue");
                this.Close();
            }

            else if(Express.IsChecked == true)
            { 

                controller.AddExpressDrone(ClientNameTxt.Text, DroneModelTxt.Text, ServiceProblemTxt.Text, ServiceCost, ServiceTag);

                DisplayStatus("Successfully added drone to the express queue");
                this.Close();
            }
        }
    }
}
