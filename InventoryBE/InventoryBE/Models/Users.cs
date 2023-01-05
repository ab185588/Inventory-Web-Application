using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string  FIRSTNAME { get; set; }
        public string  LASTNAME { get; set; }
        public string  EMAIL { get; set; }
        public string   PASSWORD { get; set; }

        public DateTime REG_DATE { get; set; }
                    
    }
}
