using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace testAmazeUI.Business
{
    /// <summary>
    /// 用户业务
    /// </summary>
    public class UserBusiness:BaseBusiness
    {
        public UserBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        /// <summary>
        /// 用户名密码获取登入账户
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public tb_user GetUserByLogin(string userAccount, string passWord)
        {
            tb_user result = new tb_user();
            try
            {
                string sql =string.Format("select * from tb_user u where u.Account={0} and u.Password={1}", userAccount, passWord);
                result = ef.tb_user.Where(u => u.Account == userAccount && u.Password == passWord).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 根据用户名和邮箱查询用户
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uEmail"></param>
        /// <returns></returns>
        public IQueryable<tb_user> GetUserInfoByUNameAndUEmail(string uName, string uEmail) {
            IQueryable <tb_user> query= GetAllUserInfo();
            if (!String.IsNullOrEmpty(uName))
            {
                query = query.Where(q => q.UserName.Contains(uName));
            }
            if (!String.IsNullOrEmpty(uEmail))
            {
                query = query.Where(q => q.Email.Contains(uEmail));
            }
            return query;
        }

        public IQueryable<tb_user> GetUserInfoById(string uId) {
            return GetAllUserInfo().Where(u => u.Id == uId);
        }

        /// <summary>
        /// 获取一般用户列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_user> GetNUserList() {
            return GetUListByUserType(1);
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_user> GetManegerList() {
            return GetUListByUserType(0);
        }

        /// <summary>
        /// 根据用户类型获取用户列表
        /// </summary>
        /// <param name="type">0管理员，1一般用户</param>
        /// <returns></returns>
        private IQueryable<tb_user> GetUListByUserType(int type) {
            return GetAllUserInfo().Where(u => u.Utype == type);
        }

        /// <summary>
        /// 获取全部有效用户信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_user> GetAllUserInfo() {
            return ef.tb_user.OrderByDescending(u => u.InsertTime);
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
                    FormsAuthentication.SetAuthCookie(user.Account, false);
                    //SetCookieInfo(user.UserName, JsonConvert.SerializeObject(user), 7200);
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
        /// 新增用户
        /// </summary>
        /// <param name="_User"></param>
        /// <returns></returns>
        public bool AddNewUser(tb_user _User)
        {
            try
            {               
                ef.tb_user.Add(_User);
                ef.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        /// <summary>
        /// 获取总用户数
        /// </summary>
        /// <returns></returns>
        public int SelectUserAllCount() {
            int result = -1;
            try
            {
                result = ef.tb_user.Count();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
           
    }
}