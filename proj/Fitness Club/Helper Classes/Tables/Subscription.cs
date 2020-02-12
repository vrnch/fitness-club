using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class Subscription
    {
        public Subscription(string subscriptionId, string clientId, string subscriptionTypeId, string dateOfIssue,
                            string expirationDate)
        {
            this.subscriptionId = subscriptionId;
            this.clientId = clientId;
            this.subscriptionTypeId = subscriptionTypeId;
            this.dateOfIssue = dateOfIssue;
            this.expirationDate = expirationDate;
        }

        public string subscriptionId { get; set; }
        public string clientId { get; set; }
        public string subscriptionTypeId { get; set; }
        public string dateOfIssue { get; set; }
        public string expirationDate { get; set; }
    }
}
