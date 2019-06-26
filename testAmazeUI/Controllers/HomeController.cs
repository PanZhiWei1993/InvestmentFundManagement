using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testAmazeUI.Models;

namespace testAmazeUI.Controllers
{
    public class HomeController : BaseController
    {
       
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult UserInfo()
        {
            var result = new ResultModel();
            do
            {       
                result.ResultCode = 1;
                result.ResultData = new { UserName = loginUser.UserName, UserIcon = Url.Content(@"~\res\assets\img\user01.png") };
            } while (false);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Login()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}