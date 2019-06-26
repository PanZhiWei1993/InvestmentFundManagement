using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Business
{
    /// <summary>
    /// 项目阶段业务
    /// </summary>
    public class ConstantBusiness : BaseBusiness
    {
        public ConstantBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##
        /// <summary>
        /// 获取项目阶段列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_constant> GetPjRankList() {
            return GetAllData().Where(c=>c.ItemType== "PjRank").OrderBy(c=>c.ItemCode);
        }
        /// <summary>
        /// 获取项目文件类型列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_constant> GetPjTextTypeList()
        {
            return GetAllData().Where(c => c.ItemType == "PjTextType").OrderBy(c => c.ItemCode);
        }
        /// <summary>
        /// 获取行业标签列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_constant> GetTradeTypeList()
        {
            return GetAllData().Where(c => c.ItemType == "TradeType").OrderBy(c => c.ItemCode);
        }
        /// <summary>
        /// 获取项目类型列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_constant> GetPjTypeList()
        {
            return GetCListByItemType("PjType").OrderBy(t => t.ItemCode);
        }


        /// <summary>
        /// 常量表类型获取类型数据列表
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        private IQueryable<tb_constant> GetCListByItemType(string itemType) {
            return GetAllData().Where(c => c.ItemType == itemType);
        }
        /// <summary>
        /// 获取全部有效数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<tb_constant> GetAllData() {
            return ef.tb_constant;
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