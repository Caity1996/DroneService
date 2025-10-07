using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneService
{
    public class Drone
    {
       public string ClientName {  get; set; }
       public string DroneModel { get; set; }
       public string ServiceProblem { get; set; }
       public double ServiceCost { get; set; }
       public int ServiceTag { get; set; }

        public Drone()
        {

        }

        public Drone (string ClientName, string DroneModel, string ServiceProblem, double ServiceCost, int ServiceTag)
        {
            this.ClientName = ClientName;
            this.DroneModel = DroneModel;
            this.ServiceProblem = ServiceProblem;
            this.ServiceCost = ServiceCost;
            this.ServiceTag = ServiceTag;
        }
    }
}
