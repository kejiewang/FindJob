using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.BLL
{
    public class T_Base_Admin
    {
        public FindJob.DAL.T_Base_Admin dal = new DAL.T_Base_Admin();
        /// <summary>
        /// 企业模块
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="EPName"></param>
        /// <returns></returns>
        public List<FindJob.Model.T_Base_Enterprise> GetList(int CurrentPage, int PageSize, string EPName)
        {
            return dal.GetList(CurrentPage, PageSize, EPName);
        }
        public int EPCount()
        {
            return dal.EPCount();
        }
        public int EPDelete(string[] ids)
        {
            //防止注入式漏洞
            string idstring = string.Join(", ", ids);
            return dal.EPDelete(idstring);
        }
        /// <summary>
        /// 学生模块
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="EPName"></param>
        /// <returns></returns>
        public List<FindJob.Model.T_Base_Student> GetList(int CurrentPage, int PageSize, string StuName,string SchoolName,string MajorName,string ClassName)
        {
            return dal.GetList(CurrentPage, PageSize, StuName, SchoolName, MajorName, ClassName);
        }
        public int StuCount()
        {
            return dal.EPCount();
        }
        public int StuDelete(string[] ids)
        {
            //防止注入式漏洞
            string idstring = string.Join(", ", ids);
            return dal.EPDelete(idstring);
        }
        public List<FindJob.Model.T_Relation_ApplyJob> ApplyJobGetList(int CurrentPage, int PageSize, string StuName, string SchoolName, string MajorName, string ClassName)
        {
            return dal.ApplyJobGetList(CurrentPage, PageSize, StuName, SchoolName, MajorName, ClassName);
        }
        public int ApplyJobCount()
        {
            return dal.ApplyJobCount();
        }
        public List<FindJob.Model.T_Base_Enterprise> EPCheckGetList(int CurrentPage, int PageSize, string EPName)
        {
            return dal.EPCheckGetList(CurrentPage, PageSize, EPName);
        }
        public int EPCheckCount()
        {
            return dal.EPCheckCount();
        }
    }
}
