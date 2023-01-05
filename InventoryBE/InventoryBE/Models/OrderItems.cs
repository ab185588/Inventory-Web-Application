using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class OrderItems
    {
        /*
ID INT IDENTITY(1,1) PRIMARY KEY,
ORDERID INT,
PRODUCTID INT,
UNITPRICE DECIMAL(18,2),
DISCOUNT DECIMAL(2,2),
QUANTITY INT,
TOTALPRICE DECIMAL(18,2)*/
        public int ID { get; set; }
        public int ORDERID { get; set; }
        public int PRODUCTID { get; set; }
        public decimal UNITPRICE { get; set; }
        public decimal DISCOUNT { get; set; }
        public int QUANTITY { get; set; }
        public decimal TOTALPRICE { get; set; }
    }
}
