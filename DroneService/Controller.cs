using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        private int tag = 90;

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

        public int IncrementTag()
        {
            if (tag == 900)
            {
                tag = 100;
                return tag;
            }
            tag = tag + 10;
            return tag;
        }

        public void AddRegularDrone(string ClientName, string DroneModel, string ServiceProblem, double ServiceCost, int ServiceTag)
        {           
            Regular.Enqueue(new Drone (ClientName, DroneModel, ServiceProblem, ServiceCost, tag));
        }

        public void AddExpressDrone(string ClientName, string DroneModel, string ServiceProblem, double ServiceCost, int ServiceTag)
        {
            ServiceCost = Math.Round(ServiceCost * 1.15, 2);      
            Express.Enqueue(new Drone (ClientName, DroneModel, ServiceProblem, ServiceCost, tag));
        }

        public string DisplayDetails(Drone SelectedDrone)
        {
            return 
                "Drone Details:" +
                $"\nClient Name: {SelectedDrone.ClientName}" +
                $"\nDrone Model: {SelectedDrone.DroneModel}" +
                $"\nService Problem: {SelectedDrone.ServiceProblem} " +
                $"\nService Cost: {SelectedDrone.ServiceCost:C2}" +
                $"\nService Tag: {SelectedDrone.ServiceTag}";
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

        public void RemoveCompletedDrone(Drone item)
        {
            Finished.Remove(item);
        }
    }
}
