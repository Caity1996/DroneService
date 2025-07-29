using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneService
{
    internal class Drone
    {
        string ClientName {  get; set; }
        string DroneModel { get; set; }
        string ServiceProblem { get; set; }
        double ServiceCost { get; set; }
        string ServiceTag { get; set; }

        public Drone()
        {

        }

        public Drone (string ClientName, string DroneModel, string ServiceProblem, double ServiceCost, string ServiceTag)
        {
            this.ClientName = ClientName;
            this.DroneModel = DroneModel;
            this.ServiceProblem = ServiceProblem;
            this.ServiceCost = ServiceCost;
            this.ServiceTag = ServiceTag;
        }
    }
}
