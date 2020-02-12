using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class Schedule
    {
        public Schedule(string scheduleId, string serviceName, string employeeId, string clientId, string roomType,
                        string day, string startTime, string endTime)
        {
            this.scheduleId = scheduleId;
            this.serviceName = serviceName;
            this.employeeId = employeeId;
            this.clientId = clientId;
            this.roomType = roomType;
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public string scheduleId { get; set; }
        public string serviceName { get; set; }
        public string employeeId { get; set; }
        public string clientId { get; set; }
        public string roomType { get; set; }
        public string day { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }

    }
}
