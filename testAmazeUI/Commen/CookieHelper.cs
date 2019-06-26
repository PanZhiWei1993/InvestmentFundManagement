using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace testAmazeUI.Commen
{
    /// <summary>
    /// 操作Cookie相关帮助类
    /// </summary>
    public class CookieHelper
    {
        private HttpResponseBase Response = null;       
        public CookieHelper(HttpResponseBase _Response)
        {
            this.Response =_Response;
        }
        /// <summary>
        /// 添加/更新cookie的方法
        /// </summary>
        /// <param name="name">cookie名称</param>
        /// <param name="value">cookie值</param>
        /// <param name="outTimeMin">过期时间</param>
        /// <returns></returns>
        public bool SetCookieInfo(string name, string value, int outTimeMin)
        {      
            try
            {
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(1), false, value);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(Ticket));//加密身份信息，保存至Cookie
                cookie.HttpOnly = true;
                Response.SetCookie(cookie);
                Response.Cookies.Add(cookie);
                return  true;
            }
            catch (Exception ex)
            {
                return false;
            }         
        }
        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookieInfo(string key)
        {
            string result = "";
            try
            {
                var cookie = Response.Cookies[key];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                result = ticket.UserData;
            }
            catch (Exception ex)
            {
                throw;
            }   
            return result;
        }
        /// <summary>
        /// 删除某cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DelCookieInfo(string key) {
            try
            {
                var cookie = Response.Cookies[key];
                if(cookie!=null)
                    cookie.Expires = DateTime.Now.AddDays(-1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
        }
    }
}
