using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class Responsecs
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users> ListUsers { get; set; }
        public Users  User{ get; set; }
        public List<Cart> ListCart{ get; set; }
        public List<Products> ListProducts { get; set; }
        public Products Product { get; set; }
        public List<Orders> ListOrders{ get; set; }
        public Orders Order { get; set; }
        public List<OrderItems> ListOrderItems { get; set; }
        public OrderItems OrderItem { get; set; }

        public RegisterAnalytics RegisterAnalytic { get; set; }

        public List<DateTime> reg_date { get; set; }

        public List<int> num_users { get; set; }


    }
}
