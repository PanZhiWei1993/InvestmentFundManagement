using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using testAmazeUI.Attribute;
using testAmazeUI.Business;
using testAmazeUI.Commen;
using RDO.Commen;
using System.Dynamic;
using testAmazeUI.Models;
using testAmazeUI.Models.tableView;
using System.IO;
using System.Configuration;
using System.Text;

namespace testAmazeUI.Controllers
{
    //[Err, Auth]
    [Auth]
    public class BaseController : Controller
    {
        #region ##业务层初始化##
        protected FUNDEntities ef = new FUNDEntities();
        private UserBusiness userBusiness;
        public UserBusiness _userBusiness
        {
            get
            {
                if (userBusiness == null)
                {
                    userBusiness = new UserBusiness(ef);
                }
                return userBusiness;
            }
        }
        private ConstantBusiness constantBusiness ;
        public ConstantBusiness _constantBusiness
        {
            get
            {
                if (constantBusiness == null)
                {
                    constantBusiness = new ConstantBusiness(ef);
                }
                return constantBusiness;
            }
        }
        private AreaBusiness areaBusiness ;
        public AreaBusiness _AreaBusiness {
            get
            {
                if (areaBusiness == null)
                {
                    areaBusiness = new AreaBusiness(ef);
                }
                return areaBusiness;
            }
        }
        private PREBusiness preBusiness ;
        public PREBusiness _PREBusiness
        {
            get
            {
                if (preBusiness == null)
                {
                    preBusiness = new PREBusiness(ef);
                }
                return preBusiness;
            }
        }
        private FileBusiness fileBusiness ;
        public FileBusiness _FileBusiness
        {
            get
            {
                if (fileBusiness == null)
                {
                    fileBusiness = new FileBusiness(ef);
                }
                return fileBusiness;
            }
        }
        private NoticeDocmentBusiness noticeDocmentBusiness ;
        public NoticeDocmentBusiness _NoticeDocmentBusiness
        {
            get
            {
                if (noticeDocmentBusiness == null)
                {
                    noticeDocmentBusiness = new NoticeDocmentBusiness(ef);
                }
                return noticeDocmentBusiness;
            }
        }
        private NoticeBusiness noticeBusiness ;
        public NoticeBusiness _NoticeBusiness
        {
            get
            {
                if (noticeBusiness == null)
                {
                    noticeBusiness = new NoticeBusiness(ef);
                }
                return noticeBusiness;
            }
        }
        private ProjectBusiness projectBusiness ;
        public ProjectBusiness _ProjectBusiness
        {
            get
            {
                if (projectBusiness == null)
                {
                    projectBusiness = new ProjectBusiness(ef);
                }
                return projectBusiness;
            }
        }
        private ProjectDocmentBusiness projectDocmentBusiness ;
        public ProjectDocmentBusiness _ProjectDocmentBusiness
        {
            get
            {
                if (projectDocmentBusiness == null)
                {
                    projectDocmentBusiness = new ProjectDocmentBusiness(ef);
                }
                return projectDocmentBusiness;
            }

        }
        private InterviewRecordBusiness interviewRecordBusiness ;
        public InterviewRecordBusiness _InterviewRecordBusiness
        {
            get
            {
                if (interviewRecordBusiness == null)
                {
                    interviewRecordBusiness = new InterviewRecordBusiness(ef);
                }
                return interviewRecordBusiness;
            }
        }
        private CommentBusiness commentBusiness ;       
        public  CommentBusiness _CommentBusiness {
            get
            {
                if (commentBusiness == null)
                {
                    commentBusiness = new CommentBusiness(ef);
                }
                return commentBusiness;
            }

        }

        #endregion
        //protected CookieHelper _CookieHelper = null;
        //protected static tb_user loginUser = new tb_user();
        public static string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        public static string IndexUrl = "/Index";
        public BaseController()
        {
            //if(_CookieHelper==null)
            //_CookieHelper = new CookieHelper(Response);           
        }

        /// <summary>
        /// 初始化BaseController（在构造函数中获取不到User.Identity，重写初始化函数）
        /// </summary>
        /// <param name="requestContext">封装有关与已定义路由匹配的 HTTP 请求的信息</param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //完成先前的初始化
            base.Initialize(requestContext);  
            
            if (User.Identity.IsAuthenticated)
            {
                string reUrl = "";
                try
                {
                    reUrl = Request["ReUrl"];
                }
                catch (Exception)
                {

                }
                ViewBag.ReUrl = String.IsNullOrEmpty(reUrl) ? IndexUrl : reUrl;
                ViewBag.userInfo = loginUser;              
            }
        }


        /// <summary>
        /// 当前登录的用户信息
        /// </summary>
        protected tb_user loginUser
        {
            get
            {
                tb_user result = new tb_user();
                do
                {
                    if (User == null)
                        break;
                    string userName = User.Identity.Name;
                    if (string.IsNullOrEmpty(userName)) break;
                    //从cook中获得用户信息
                    new CookieHelper(Response);
                    var userInfo = GetCookieInfo(userName);
                    if (!String.IsNullOrEmpty(userInfo))
                    {
                        result = JsonConvert.DeserializeObject<tb_user>(userInfo);
                        break;
                    }
                    else {
                        result = ef.tb_user.Where(u => u.Account == userName).FirstOrDefault();
                        result.AccountIcon = result.AccountIcon.Replace("~", BaseUrl);
                        if (result != null)
                        {
                            SaveUserLoginInfo(result);
                        }
                    }                  
                } while (false);
                return result;
            }
        }
        /// <summary>
        /// 保存用户成功登入的信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="outTimeMin"></param>
        /// <returns></returns>
        public bool SaveUserLoginInfo(tb_user user)
        {
            bool result = false;
            try
            {
                if (user != null)
                {
                    SetCookieInfo(user.Account, JsonConvert.SerializeObject(user), 7200);
                    user.Status = 2;
                    ef.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw;

            }
            return result;
        }
        /// <summary>
        /// 获取新guid
        /// </summary>
        /// <returns></returns>
        public string GetNewGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// 获取默认密码和其md5加密码
        /// </summary>
        /// <returns></returns>
        public dynamic GetUserIntilPassWord()
        {
            string dePassword = "123456";
            dynamic result = new System.Dynamic.ExpandoObject();
            result.Password = dePassword;
            result.strValue = GetMD5Password(dePassword);         
            return result;
        }
        /// <summary>
        /// md516位加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetMD5Password(string password) {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();        
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", null);
        }
        /// <summary>
        /// 根据登入信息获取用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        protected tb_user GetUserInfoByLogin(string account,string password) {
            tb_user result = null;
            try
            {
                result = _userBusiness.GetUserByLogin(account, GetMD5Password(password) );
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 分页方法，必须先orderBy
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pageHelper"></param>
        /// <returns></returns>
        public static List<dynamic> PagingFunction(IQueryable<dynamic> queryable, ref PageHelper pageHelper)
        {
            List<dynamic> result = new List<dynamic>();
            try
            {
                pageHelper.DataCount = queryable.Count();
                //多余页转最顶页
                if ((pageHelper.PageIndex - 1) * pageHelper.PageSize > pageHelper.DataCount)
                {
                    pageHelper.PageIndex = pageHelper.DataCount / pageHelper.PageSize;
                }
                var test = queryable.Skip((pageHelper.PageIndex - 1) * pageHelper.PageSize).Take(pageHelper.PageSize);
                result = queryable.Skip((pageHelper.PageIndex - 1) * pageHelper.PageSize).Take(pageHelper.PageSize).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        /// <summary>
        /// 将PartialView输出为字符串
        /// </summary>
        /// <param name="controller">Controller实例</param>
        /// <param name="viewName">如果PartialView文件在当前Controller目录下，则直接输入文件名(例:Toolbar)；否则,从根路径开始指定(例：~/Views/User/Toolbar.cshtml)</param>
        /// <param name="model">构造页面所需的的实体参数</param>
        /// <returns>字符串</returns>
        public static string RenderPartialViewToString(Controller controller, string viewName, object model)
        {
            IView view = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName).View;
            controller.ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(controller.ControllerContext, view, controller.ViewData, controller.TempData, writer);
                viewContext.View.Render(viewContext, writer);
                return writer.ToString();
            }
        }       

        #region #cookie操作#
        /// <summary>
        /// 添加/更新cookie的方法
        /// </summary>
        /// <param name="name">cookie名称</param>
        /// <param name="value">cookie值</param>
        /// <param name="outTimeMin">过期时间(分钟)</param>
        /// <returns></returns>
        public bool SetCookieInfo(string name, string value, int outTimeMin)
        {
            try
            {
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(outTimeMin), false, value);
                HttpCookie cookie = new HttpCookie(name, FormsAuthentication.Encrypt(Ticket));//加密身份信息，保存至Cookie
                cookie.HttpOnly = true;
                Response.SetCookie(cookie);
                Response.Cookies.Add(cookie);
                return true;
            }
            catch (Exception ex)
            {
                throw;
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
             
            }
            return result;
        }
        /// <summary>
        /// 删除某cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DelCookieInfo(string key)
        {
            try
            {
                var cookie = Response.Cookies[key];
                if (cookie != null)
                    cookie.Expires = DateTime.Now.AddDays(-1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion
    }
}