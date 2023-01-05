using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public string ORDERNO { get; set; }
        public decimal TOTALPRICE { get; set; }
        public string ORDERSTATUS { get; set; }


    }
}
