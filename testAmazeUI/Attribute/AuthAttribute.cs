using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testAmazeUI.Attribute
{
    /// <summary>
    /// 基于特性的身份验证
    /// </summary>
    public class AuthAttribute: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.HttpContext.User.Identity.IsAuthenticated
            //跳过方法和类的匿名用户特性验证
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //如果存在身份信息
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    ContentResult Content = new ContentResult();
                    Content.Content = string.Format("<script type='text/javascript'>alert('请先登录！');window.location.href='{0}';</script>", new UrlHelper(filterContext.RequestContext).Content("~/Login"));
                    filterContext.Result = Content;
                }
                //验证权限
                else
                {

                }
            }
        }
    }
}