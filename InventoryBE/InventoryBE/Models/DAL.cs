using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBE.Models
{
    public class DAL
    {
        public Responsecs Register(Users user,SqlConnection connection){

            Responsecs response = new Responsecs();

            

            SqlCommand cmd = new SqlCommand("insert into Users (FIRSTNAME,LASTNAME,EMAIL,PASSWORD,REG_DATE)  values(@FIRSTNAME,@LASTNAME,@EMAIL,@PASSWORD,@REG_DATE)", connection);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FIRSTNAME", user.FIRSTNAME);
            cmd.Parameters.AddWithValue("@LASTNAME", user.LASTNAME);
            cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
            cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
            cmd.Parameters.AddWithValue("@REG_DATE", user.REG_DATE);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User registration successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User registration failed";
            }

            return response;
        }
        public Responsecs Login(Users user,SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            string query = "select * from Users where EMAIL = @EMAIL and PASSWORD = @PASSWORD";
            SqlDataAdapter da = new SqlDataAdapter(query,connection);
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@EMAIL", user.EMAIL);
            da.SelectCommand.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
            DataTable dt = new DataTable();
            Users users = new Users();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                users.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                users.FIRSTNAME = Convert.ToString(dt.Rows[0]["FIRSTNAME"]);
                users.LASTNAME = Convert.ToString(dt.Rows[0]["LASTNAME"]);
                users.EMAIL = Convert.ToString(dt.Rows[0]["EMAIL"]);
                
                response.User = users;
                response.StatusCode = 200;
                response.StatusMessage = "User Login successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Login failed";
                response.User = null;
            }
            return response;
        }
        public Responsecs ViewUser(Users user,SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            SqlDataAdapter da = new SqlDataAdapter("select * from Users where ID=@ID",connection);
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@ID", user.ID);
            DataTable dt = new DataTable();
            Users users = new Users();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                users.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                users.FIRSTNAME = Convert.ToString(dt.Rows[0]["FIRSTNAME"]);
                users.LASTNAME = Convert.ToString(dt.Rows[0]["LASTNAME"]);
                users.EMAIL = Convert.ToString(dt.Rows[0]["EMAIL"]);
                users.PASSWORD = Convert.ToString(dt.Rows[0]["PASSWORD"]);

                response.User = users;
                response.StatusCode = 200;
                response.StatusMessage = "User Found successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Found failed";
                response.User = null;
            }
            return response;

        }
        public Responsecs UpdateUserProfile(Users user,SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            string query = "update Users set FIRSTNAME = @FIRSTNAME , LASTNAME = @LASTNAME , EMAIL = @EMAIL , PASSWORD = @PASSWORD where ID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@FIRSTNAME", user.FIRSTNAME);
                cmd.Parameters.AddWithValue("@LASTNAME", user.LASTNAME);
                cmd.Parameters.AddWithValue("@EMAIL", user.EMAIL);
                cmd.Parameters.AddWithValue("@PASSWORD", user.PASSWORD);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                Users users = new Users();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    users.FIRSTNAME = user.FIRSTNAME;
                    users.LASTNAME = user.LASTNAME;
                    users.EMAIL = user.EMAIL;
                    response.User = users;
                    response.StatusMessage = "User Update successful";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User Update failed";
                }
            
            return response;

        }
        public Responsecs AddToCart(Cart cart,SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            SqlCommand cmd = new SqlCommand("cart_sp", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USERID",cart.USERID);
            cmd.Parameters.AddWithValue("@PRODUCTID", cart.PRODUCTID);
            cmd.Parameters.AddWithValue("@UNITPRICE", cart.UNITPRICE);
            cmd.Parameters.AddWithValue("@DISCOUNT", cart.DISCOUNT);
            cmd.Parameters.AddWithValue("@QUANTITY", cart.QUANTITY);
            cmd.Parameters.AddWithValue("@TOTALPRICE", cart.TOTALPRICE);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "item Added successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item not added. !!!failed";
            }
            return response;

        }
        public Responsecs PlaceOrder(Users user,SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            SqlCommand cmd = new SqlCommand("cart_sp", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USERID", user.ID);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order Placed successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order not placed(failed)";
            }
            return response;
        }
        public Responsecs OrderList(Users user,SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            List<Orders> listOrder = new List<Orders>();
            string query = "select * from ORDERS where USERID = @ID ";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@ID", user.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.ORDERNO = Convert.ToString(dt.Rows[i]["ORDERNO"]);
                    order.TOTALPRICE = Convert.ToDecimal(dt.Rows[i]["TOTALPRICE"]);
                    order.ORDERSTATUS = Convert.ToString(dt.Rows[i]["ORDERSTATUS"]);
                    
                    listOrder.Add(order);
                }
                if (dt.Rows.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order Details Fetched";
                    response.ListOrders = listOrder;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order Details cannot be Fetched";
                    response.ListOrders = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order Details cannot be Fetched";
                response.ListOrders = null;
            }
            return response;
        }
        public Responsecs AddUpdateProducts(Products product,SqlConnection connection)
        {
            Responsecs response = new Responsecs();

            SqlCommand cmd = new SqlCommand("sp_AddUpdateProducts",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", product.ID);
            cmd.Parameters.AddWithValue("@NAME", product.NAME);
            cmd.Parameters.AddWithValue("@PRICE", product.PRICE);
            cmd.Parameters.AddWithValue("@DISCOUNT", product.DISCOUNT);
            cmd.Parameters.AddWithValue("@QUANTITY", product.QUANTITY);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "product added/updated successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "product added/updated failed";
            }


            return response;
        }
        public Responsecs UsersList(SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            List<Users> listUser = new List<Users>();
            string query = "select * from Users";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users users = new Users();
                    users.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    users.FIRSTNAME = Convert.ToString(dt.Rows[i]["FIRSTNAME"]);
                    users.LASTNAME = Convert.ToString(dt.Rows[i]["LASTNAME"]);
                    users.EMAIL = Convert.ToString(dt.Rows[i]["EMAIL"]);
                    users.PASSWORD = Convert.ToString(dt.Rows[i]["PASSWORD"]);


                    listUser.Add(users);
                }
                if (dt.Rows.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "user Details Fetched";
                    response.ListUsers = listUser;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User Details cannot be Fetched";
                    response.ListUsers = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Details cannot be Fetched";
                response.ListUsers = null;
            }
            return response;
        }
        public Responsecs RegAnalytics(SqlConnection connection) { 


            Responsecs response = new Responsecs();
            string query = "select REG_DATE as DATE,count(REG_DATE) as USERS from Users Group by REG_DATE order by REG_DATE asc";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            da.SelectCommand.CommandType = CommandType.Text;
           

            List<DateTime> t1 = new List<DateTime>();
            List<int> t2 = new List<int>();
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var temp1 = Convert.ToDateTime(dt.Rows[i]["DATE"]);
                    var temp2 = Convert.ToInt32(dt.Rows[i]["USERS"]);
                    t1.Add(temp1);
                    t2.Add(temp2);
                }
                response.StatusCode = 100;
                response.StatusMessage = "Analytics can be Fetched";
                response.num_users = t2;
                response.reg_date = t1;
                
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Analytics cannot be Fetched";   
            }
            return response;
            }
        public Responsecs ProductList(SqlConnection connection)
        {
            Responsecs response = new Responsecs();
            string Query = "select * from Products";
            SqlDataAdapter da = new SqlDataAdapter(Query, connection);
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            Users users = new Users();
            List<Products> lp = new List<Products>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Products product = new Products();
                    product.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    product.NAME = Convert.ToString(dt.Rows[i]["NAME"]);
                    product.PRICE= Convert.ToDecimal(dt.Rows[i]["PRICE"]);
                    product.QUANTITY = Convert.ToInt32(dt.Rows[i]["QUANTITY"]);
                    product.DISCOUNT = Convert.ToDecimal(dt.Rows[i]["DISCOUNT"]);

                    lp.Add(product);
                }
                response.StatusCode = 200;
                response.StatusMessage = "Products are fetched";
                response.ListProducts = lp;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Products cannot be fetched";
                response.ListProducts = null;
            }
            return response;
        } 
    }
}
