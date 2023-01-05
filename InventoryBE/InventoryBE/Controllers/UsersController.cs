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
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        public UsersController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        [Route("registration")]
        public Responsecs Register(Users user)
        {
            Responsecs response;
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            DAL dal = new DAL();
            response = dal.Register(user, connection);
            return response;
        }
        [HttpPost]
        [Route("login")]
        public Responsecs Login(Users user)
        {
            Responsecs response;
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            DAL dal = new DAL();
            response=dal.Login(user, connection);
            return response;
        }
        [HttpPost]
        [Route("ViewUser")]
        public Responsecs ViewUser(Users user)
        {
            Responsecs response;
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            DAL dal = new DAL();
            response = dal.ViewUser(user, connection);
            return response;
        }
        [HttpPost]
        [Route("UpdateUser")]
        public Responsecs UpdateUser(Users user)
        {
            Responsecs response;
            SqlConnection connection = new SqlConnection(_config.GetConnectionString("InventoryCS").ToString());
            DAL dal = new DAL();
            response = dal.UpdateUserProfile(user, connection);
            return response;
        }

        


    }
}
