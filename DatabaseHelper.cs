using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Assignment_SD
{
    public static class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ECommerceInvoices"].ConnectionString;

        public static int InsertSeller(string name, string address, string city, string state, string pincode, string panNo, string gstNo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertSeller", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Pincode", pincode);
                cmd.Parameters.AddWithValue("@PANNo", panNo);
                cmd.Parameters.AddWithValue("@GSTNo", gstNo);

                SqlParameter outputId = new SqlParameter("@SellerID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outputId);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)outputId.Value;
            }
        }

        public static int InsertOrder(string orderNo, DateTime orderDate, int sellerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertOrder", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderNo", orderNo);
                cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                SqlParameter outputId = new SqlParameter("@OrderID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outputId);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)outputId.Value;
            }
        }

        public static int InsertInvoice(string invoiceNo, DateTime invoiceDate, bool reverseCharge, int orderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                cmd.Parameters.AddWithValue("@InvoiceDate", invoiceDate);
                cmd.Parameters.AddWithValue("@ReverseCharge", reverseCharge);
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                SqlParameter outputId = new SqlParameter("@InvoiceID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outputId);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)outputId.Value;
            }
        }

        public static int InsertItem(string description, decimal unitPrice, int quantity, decimal discount, int invoiceID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);

                SqlParameter outputId = new SqlParameter("@ItemID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outputId);

                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)outputId.Value;
            }
        }
    }
}