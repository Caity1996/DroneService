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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDroneMenu addDroneMenu = new AddDroneMenu();

            addDroneMenu.ShowDialog();
        }
        //public void somemethod(object sender)
        //{
        //    foreach(Drone drone in controller.getmethodgoeshere())
        //}
    }
}