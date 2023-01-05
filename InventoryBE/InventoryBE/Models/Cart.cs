using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int PRODUCTID { get; set; }
        public int USERID { get; set; }
        public decimal UNITPRICE { get; set; }
        public decimal DISCOUNT  { get; set; }
        public int QUANTITY { get; set; }
        public decimal TOTALPRICE { get; set; }
    }
}
