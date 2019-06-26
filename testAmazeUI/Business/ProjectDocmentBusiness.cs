using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class ProjectDocmentBusiness : BaseBusiness
    {

        public ProjectDocmentBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##


        public IQueryable<tb_project_docment> GetProjectDocmentListByProId(string proId) {
            return GetAllData().Where(pd => pd.ProId == proId);
        }


        public IQueryable<tb_project_docment> GetProjectDocmentById(string pdId)
        {
            return GetAllData().Where(pd => pd.Id == pdId);
        }
        public IQueryable<tb_project_docment> GetAllData() {
            return ef.tb_project_docment;

        }
        #endregion
        #region ##新增##
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        public bool DelProjectDocmentById(string id)
        {
            bool result = false;
            var data = ef.tb_project_docment.Where(pd=>pd.Id==id).FirstOrDefault();
            if (data != null)
            {
                ef.tb_project_docment.Remove(data);
                result = true;
            }
            return result;
        }

        #endregion
        #region ##私有方法##
        #endregion
    }
}