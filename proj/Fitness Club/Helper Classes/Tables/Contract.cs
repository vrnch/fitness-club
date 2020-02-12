using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class Contract
    {
        public Contract(string contractId, string employeeId, string positionId, string dateOfIssue,
                        string expirationDate)
        {
            this.contractId = contractId;
            this.employeeId = employeeId;
            this.positionId = positionId;
            this.dateOfIssue = dateOfIssue;
            this.expirationDate = expirationDate;
        }

        public string contractId { get; set; }
        public string employeeId { get; set; }
        public string positionId { get; set; }
        public string dateOfIssue { get; set; }
        public string expirationDate { get; set; }


    }
}
