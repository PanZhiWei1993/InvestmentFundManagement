using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class CommentBusiness : BaseBusiness
    {
        public CommentBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        public IQueryable<tb_comment> SleCommenyByProjectId(string proId) {
            return SelAllData().Where(c => c.ProId == proId);
        }
        public IQueryable<tb_comment> GetCommentInfoByComId(string comId) {
            return SelAllData().Where(c => c.Id == comId);
        }
        public IQueryable<tb_comment> SelAllData() {
            return ef.tb_comment;

        }
        #endregion
        #region ##新增##
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        public bool DelComment(string comId) {
            bool result = false;
            try
            {
                tb_comment data = ef.tb_comment.Where(c => c.Id == comId).FirstOrDefault();
                if (data != null)
                {
                    ef.tb_comment.Remove(data);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        #endregion
        #region ##私有方法##
        #endregion
    }
}