using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UberEatsWebApi.Models;

namespace UberEatsWebApi.Data
{
    public class DBConnect
    {
        static string connectString = "SERVER=localhost;UID=root;pwd=root;DATABASE=UberEatsMobile;";
        public MySqlDataReader reader;
        public MySqlConnection connection;
        public MySqlCommand command;
        public Products product;

        //Register
        public string AddCust(Customer cust)
        {
            string x = "";

            using (connection = new MySqlConnection())
            {
                connection.ConnectionString = connectString;

                string query = "INSERT INTO UberEatsMobile.Customer(firstName, lastName, phoneNumber, email, password, creditCard, CVV, expiryDate, zipCode, userRole) " +
                    "VALUES('" + cust.FirstName + "','" + cust.LastName + "','" + cust.PhoneNumber + "','" + cust.Email + "','" + cust.Password + "','" + cust.CreditCard + "','" + cust.CVV + "','" + cust.ExpiryDate + "','" + cust.ZipCode + "','" + cust.UserRole + "');";


                using (command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        command.Connection.Open();

                        command.Parameters.AddWithValue("@Firstname", cust.FirstName);
                        command.Parameters.AddWithValue("@Lastname", cust.LastName);
                        command.Parameters.AddWithValue("@phoneNumber", cust.PhoneNumber);
                        command.Parameters.AddWithValue("@email", cust.Email);
                        command.Parameters.AddWithValue("@password", cust.Password);
                        command.Parameters.AddWithValue("@creditCard", cust.CreditCard);
                        command.Parameters.AddWithValue("@CVV", cust.CVV);
                        command.Parameters.AddWithValue("@expiryDate", cust.ExpiryDate);
                        command.Parameters.AddWithValue("@zipCode", cust.ZipCode);
                        command.Parameters.AddWithValue("@userRole", cust.UserRole);

                        int y = command.ExecuteNonQuery();

                        x = y.ToString();

                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                        command.Connection.Close();
                    }
                }
                return null;
            }
        }


        //Login

        public Customer CustomerLogin(string email, string passwords)
        {
            string sql = "SELECT * FROM UberEatsMobile.Customer WHERE email='" + email + "'AND password='" + passwords + "';";

            using (connection = new MySqlConnection())
            {
                connection.ConnectionString = connectString;
                command = new MySqlCommand(sql, connection);
                command.Connection = connection;

                try
                {
                    command.Connection.Open();
                    command.Parameters.Add(new MySqlParameter("@email", email));
                    command.Parameters.Add(new MySqlParameter("@password", passwords));

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        return new Customer(Convert.ToInt32(reader["id"]),
                                                Convert.ToString(reader["firstName"]),
                                                Convert.ToString(reader["lastName"]),
                                                Convert.ToString(reader["phoneNumber"]),
                                                Convert.ToString(reader["email"]),
                                                Convert.ToString(reader["password"]),
                                                Convert.ToString(reader["creditCard"]),
                                                Convert.ToString(reader["CVV"]),
                                                Convert.ToString(reader["expiryDate"]),
                                                Convert.ToString(reader["zipCode"]),
                                                Convert.ToString(reader["userRole"]));
                    }
                    reader.Close();
                }
                catch (MySqlException exception)
                {
                    command.Connection.Close();
                    exception.ToString();
                }
                return null;
            }
        }


        //Update customer information
        public Customer CustomerUpdate(Customer cust, int id)
        {
            string sql = "UPDATE UberEatsMobile.Customer SET firstName='" + cust.FirstName + "', lastName='" + cust.LastName + "',phoneNumber='" + cust.PhoneNumber + "' WHERE id=" + id + ";";
            using (connection = new MySqlConnection())
            {
                connection.ConnectionString = connectString;
                using (command = new MySqlCommand(sql, connection))
                {

                    command.Connection = connection;
                    try
                    {
                        command.Connection.Open();

                        command.Parameters.Add(new MySqlParameter("firstName", cust.FirstName));
                        command.Parameters.Add(new MySqlParameter("lastName", cust.LastName));
                        command.Parameters.Add(new MySqlParameter("phoneNumber", cust.PhoneNumber));
                        command.Parameters.Add(new MySqlParameter("email", cust.Email));
                        command.Parameters.Add(new MySqlParameter("password", cust.Password));


                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            return cust = new Customer(Convert.ToInt32(reader["id"]),
                                                Convert.ToString(reader["firstName"]),
                                                Convert.ToString(reader["lastName"]),
                                                Convert.ToString(reader["phoneNumber"]),
                                                Convert.ToString(reader["email"]),
                                                Convert.ToString(reader["password"]),
                                                Convert.ToString(reader["creditCard"]),
                                                Convert.ToString(reader["CVV"]),
                                                Convert.ToString(reader["expiryDate"]),
                                                Convert.ToString(reader["zipCode"]),
                                                Convert.ToString(reader["userRole"]));

                        }
                        reader.Close();

                    }
                    catch (MySqlException exception)
                    {
                        exception.ToString();

                    }
                    finally
                    {
                        command.Connection.Close();
                    }
                }
                return cust;
            }
        }

        //Gettuing all the products from the database

        public Products[] GetProduct()
        {
            List<Products> productList = new List<Products>();

            using (connection = new MySqlConnection())
            {
                connection.ConnectionString = connectString;

                string querys = "SELECT * FROM UberEatsMobile.Products;";
                using (command = new MySqlCommand(querys, connection))
                {
                    try
                    {
                        command.Connection.Open();


                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            product = new Products(Convert.ToInt32(reader["Id"]),
                                                   Convert.ToString(reader["ItemName"]),
                                                   Convert.ToDouble(reader["ItemPrice"]),
                                                   (byte[])(reader["ItemImage"]),
                                                   Convert.ToString(reader["Description"]),
                                                   Convert.ToString(reader["ItemType"]));

                            productList.Add(product);

                        }
                        reader.Close();
                        reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                        reader.Read();
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        ex.ToString();
                    }
                    finally
                    {
                        command.Connection.Close();
                    }
                }
                return productList.ToArray();
            }
        }


        //Get Restaurants
        /** public Restaurant[] GetRestaurant()
         {
             List<Restaurant> restaurants = new List<Restaurant>();

             using (MySqlConnection connect = new MySqlConnection())
             {
                 connect.ConnectionString = connectString;

                 string querys = "SELECT res_Id,Res_Name,Res_Location,Res_City,Image FROM MyAppData.Restaurants;";
                 using (MySqlCommand comma = new MySqlCommand(querys, connect))
                 {
                     try
                     {
                         comma.Connection.Open();
                         Restaurant res = new Restaurant();

                         read = comma.ExecuteReader();
                         while (read.Read())
                         {
                             res = new Restaurant(Convert.ToInt32(read["res_Id"]),
                                                 Convert.ToString(read["Res_Name"]),
                                                 Convert.ToString(read["Res_Location"]),
                                                 Convert.ToString(read["Res_City"]),
                                                  (byte[])(read["Image"])

                                                );
                             restaurants.Add(res);

                         }
                         read.Close();
                         MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                         reader.Read();
                         reader.Close();
                     }
                     catch (MySqlException ex)
                     {
                         ex.ToString();
                     }
                     finally
                     {
                         comma.Connection.Close();
                     }
                 }
                 return restaurants.ToArray();
             }

         }

         //Make Payment
         public string payments(Payment pay)
         {
             string x = "";
             using (MySqlConnection connect = new MySqlConnection())
             {
                 connect.ConnectionString = connectString;
                 string query = "INSERT INTO MyAppData.Payment(CardName,CardNumber,Cvv,cust_Id) " +
                     "VALUES('" + pay.CardName + "','" + pay.CardNumber + "','" + pay.Cvv + "','" + pay.cust_Id + "');";
                 using (MySqlCommand comma = new MySqlCommand(query, connect))
                 {
                     try
                     {
                         comma.Connection.Open();

                         comma.Parameters.AddWithValue("@CardName", pay.CardName);
                         comma.Parameters.AddWithValue("@CardNumber", pay.CardNumber);
                         comma.Parameters.AddWithValue("@Cvv", pay.Cvv);
                         comma.Parameters.AddWithValue("@cust_Id", pay.cust_Id);
                         int y = comma.ExecuteNonQuery();

                         x = y.ToString();

                     }
                     catch (MySqlException ex)
                     {
                         ex.ToString();
                         comma.Connection.Close();
                     }
                 }
                 return null;
             }
         }

         //Place an Order

         public string Orders(Order ord)
         {
             string x = "";
             using (MySqlConnection connect = new MySqlConnection())
             {
                 connect.ConnectionString = connectString;
                 string query = "INSERT INTO MyAppData.Order(cust_id,totalAmount,quantity,address) " +
                     "VALUES('" + ord.cust_id + "','" + ord.totalAmount + "','" + ord.quantity + "','" + ord.address + "');";
                 using (MySqlCommand comma = new MySqlCommand(query, connect))
                 {
                     try
                     {
                         comma.Connection.Open();

                         comma.Parameters.AddWithValue("@cust_id", ord.cust_id);
                         comma.Parameters.AddWithValue("@totalAmount", ord.totalAmount);
                         comma.Parameters.AddWithValue("@quantity", ord.quantity);
                         comma.Parameters.AddWithValue("@address", ord.address);
                         int y = comma.ExecuteNonQuery();

                         x = y.ToString();

                     }
                     catch (MySqlException ex)
                     {
                         ex.ToString();
                         comma.Connection.Close();
                     }
                 }
                 return null;
             }
         }

         //Gettuing all the products from the database

         public Product[] GetProduct()
         {
             List<Product> restaurants = new List<Product>();

             using (MySqlConnection connect = new MySqlConnection())
             {
                 connect.ConnectionString = connectString;

                 string querys = "SELECT prodId,ProdName,ProdpPrice,Image FROM MyAppData.Products;";
                 using (MySqlCommand comma = new MySqlCommand(querys, connect))
                 {
                     try
                     {
                         comma.Connection.Open();
                         Product prod = new Product();

                         read = comma.ExecuteReader();
                         while (read.Read())
                         {
                             prod = new Product(Convert.ToInt32(read["prodId"]),
                                                 Convert.ToString(read["ProdName"]),
                                                 Convert.ToString(read["ProdpPrice"]),
                                                  (byte[])(read["Image"])

                                                );
                             restaurants.Add(prod);

                         }
                         read.Close();
                         MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                         reader.Read();
                         reader.Close();
                     }
                     catch (MySqlException ex)
                     {
                         ex.ToString();
                     }
                     finally
                     {
                         comma.Connection.Close();
                     }
                 }
                 return restaurants.ToArray();
             }

         }**/


    }

}
