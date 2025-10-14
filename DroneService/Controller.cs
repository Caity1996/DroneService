using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DroneService
{
    public class Controller
    {
        private Queue<Drone> Regular;
        private Queue<Drone> Express;
        private List<Drone> Finished;

        public Controller()
        {
            Regular = new Queue<Drone>();
            Express = new Queue<Drone>();
            Finished = new List<Drone>();
        }

        public Queue<Drone> GetRegular()
        {
            return Regular;
        }

        public Queue<Drone> GetExpress()
        {
            return Express;
        }

        public List<Drone> GetFinished()
        {
            return Finished;
        }

        public int IncrementRegTag()
        {
            int ServiceTag;

            if (Regular.Count == 0 || Regular.Count >= 81)
            {
                ServiceTag = 100;
                return ServiceTag;
            }
            Drone lastDrone = Regular.Last();
            ServiceTag = lastDrone.ServiceTag + 10;
            return ServiceTag;
        }


        public int IncrementExTag()
        {
            int ServiceTag;

            if (Express.Count == 0 || Express.Count >= 81)
            {
                ServiceTag = 100;
                return ServiceTag;
            }
            Drone lastDrone = Express.Last();
            ServiceTag = lastDrone.ServiceTag + 10;
            return ServiceTag;
        }

        public void AddRegularDrone(string ClientName, string DroneModel, string ServiceProblem, double ServiceCost, int ServiceTag)
        {
            Regular.Enqueue(new Drone (ClientName, DroneModel, ServiceProblem, ServiceCost, ServiceTag));
        }

        public void AddExpressDrone(string ClientName, string DroneModel, string ServiceProblem, double ServiceCost, int ServiceTag)
        {
            ServiceCost = ServiceCost * 1.15;
            Express.Enqueue(new Drone (ClientName, DroneModel, ServiceProblem, ServiceCost, ServiceTag));
        }

        public string DisplayDetails(Drone SelectedDrone)
        {
            return 
                "Drone Details:" +
                $"\n{SelectedDrone.ClientName}" +
                $"\n {SelectedDrone.DroneModel}" +
                $"\n {SelectedDrone.ServiceProblem} " +
                $"\n {SelectedDrone.ServiceCost}" +
                $"\n {SelectedDrone.ServiceTag}";
        }

        public bool RemoveRegularDrone()
        {
            if (Regular.Count == 0)
            {
                return false;
            }
            else
            {
                Drone completedDrone = Regular.Dequeue();
                Finished.Add(completedDrone);
                return true;
            }
        }

        public bool RemoveExpressDrone()
        {
            if (Express.Count == 0)
            {
                return false;
            }
            else
            {
                Drone completedDrone = Express.Dequeue();
                Finished.Add(completedDrone);
                return true;
            }
        }
    }
}
