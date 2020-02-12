using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Club.Helper_Classes.Tables
{
    class Room
    {
        public Room(string roomId, string isAvailable, string type, string capacity)
        {
            this.roomId = roomId;
            this.isAvailable = isAvailable;
            this.type = type;
            this.capacity = capacity;
        }

        public string roomId { get; set; }
        public string isAvailable { get; set; }
        public string type { get; set; }
        public string capacity { get; set; }

    }
}
