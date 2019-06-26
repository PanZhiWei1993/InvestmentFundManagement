using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testAmazeUI.Attribute
{
    public class ErrAttribute: ActionFilterAttribute, IExceptionFilter
    {

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            //获取异常信息，入库保存
            Exception Error = filterContext.Exception;
            string title = Error.Message.Substring(0, Error.Message.Length >= 97 ? 97 : Error.Message.Length) + "...";
            string Content = string.Format(@"
                    错误标题\r\n{0}
                    错误内容\r\n{1}
                    错误地址\r\n{2}
                    ", Error.Message, Error.StackTrace, HttpContext.Current.Request.RawUrl);
            FUNDEntities db = new FUNDEntities();
            //rl_Logs errorlog = new rl_Logs()
            //{
            //    AddIP = HttpContext.Current.Request.UserHostAddress,
            //    AddTime = DateTime.Now,
            //    FK_ProductID = 1,
            //    LogContent = Content,
            //    LogTitle = title,
            //    LogType = "error"
            //};
            //db.rl_Logs.Add(errorlog);
            //db.SaveChanges();
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Default/Error/");//跳转至错误提示页面
        }
    }
}