using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ORMAdonet.Models
{
    public class CRUD
    {
        private string _connectionString = @"Data Source=IN-FHB5P93\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;User Id=sa;Password=sa";

        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from SalesLT.Customer", sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public DataTable GetCustomerById(int customerid)
        {
            DataTable dataTable = new DataTable();

            // string _connectionString = @"Data Source=IN-FHB5P93\SQLEXPRESS;Initial Catalog=paginationDb;User Id=sa; Password=sa";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Select * from SalesLT.Customer where CustomerId=" + customerid, sqlConnection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dataTable);
            }

            return dataTable;
        }

        public int CreateCustomer(int CustomerID, string FirstName, string LastName, string CompanyName, string SalesPerson, string EmailAddress, string Phone)
        {
            // string strConString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=paginationDb;User Id=sa; Password=sa";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO Customers(CustomerID, FirstName,LastName,CompanyName, SalesPerson,EmailAddress, Phone) VALUES (@customerid,@firstname, @lastname , @companyname, @salesperson, @email, @phone)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@customerid", CustomerID);
                cmd.Parameters.AddWithValue("@firstname", FirstName);
                cmd.Parameters.AddWithValue("@lastname", LastName);
                cmd.Parameters.AddWithValue("@companyname", CompanyName);
                cmd.Parameters.AddWithValue("@salesperson", SalesPerson);
                cmd.Parameters.AddWithValue("@eamil", EmailAddress);
                cmd.Parameters.AddWithValue("@phone", Phone);
                return cmd.ExecuteNonQuery();
            }
        }

        internal int CreateCustomer(int CustomerID, string firstName, string lastName, string companyName, string emailAddress, string phone)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(int CustomerID, string FirstName, string LastName, string CompanyName, string SalesPerson, string EmailAddress, string Phone)
        {
            //string strConString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=paginationDb;User Id=sa;Password=sa";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "Update Customers SET FirstName=@firstname, LastName=@lastname , Contact=@contact, Email=@email where Id=@customerid";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@firstname", FirstName);
                cmd.Parameters.AddWithValue("@lastname", LastName);
                cmd.Parameters.AddWithValue("@companyname", CompanyName);
                cmd.Parameters.AddWithValue("@salesperson", SalesPerson);
                cmd.Parameters.AddWithValue("@email", EmailAddress);
                cmd.Parameters.AddWithValue("@phone", Phone);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            //string strConString = @"Data Source=IN-B2WMGK3\SQLEXPRESS;Initial Catalog=paginationDb;User Id=sa; Password=sa";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "Delete from Customers where CustomerId=@customerid";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }

        internal int UpdateCustomer(int customerID, string firstName, string lastName, string companyName, string emailAddress, string phone)
        {
            throw new NotImplementedException();
        }

        internal int UpdateCustomer(string firstName, string lastName, string companyName, string emailAddress, string phone)
        {
            throw new NotImplementedException();
        }
    }
}