using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class NoticeDocmentBusiness : BaseBusiness
    {
        public NoticeDocmentBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        public IQueryable<tb_notice_docment> GetNoticeDocmentListByNoticeId(string noticeId) {
            return GetAllData().Where(q => q.NoticeId == noticeId);
        }
        public IQueryable<tb_notice_docment> GetDataById(string Id) {
            return GetAllData().Where(q => q.Id == Id);
        }
        public IQueryable<tb_notice_docment> GetAllData() {
            return ef.tb_notice_docment;
        }
        #endregion
        #region ##新增##
        public tb_notice_docment AddData(tb_notice_docment data) {
            data.Id = Guid.NewGuid().ToString("N");
            data.InsertDate = DateTime.Now;
            //data.Account = "";
            ef.tb_notice_docment.Add(data);
            return data;
        }
        #endregion

        #region ##修改##
        public tb_notice_docment UpdateData(tb_notice_docment data) {
            var cData = GetDataById(data.Id).FirstOrDefault();
            cData.FileDesc = data.FileDesc;
            cData.FileId = data.FileId;
            return cData;
        }
        #endregion
        #region ##删除##
        #endregion
        #region ##私有方法##
        #endregion
    }
}