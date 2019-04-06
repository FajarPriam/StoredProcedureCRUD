using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StoredProcedureCRUD.Models;

namespace StoredProcedureCRUD.Data_Access
{
    public class DB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);

        public void add_record(Supplier supplier)
        {
            SqlCommand com = new SqlCommand("sp_supplier_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", supplier.Name);
            com.Parameters.AddWithValue("@CreateDate",supplier.CreateDate);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void update_record(Supplier supplier)
        {
            SqlCommand com = new SqlCommand("sp_supplier_update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", supplier.Id);
            com.Parameters.AddWithValue("@Name", supplier.Name);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet show_record_byid(int id)
        {
            SqlCommand com = new SqlCommand("sp_supplier_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet show_data()
        {
            SqlCommand com = new SqlCommand("sp_supplier_all", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void delete_record(int id)
        {
            SqlCommand com = new SqlCommand("sp_supplier_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}