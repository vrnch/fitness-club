using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class Employee
    {
        public Employee(string employeeId, string name, string phoneNumber, string passport, string email,
                        string positionName, string serviceName, string dateOfIssue, string expirationDate)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.passport = passport;
            this.email = email;
            this.positionName = positionName;
            this.serviceName = serviceName;
            this.dateOfIssue = dateOfIssue;
            this.expirationDate = expirationDate;
        }

        public string employeeId { get; set; } 
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string passport { get; set; }
        public string email { get; set; }
        public string positionName { get; set; }
        public string serviceName { get; set; }
        public string dateOfIssue { get; set; }
        public string expirationDate { get; set; }



    }
}
