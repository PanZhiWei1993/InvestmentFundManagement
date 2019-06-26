using Newtonsoft.Json;
using RDO.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using testAmazeUI.Business;
using testAmazeUI.Commen;
using testAmazeUI.Models;

namespace testAmazeUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
       
      
        #region 页面初始化
        /// <summary>
        /// 登入界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect(Url.Content("~/Index"));
            else
                return View();
            //return View();
        }

        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]      
        public JsonResult Login(UserLogin userInfo)
        {
            CookieHelper _cookieHelper = new CookieHelper(Response);
            ResultModel result = new ResultModel();
            userInfo = userInfo.SqlParamEscape();
            do
            {
                //登陆密码验证
                var loginUser = GetUserInfoByLogin(userInfo.Account, userInfo.Password);
                if (loginUser == null)
                {
                    result.ResultMsg = "账号或密码错误！";
                    break;
                }
                FormsAuthentication.SetAuthCookie(loginUser.Account, userInfo.IsRemember);
                SaveUserLoginInfo(loginUser);
                result.ResultCode = 1;               
            } while (false);
            return Json(result);
        }
        /// <summary>
        /// 注销登陆
        /// </summary>
        /// <returns></returns>
        public JsonResult Logout()
        {
            ResultModel result = new ResultModel();
            try
            {
                if (!string.IsNullOrEmpty(User.Identity.Name))
                    DelCookieInfo(User.Identity.Name);
                FormsAuthentication.SignOut();
                result.ResultCode = 1;
            }
            catch (Exception)
            {
                result.ResultMsg = "退出失败！";
            }
            return Json(result);
        }        
    }
}