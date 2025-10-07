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
        public AddDroneMenu()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow as MainWindow;
            controller = new Controller();
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

            if (TextNullCheck || RadioButtonUnchecked) { DisplayStatus("Error! Not all fields are filled, or a service type was not seleted!"); }

            else 
            {
                if (Regular.IsChecked == true)
                {
                    double ServiceCost = double.Parse(ServiceCostTxt.Text.Replace("$", "").Replace(",", ""));

                    int ServiceTag = int.Parse(ServiceTagTxt.Text);

                    controller.AddRegularDrone(ClientNameTxt.Text, DroneModelTxt.Text, ServiceProblemTxt.Text, ServiceCost, ServiceTag);

                    mainWindow.RegularDroneList.Items.Clear();

                    foreach (Drone drone in controller.GetRegular())
                    {
                        mainWindow.RegularDroneList.Items.Add(drone);
                    }
                    DisplayStatus("Successfully added drone to the regular queue");
                    this.Close();
                }

                if (Express.IsChecked == true)
                {
                    if (Regular.IsChecked == true)
                    {
                        double ServiceCost = double.Parse(ServiceCostTxt.Text.Replace("$", "").Replace(",", ""));

                        int ServiceTag = int.Parse(ServiceTagTxt.Text);

                        controller.AddExpressDrone(ClientNameTxt.Text, DroneModelTxt.Text, ServiceProblemTxt.Text, ServiceCost, ServiceTag);

                        mainWindow.RegularDroneList.Items.Clear();

                        foreach (Drone drone in controller.GetExpress())
                        {
                            mainWindow.ExpressDroneList.Items.Add(drone);
                        }
                        DisplayStatus("Successfully added drone to the regular queue");
                        this.Close();
                    }
                }
            }
        }
    }
}
