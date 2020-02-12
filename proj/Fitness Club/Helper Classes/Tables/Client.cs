using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fitness_Club.Helper_Classes.Tables
{
    class Client
    {
        public Client(string clientId, string name, string phoneNumber, string email, string subscriptionId, string type,
                      string price, string dateOfIssue, string expirationDate)
        {
            this.clientId = clientId;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.subscriptionId = subscriptionId;
            this.type = type;
            this.price = price;
            this.dateOfIssue = dateOfIssue;
            this.expirationDate = expirationDate;
        }
        public string clientId { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string subscriptionId { get; set; }
        public string type { get; set; }
        public string price { get; set; }
        public string dateOfIssue { get; set; }
        public string expirationDate { get; set; }

    }
}
