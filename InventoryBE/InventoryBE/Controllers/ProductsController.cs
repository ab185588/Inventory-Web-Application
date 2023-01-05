using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryBE.Models;
using System.Data.SqlClient;

namespace InventoryBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ProductsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("AddToCart")]
        public Responsecs AddToCart(Cart cart)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.AddToCart(cart, connection);
            return response;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public Responsecs PlaceOrder(Users user)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.PlaceOrder(user, connection);
            return response;
        }

        [HttpPost]
        [Route("OrderList")]
        public Responsecs OrderList(Users user)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.OrderList(user, connection);
            return response;
        }

        [HttpGet]
        [Route("ProductList")]
        public Responsecs ProductList()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.ProductList(connection);
            return response;

        }


    }
}
