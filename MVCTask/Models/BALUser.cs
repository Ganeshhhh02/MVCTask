using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCTask.Models
{
    public class BALUser
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-VMIN6I0G;Initial Catalog=ASPProject;Integrated Security=True;Encrypt=False");
        public DataSet FetchCountry()
        {
            con.Close();
            con.Open();
            SqlCommand cmd =new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FetchCountry");
            SqlDataAdapter adpt=new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet FetchState(int CountryId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FetchState");
            cmd.Parameters.AddWithValue("@CountryID", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public DataSet FetchCity(int StateId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FetchCity");
            cmd.Parameters.AddWithValue("@StateId", StateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public void SaveData(User objU)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RegisterUser");
            cmd.Parameters.AddWithValue("@Name", objU.Name);
            cmd.Parameters.AddWithValue("@address", objU.address);
            cmd.Parameters.AddWithValue("@Email", objU.Email);
            cmd.Parameters.AddWithValue("@Mobile", objU.MobileNo);
            cmd.Parameters.AddWithValue("@Gender", objU.Gender);
            cmd.Parameters.AddWithValue("@CityId", objU.CityId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ShowDetails()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowDetails");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds=new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close() ;
        }

        public SqlDataReader EditDetails(int Id)
        {
            con.Open() ;
            SqlCommand cmd = new SqlCommand("AspMain",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "EditDetails");
            cmd.Parameters.AddWithValue("Id",Id );
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            con.Close () ;
        }

        public SqlDataReader GetDetails(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetDetails");
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public void Delete (int Id)
        {   
            con.Open() ;
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.ExecuteNonQuery();
            con.Close() ;

        }

        public void UpdateData(User objU)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AspMain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateDetails");
            cmd.Parameters.AddWithValue("@Id", objU.Id);
            cmd.Parameters.AddWithValue("@Name", objU.Name);
            cmd.Parameters.AddWithValue("@address", objU.address);
            cmd.Parameters.AddWithValue("@Email", objU.Email);
            cmd.Parameters.AddWithValue("@Mobile", objU.MobileNo);
            cmd.Parameters.AddWithValue("@Gender", objU.Gender);
            cmd.Parameters.AddWithValue("@CityId", objU.CityId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}