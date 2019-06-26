using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testAmazeUI.Models.selTableView;

namespace testAmazeUI.Business
{
    public class ProjectBusiness:BaseBusiness
    {

        public ProjectBusiness(FUNDEntities fUNDEntities) : base(fUNDEntities)
        {

        }
        #region ##查询##

        public IQueryable<tb_project> GetProjectInfoById(string ProId) {
            return GetAllProjectInfo().Where(p => p.Id == ProId);

        }
        public IQueryable<tb_project> GetProjectListByQuery(SelProjectList  selProjectList) {
            var query = GetAllProjectInfo();
            if (!String.IsNullOrEmpty(selProjectList.KeyWord))
            {
                query = query.Where(p => p.CompName.Contains(selProjectList.KeyWord));
            }
            if (!String.IsNullOrEmpty(selProjectList.ProPhaseId))
            {
                query = query.Where(p => p.ProPhaseId==selProjectList.ProPhaseId);
            }
            if (!String.IsNullOrEmpty(selProjectList.ProManager))
            {
                query = query.Where(p => p.ProManager == selProjectList.ProManager);
            }
            //if (String.IsNullOrEmpty(selProjectList.ProType.Trim()))
            //{
            //    query = query.Where(p => p.ProType == selProjectList.ProType);
            //}
            try
            {                
                if ((int)selProjectList.AreaId!=0)
                {
                    query = query.Where(p => p.AreaId== selProjectList.AreaId);
                }
            }
            catch (Exception)
            {
              
            }
            if (selProjectList.BeginTime.Year != 1)
            {
                query = query.Where(p => p.InvestmentTime >= selProjectList.BeginTime && p.InvestmentTime < selProjectList.EndTime);
            }
         

            var count = query.Count();
          
            return query;
        }
        /// <summary>
        /// 根据地区查询项目
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public IQueryable<tb_project> GetProjectListByArea(int areaID, IQueryable<tb_project> query = null) {
            if (query == null)
                query = GetAllProjectInfo();
            return query.Where(q => q.AreaId == areaID);
        }
        public IQueryable<tb_project> GetAllProjectInfo() {
            return ef.tb_project.Where(p=>p.IsUsed==true);
        }


       
        #endregion
        #region ##新增##
        /// <summary>
        /// 添加项目图片列表
        /// </summary>
        /// <param name="fileIDs"></param>
        /// <param name="proID"></param>
        public void AddProImgList(List<string> fileIDs, string proID) {
            foreach (var item in fileIDs)
            {
                AddProImage(item, proID);
            }
        }
        /// <summary>
        /// 添加单个项目图片
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="proID"></param>
        public void AddProImage(string fileID,string proID) {
            tb_project_image newData = new tb_project_image();
            newData.Id = Guid.NewGuid().ToString("N");
            newData.ProId = proID;
            newData.FileId = fileID;
            ef.tb_project_image.Add(newData);
        }
        #endregion
        #region ##修改##
        #endregion
        #region ##删除##
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="Id">项目ID</param>
        /// <param name="remark">删除理由</param>
        /// <param name="account">删除人员</param>
        /// <returns></returns>
        public bool DleProject(string Id, string remark, string account) {
            bool result = false;
            tb_project _Project = ef.tb_project.Where(p=>p.Id== Id).FirstOrDefault();
            try
            {
                _Project.IsUsed = false;
                _Project.DelAccount = account;
                _Project.DeleteTime = DateTime.Now;
                _Project.DelRemark = remark;
                result = true;
            }
            catch (Exception)
            {

             
            }
            return result;
        }
        #endregion
        #region ##私有方法##
        #endregion
    }
}