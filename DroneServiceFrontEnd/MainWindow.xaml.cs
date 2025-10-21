using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DroneService;

namespace DroneServiceFrontEnd
{
    public partial class MainWindow : Window
    {
        Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
        }

        public void DisplayStatus(string msg)
        {
            Status1Txt.Text = $"System Status: {msg}";
        }

        private void AddDroneBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDroneMenu addDroneMenu = new AddDroneMenu(controller);
            addDroneMenu.ShowDialog();
            UpdateUI();
        }

        private void RegDequeueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (controller.GetRegular().Count == 0)
            {
                DisplayStatus("Error! No Drones found to Dequeue!");
                UpdateUI();
            }
            else
            {
                controller.RemoveRegularDrone();
                DisplayStatus("First Drone sucessfully removed from the Regular queue and added to Completed List!");
                UpdateUI();
            }
        }
        private void ExDequeueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (controller.GetExpress().Count == 0)
            {
                DisplayStatus("Error! No Drones found to Dequeue!");
                UpdateUI();
            }
            else
            {
                controller.RemoveExpressDrone();
                DisplayStatus("First Drone sucessfully removed from the Express queue and added to Completed List!");
                UpdateUI();
            }
        }

        private void RegularDroneList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox != null && listBox.SelectedItem != null)
            {
                var selectedDrone = listBox.SelectedItem as Drone;

                MessageBox.Show(controller.DisplayDetails(selectedDrone));
            }
        }

        private void ExpressDroneList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox != null && listBox.SelectedItem != null)
            {
                var selectedDrone = listBox.SelectedItem as Drone;

                MessageBox.Show(controller.DisplayDetails(selectedDrone));
            }
        }

        private void CompletedDroneLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox != null && listBox.SelectedItem != null)
            {
                var selectedDrone = listBox.SelectedItem as Drone;

                MessageBox.Show(controller.DisplayDetails(selectedDrone));
            }
        }

        private void CompletedDroneLst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null && item.Content is Drone selectedDrone)
            {
                controller.RemoveCompletedDrone(selectedDrone);
                UpdateUI();
                DisplayStatus($"Item Number: {selectedDrone.ServiceTag} sucessfully removed from the completed List!");
            }
        }

        public void UpdateUI()
        {
            RegularDroneList.ItemsSource = null;
            ExpressDroneList.ItemsSource = null;
            CompletedDroneLst.ItemsSource = null;

            RegularDroneList.ItemsSource = controller.GetRegular().ToList();
            ExpressDroneList.ItemsSource = controller.GetExpress().ToList();
            CompletedDroneLst.ItemsSource = controller.GetFinished().ToList();
        }
    }
}