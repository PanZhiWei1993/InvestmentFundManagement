
using RDO.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testAmazeUI.Models;
using testAmazeUI.Models.selTableView;
using testAmazeUI.Models.tableView;

namespace testAmazeUI.Controllers
{
    public class UserManegeController : BaseController
    {

        #region ##页面初始化##
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassWord()
        {
            return View();
        }
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult UserManegeView()
        {
            return View();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserView()
        {
            return View();
        }
        /// <summary>
        /// 用户信息页
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInfoView() {
            string userId = Request["userId"];
            var selUserInfo = new tb_user();
            if (!String.IsNullOrEmpty(userId)) {
                selUserInfo = loginUser;
            }
            else {
                selUserInfo = GetUserInfoById(userId);
            }
            ViewBag.SelUserInfo = selUserInfo;
            return View();
        }

        //public PartialViewResult _SelUserList(List<tb_UserList> data)
        //{
        //    //TableHelper _TableHelper = new TableHelper(data);
        //    //return PartialView("_normalTable", _TableHelper);
        //}
        #endregion
        #region ##接口##
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]       
        public JsonResult AddUser(AddUser userInfo) {
            ResultModel resultModel = new ResultModel();
            tb_user _User = new tb_user();
            _User.Id = GetNewGuid();
            _User.InsertTime = DateTime.Now;            
            _User.UpdateTime = DateTime.Now;
            _User.Mobile = userInfo.UserPhone!=null? userInfo.UserPhone : "";
            _User.Email = userInfo.UserEmail != null ? userInfo.UserEmail : "";
            _User.UserName = userInfo.UserName != null ? userInfo.UserName : "";
            _User.Utype = userInfo.UserRole;

            var newPassword = GetUserIntilPassWord();
            _User.Password = newPassword.MD5_Password;
            _User.Account =String.IsNullOrEmpty(userInfo.UserAccount)? GetNewAccount():userInfo.UserAccount;
            _User.Status = 0;
            if (_userBusiness.AddNewUser(_User))
            {
                resultModel.ResultCode = 1;
                resultModel.ResultMsg = string.Format("创建成功，账号为{0}，密码为{1}", _User.Account, newPassword.Password);
            }
            else
            {
                resultModel.ResultMsg = "创建失败！";
            }
            return Json(resultModel);
        }      
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="selUserList"></param>
        /// <returns></returns>
        public JsonResult SelectUserListByQuery(SelUserList selUserList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper =selUserList.ConvertToT<TableHelper>();
            try
            {               
                PageHelper pageHelper = new PageHelper(_TableHelper.PageIndex,_TableHelper.PageSize);
                var queryUserList = _userBusiness.GetUserInfoByUNameAndUEmail(selUserList.uName, selUserList.uEmail)
                    .Select(u => new
                     {
                         Id = u.Id,
                         UserName = u.UserName,
                         Account = u.Account,
                         Mobile = u.Mobile,
                         Email = u.Email,
                         Utype = u.Utype == 0 ? "内部人员" : "外部人员",
                         InsertTime = u.InsertTime
                     });
                var userList = PagingFunction(queryUserList,ref pageHelper);
                _TableHelper.data = userList.ConvertToExpand();
                string tableHtml = RenderPartialViewToString(this, "_normalTable", _TableHelper);
                // string tableHtml = PartialView("_normalTable", _TableHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = tableHtml,pageInfo= pageHelper };
                //_TableHelper.data = queryUserList.ConvertToExpand();
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return Json(result);
        }
        public JsonResult SelectUserInfoByuId(string Id) {
            ResultModel result = new ResultModel();
            try
            {
                var data = GetUserInfoById(Id);
                result.ResultCode = 1;
                result.ResultData = data;
            }
            catch (Exception)
            {
                result.ResultMsg = "数据异常！";
               
            }
            return Json(result);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public JsonResult UserChangePassWord(string oldPassword, string newPassword) {
            ResultModel result = new ResultModel();
            try
            {
                do
                {
                    var _loginUser = GetUserInfoByLogin(loginUser.Account, oldPassword);
                    if (_loginUser == null)
                    {
                        result.ResultMsg = "密码错误！";
                        break;
                    }
                    loginUser.Password = GetMD5Password(newPassword);
                    ef.SaveChanges();
                    result.ResultCode = 1;                   
                } while (false);             
            }
            catch (Exception ex)
            {
                result.ResultMsg = "系统错误，修改失败！";
            }
            return Json(result);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userIcon"></param>
        /// <returns></returns>
        public JsonResult UserChangeInfo(tb_user userInfo) {
            ResultModel result = new ResultModel();
            try
            {
                if (userInfo.Id == loginUser.Id)
                {
                    var nowUser = _userBusiness.GetUserInfoById(loginUser.Id).FirstOrDefault();
                    nowUser = userInfo.ConvertToT<tb_user>(nowUser);
                    ef.SaveChanges();

                    //删除cookie信息，删除缓存
                    DelCookieInfo(loginUser.Account);
                    nowUser.AccountIcon = nowUser.AccountIcon.Replace("~", BaseUrl);
                    result.ResultCode = 1;
                    result.ResultData = nowUser;
                }
                else
                {
                    result.ResultMsg = "您无此权限！";
                }
               
            }
            catch (Exception)
            {
              
            }
            return Json(result);
        }
        #endregion
        #region ##私有方法##
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        private tb_user GetUserInfoById(string uId) {
            tb_user result = new tb_user();
            try
            {
                result=_userBusiness.GetUserInfoById(loginUser.Id).FirstOrDefault();
                if(result!=null)
                result.AccountIcon = result.AccountIcon.Replace("~", BaseUrl);
            }
            catch (Exception)
            {

              
            }
            return result;
        }
        /// <summary>
        /// 获取用户新账号
        /// </summary>
        /// <returns></returns>
        protected string GetNewAccount() {
            string userCon = (_userBusiness.SelectUserAllCount()+1).ToString();
            return ExpandString.AheadFillCharacter(userCon, "0", 5);
        }
        #endregion


    }
}