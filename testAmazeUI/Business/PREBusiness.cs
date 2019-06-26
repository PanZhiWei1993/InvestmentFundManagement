using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    public class PREBusiness:BaseBusiness
    {
        public PREBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        /// <summary>
        /// 获取全部有PRE信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_PRE> GetAllPRE()
        {
            return ef.tb_PRE.Where(p => p.IsDelete == false);
        }
        #endregion
        #region ##新增##
        /// <summary>
        /// 添加项目PRE列表
        /// </summary>
        /// <param name="preId"></param>
        /// <param name="proID">项目ID</param>
        public void AddListProPRE(List<int> preId, string proID)
        {
            foreach (var item in preId)
            {
                AddNewProPRE(item, proID);
            }         
        }
        /// <summary>
        /// 添加单个项目PRE
        /// </summary>
        /// <param name="preId"></param>
        /// <param name="proID">项目ID</param>
        public void AddNewProPRE(int preId, string proID)
        {
            tb_Pro_PRE newData = new tb_Pro_PRE();
            newData.fk_PREID = preId;
            newData.fk_ProjectID = proID;
            ef.tb_Pro_PRE.Add(newData);
        }
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        /// <summary>
        /// 根据项目ID删除项目pre
        /// </summary>
        /// <param name="proID">项目ID</param>
        public void DelProPRE(string proID)
        {
            var delList = ef.tb_Pro_PRE.Where(t => t.fk_ProjectID == proID);
            ef.tb_Pro_PRE.RemoveRange(delList);
        }
        #endregion
        #region ##私有方法##
        #endregion
    }
}