using InventoryBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AdminController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("AddUpdateProducts")]
        public Responsecs AddUpdateProducts(Products product)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.AddUpdateProducts(product, connection);
            return response;
        }

        [HttpGet]
        [Route("UsersList")]
        public Responsecs UsersList()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.UsersList(connection);
            return response;
        }

        [HttpGet]
        [Route("RegAnalytics")]

        public Responsecs RegAnalytics()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            Responsecs response = dal.RegAnalytics(connection);
            return response;
        }


    }
}
