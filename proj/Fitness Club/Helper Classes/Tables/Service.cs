using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class Service
    {
        public Service(string serviceId,
                       string employeeId,
                       string serviceName)
        {
            this.serviceId = serviceId;
            this.employeeId = employeeId;
            this.serviceName = serviceName;
        }

        public string serviceId { get; set; }
        public string employeeId { get; set; }
        public string serviceName { get; set; }

    }
}
