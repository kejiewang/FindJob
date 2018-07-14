using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FindJob.DAL
{
    public class T_Base_Enterprise
    {
        public string connstring = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;

        public int AddInfoSave(FindJob.Model.T_Base_Enterprise enterprise)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.Parameters.AddWithValue("@Name", enterprise.Name);
            cm.Parameters.AddWithValue("@Tel", enterprise.Tel);
            cm.Parameters.AddWithValue("@Address", enterprise.Address);
            cm.Parameters.AddWithValue("@Introduction", enterprise.Introduction);
            cm.Parameters.AddWithValue("@Qualification", enterprise.Qualification);
            cm.Parameters.AddWithValue("@IsChecked", false);
            cm.Parameters.AddWithValue("@UserId", enterprise.Id);
            cm.CommandText = "insert into T_Base_Enterprise values(@Name,@Tel,@Address,@Introduction,@Qualification,@IsChecked,@UserId)";
            int result = cm.ExecuteNonQuery();


            co.Close();
            return result;
        }

    }
}