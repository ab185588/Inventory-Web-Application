using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class Products
    {

        public int ID { get; set; }
        public string NAME { get; set; }
        public decimal PRICE { get; set; }
        public int QUANTITY { get; set; }
        public decimal DISCOUNT { get; set; }


    }
}
