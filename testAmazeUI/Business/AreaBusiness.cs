using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class AreaBusiness:BaseBusiness
    {
        public AreaBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        public IQueryable<tb_area> GetAreaListOrderByCode() {
            return GetAllAreaInfo().OrderBy(a=>a.Code);
        }
        public IQueryable<tb_area> GetAllAreaInfo() {
            return ef.tb_area;
        }
        #endregion
        #region ##新增##
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        #endregion
        #region ##私有方法##
        #endregion
    }
}