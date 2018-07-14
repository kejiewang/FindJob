using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace FindJob.DAL
{
    public class T_Base_Admin
    {
        public string constr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        public List<FindJob.Model.T_Base_Enterprise> GetList(int CurrentPage, int PageSize, string EPName)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = constr;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            //cm.CommandText = "select * from t_base_FindJob";
            EPName = "'%" + EPName + "%'";

            cm.CommandText = "select top " + PageSize + " * from  T_Base_Enterprise where id not in (select top " + PageSize * (CurrentPage - 1) + " id from T_Base_Enterprise where ischecked=1 and Name like " + EPName + ")   and ischecked = 1  and  Name like " + EPName;
            //cm.Parameters.AddWithValue("@pageSize", PageSize);
            //cm.Parameters.AddWithValue("@beforeCount", PageSize * (CurrentPage - 1));
            SqlDataReader dr = cm.ExecuteReader();
            List<FindJob.Model.T_Base_Enterprise> lst = new List<Model.T_Base_Enterprise>();
            while (dr.Read())
            {
                FindJob.Model.T_Base_Enterprise EP = new Model.T_Base_Enterprise();
                //FindJob.Model.T_Base_EnterpriseHead head = new Model.T_Base_EnterpriseHead();
                EP.Id = Convert.ToInt32(dr["Id"]);
                
                EP.Name = Convert.ToString(dr["Name"]);
                EP.Tel = Convert.ToString(dr["Tel"]);
                EP.Address = Convert.ToString(dr["Address"]);
                EP.Introduction = Convert.ToString(dr["Introduction"]);
                EP.Qualification = Convert.ToString(dr["Qualification"]);
                EP.IsChecked = Convert.ToBoolean(dr["IsChecked"]);
                EP.UserId = Convert.ToInt32(dr["UserId"]);
               
                lst.Add(EP);
            }
            dr.Close();
            co.Close();
            return lst;
        }
        public int EPCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = constr;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(*) from T_Base_Enterprise where ischecked=1";
            object obj = cm.ExecuteScalar();
            co.Close();
            return (int)obj;
        }
        public int EPDelete(string ids)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = constr;
            co.Open();
            SqlCommand cm = new SqlCommand();
            //cm.CommandText = "delete from t_stock_inItems where headid in (" + ids + ");delete from t_stock_inhead where id in (" + ids + ") ; ";
            cm.CommandText = "delete from T_Base_Enterprise where id in (" + ids + ") ; ";
            cm.Connection = co;
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }
        /// <summary>
        /// 学生模块
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="EPName"></param>
        /// <returns></returns>
        public List<FindJob.Model.T_Base_Student> GetList(int CurrentPage, int PageSize, string StuName,string SchoolName, string MajorName, string ClassName)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = constr;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
         
            StuName = "'%" + StuName + "%'";
            SchoolName = "'%" + SchoolName + "%'";
            MajorName = "'%" + MajorName + "%'";
            ClassName = "'%" + ClassName + "%'";

            cm.CommandText = "select top " + PageSize + " * from  T_Base_Student where  id not in (select top " + PageSize * (CurrentPage - 1) + " id from T_Base_Student where ischeck=1 and Name like " + StuName + " and Major like " +MajorName+" and Class like " +ClassName+ " and School like "+SchoolName+") and  Name like " + StuName+ " and Major like " + MajorName + " and Class like " + ClassName+ " and ischeck = 1 and School like " + SchoolName ;
            //cm.Parameters.AddWithValue("@pageSize", PageSize);
            //cm.Parameters.AddWithValue("@beforeCount", PageSize * (CurrentPage - 1));
            SqlDataReader dr = cm.ExecuteReader();
            List<FindJob.Model.T_Base_Student> lst = new List<Model.T_Base_Student>();
            while (dr.Read())
            {
                FindJob.Model.T_Base_Student Stu = new Model.T_Base_Student();
                //FindJob.Model.T_Base_EnterpriseHead head = new Model.T_Base_EnterpriseHead();
                Stu.Id = Convert.ToInt32(dr["Id"]);

                Stu.Name = Convert.ToString(dr["Name"]);
                Stu.Major = Convert.ToString(dr["Major"]);
                Stu.Phone = Convert.ToString(dr["Phone"]);
                Stu.Class = Convert.ToString(dr["Class"]);
                Stu.School = Convert.ToString(dr["School"]);
                Stu.IdCard = Convert.ToString(dr["IdCard"]);
                Stu.UserId = Convert.ToInt32(dr["UserId"]);
                Stu.Gender = Convert.ToString(dr["Gender"]);
                lst.Add(Stu);
            }
            dr.Close();
            co.Close();
            return lst;
        }
        public int StuCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = constr;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(*) from T_Base_Student where ischeck=1";
            object obj = cm.ExecuteScalar();
            co.Close();
            return (int)obj;
        }
        public int StuDelete(string ids)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = constr;
            co.Open();
            SqlCommand cm = new SqlCommand();
            //cm.CommandText = "delete from t_stock_inItems where headid in (" + ids + ");delete from t_stock_inhead where id in (" + ids + ") ; ";
            cm.CommandText = "delete from T_Base_Student where id in (" + ids + ") ; ";
            cm.Connection = co;
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }
    }
   
}
