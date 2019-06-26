using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class InterviewRecordBusiness : BaseBusiness
    {
        public InterviewRecordBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        public IQueryable<tb_interview_record> GetDataListByProId(string ProId)
        {
            return GetAllData().Where(p => p.ProId == ProId);

        }
        public IQueryable<tb_interview_record> GetAllData() {
            return ef.tb_interview_record;
        }
        #endregion
        #region ##新增##
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        public bool DelInterviewRecord(string id) {
            bool result = false;
            var data = ef.tb_interview_record.Where(i => i.Id == id).FirstOrDefault();
            if (data != null)
            {
                ef.tb_interview_record.Remove(data);
                result = true;
            }
            return result;
        }
        #endregion
        #region ##私有方法##
        #endregion
    }
}