using System.Collections.Generic;
using System.Web.Mvc;

namespace FindJob.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        FindJob.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
        //
        // GET: /admin/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 企业模块管理
        /// </summary>
        /// <returns></returns>
        public ActionResult EPIndex()
        {
            return View();
        }
     
        public JsonResult EPGetList(int pageSize, int pageIndex, string EPName)
        {

            List<FindJob.Model.T_Base_Enterprise> lst = new List<FindJob.Model.T_Base_Enterprise>();
            lst = bll.GetList(pageIndex, pageSize, EPName);
            int count = bll.EPCount();
            return Json(new { total = count, rows = lst });
            //return Json(lst);
        }
        public JsonResult EPDelete(string []Ids)
        {
            FindJob.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            bll.EPDelete(Ids);
            return Json(new FindJob.Model.Message() { Code = 1, Content = "删除成功" });
        }
        /// <summary>
        /// 学生模块管理
        /// </summary>
        /// <returns></returns>
        public ActionResult StuIndex()
        {
            return View();
        }
        public JsonResult StuGetList(int pageSize, int pageIndex, string StuName,string SchoolName,string MajorName,string ClassName)
        {

            List<FindJob.Model.T_Base_Student> lst = new List<FindJob.Model.T_Base_Student>();
            lst = bll.GetList(pageIndex, pageSize, StuName, SchoolName,MajorName, ClassName);
            int count = bll.EPCount();
            return Json(new { total = count, rows = lst });
            //return Json(lst);
        }
        public JsonResult StuDelete(string[] Ids)
        {
            FindJob.BLL.T_Base_Admin bll = new BLL.T_Base_Admin();
            bll.EPDelete(Ids);
            return Json(new FindJob.Model.Message() { Code = 1, Content = "删除成功" });
        }

        public ActionResult ApplyJobIndex()
        {
            return View();
        }
        public JsonResult ApplyJobGetList(int pageSize, int pageIndex, string StuName, string SchoolName, string MajorName, string ClassName)
        {

            List<FindJob.Model.T_Relation_ApplyJob> lst = new List<FindJob.Model.T_Relation_ApplyJob>();
            lst = bll.ApplyJobGetList(pageIndex, pageSize, StuName, SchoolName, MajorName, ClassName);
            int count = bll.ApplyJobCount();
            return Json(new { total = count, rows = lst });
            //return Json(lst);
        }
        public ActionResult EPCheck()
        {
            return View();
        }
        public JsonResult EPCheckGetList(int pageSize, int pageIndex, string EPName)
        {

            List<FindJob.Model.T_Base_Enterprise> lst = new List<FindJob.Model.T_Base_Enterprise>();
            lst = bll.EPCheckGetList(pageIndex, pageSize, EPName);
            int count = bll.EPCheckCount();
            return Json(new { total = count, rows = lst });
            //return Json(lst);
        }
    }
}