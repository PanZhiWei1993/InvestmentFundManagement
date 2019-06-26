using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class NoticeBusiness:BaseBusiness
    {
        public NoticeBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##添加##
        /// <summary>
        /// 添加投资人公告
        /// </summary>
        /// <param name="notice"></param>
        public void InsertNoticeInfo(tb_notice notice)
        {
            try
            {
                //tb_notice notice = new tb_notice();
                string noticeId = Guid.NewGuid().ToString();
                notice.Id = noticeId;
                notice.NoticeNO = CreateNotieceNo();
                notice.NDate = DateTime.Now;
                ef.tb_notice.Add(notice);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion

        #region ##查询##
        /// <summary>
        /// 查询公告列表
        /// </summary>
        /// <param name="starTime"></param>
        /// <param name="endTime"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public IQueryable<tb_notice> GetNoticeListByQuery(DateTime starTime, DateTime endTime, string keyWord)
        {
            var query = GetNoticeAllData();
            if (starTime.Year!=1)
                query= query.Where(n => n.NDate >= starTime && n.NDate <= endTime);
            if (!String.IsNullOrEmpty(keyWord))
            {
                query = query.Where(n => n.NoticeNO.Contains(keyWord) || n.Content.Contains(keyWord) || n.NTheme.Contains(keyWord));
            }
            return query;
        }
        /// <summary>
        /// 获取公告表全部有效信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_notice> GetNoticeAllData()
        {
            return ef.tb_notice.Where(n=>n.IsUsed==true);
        }
        /// <summary>
        /// 根据ID获取公告
        /// </summary>
        /// <param name="noID">公告ID</param>
        /// <returns></returns>
        public IQueryable<tb_notice> GetNoticeByID(string noID) {
            return ef.tb_notice.Where(q => q.Id == noID);
        }

        /// <summary>
        /// 根据ID获取公告实体类
        /// </summary>
        /// <param name="noID"></param>
        /// <returns></returns>
        public tb_notice GetNoticeInfoByID(string noID)
        {
            return GetNoticeByID(noID).FirstOrDefault();
        }
        #endregion

        #region ##修改##
        #endregion

        #region ##删除##
        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="noID"></param>
        public bool DeleteNoticeInfo(string NoID,string remark,string account)
        {
            bool result = false;
            try
            {
                tb_notice _Notice = ef.tb_notice.Where(n => n.Id == NoID).FirstOrDefault();
                if (_Notice != null)
                {
                    _Notice.Id = NoID;
                    _Notice.IsUsed = false;
                    _Notice.DelRemark = remark;
                    _Notice.DeleteTime = DateTime.Now;
                    _Notice.DelAccount = account;
                    result = true;
                }
              
            }
            catch (Exception)
            {
                
            }
            return result;
        }
        #endregion

        #region ##私有方法##
        /// <summary>
        /// 生成公告序号
        /// </summary>
        /// <returns></returns>
        public string CreateNotieceNo()
        {
            return "";
        }
        #endregion
    }
}