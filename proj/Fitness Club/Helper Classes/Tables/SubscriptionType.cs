using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class SubscriptionType
    {
        public SubscriptionType(string subscriptionTypeId, string type, string price)
        {
            this.subscriptionTypeId = subscriptionTypeId;
            this.type = type;
            this.price = price;
        }

        public string subscriptionTypeId { get; set; }
        public string type { get; set; }
        public string price { get; set; }
    }
}
