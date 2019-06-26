using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testAmazeUI.Models;
using testAmazeUI.Models.parModel;
using RDO.Commen;
using System.Data.Entity.Validation;
using testAmazeUI.Models.selTableView;
using testAmazeUI.Models.resultModel;

namespace testAmazeUI.Controllers
{
    public class ProjectManegeController : BaseController
    {
        #region ##页面初始化##
        // GET: ProjectManege
        public ActionResult CastProjectView()
        {
            return View();
        }
        // GET: ProjectManege
        public ActionResult NotAdvanceView()
        {
            return View();
        }
        // GET: ProjectManege
        public ActionResult ObservationProjectView()
        {
            return View();
        }
        public ActionResult CreateProjectView()
        {
            return View();
        }
        public ActionResult EditProjectView() {
            string proId = Request["ProId"];
            try
            {
                if (!String.IsNullOrEmpty(proId))
                {
                    ViewBag.ProjectInfo = SelProjectInfo(proId);
                    ViewBag.ProjectPRE = GetProjectPREs(proId);
                    ViewBag.ProjectImgs = GetProjectImgs(proId);
                }               
            }
            catch (Exception)
            {
               
            }
           
            return View();
        }
        public ActionResult ProjectDetailedView() {
            string proID=Request["ProId"];
            if (!String.IsNullOrEmpty(proID))
            {
                ViewBag.ProjcetInfo = SelProjectInfo(proID);
                ViewBag.ProjectDocmentList = GetProjectTxtListByProId(proID);
                //ViewBag.ProjectFlieList = GetProjectDocmentListByProId(proID) ;
                ViewBag.ProjectImgs = GetProjectImgs(proID);
                ViewBag.ProjectPREs = GetProjectPREs(proID);
            }
         
            return View();
        }

        #endregion


        #region ##页面接口##

        #region     ##Project##
        /// <summary>
        /// 添加新项目
        /// </summary>
        /// <returns></returns>
        public JsonResult AddProjectInfo(ProjectInfo projectInfo)
        {
            ResultModel result = new ResultModel();
            try
            {
                tb_project newData = projectInfo.ConvertToT<tb_project>();
                if (String.IsNullOrEmpty(newData.Id))
                {
                    newData.Id = GetNewGuid();
                }
                newData.InsertTime = DateTime.Now;
                newData.UpdateTime = DateTime.Now;
                newData.InvestmentTime = DateTime.Now;
                
                if (projectInfo.ProPREs != null)
                _PREBusiness.AddListProPRE(projectInfo.ProPREs, newData.Id);
                if(projectInfo.ProImgs!=null)
                _ProjectBusiness.AddProImgList(projectInfo.ProImgs, newData.Id);


                ef.tb_project.Add(newData);
                ef.SaveChanges();
                result.ResultCode = 1;
                result.ResultData = newData;
            }
            catch (DbEntityValidationException dex)
            {
                dex.ToString();
            }
            catch (Exception ex)           
            {
                throw;
            }
            return Json(result);
        }
        //修改项目信息
        public JsonResult EditProjectInfo(ProjectInfo projectInfo) {
            ResultModel result = new ResultModel();
            try
            {
                tb_project newData = _ProjectBusiness.GetProjectInfoById(projectInfo.Id).FirstOrDefault();
                 newData = projectInfo.ConvertToT<tb_project>(newData);
                if (String.IsNullOrEmpty(newData.Id))
                {
                    newData.Id = GetNewGuid();
                }
             
                newData.UpdateTime = DateTime.Now;
                newData.UpdateUser = loginUser.Id;

                _PREBusiness.DelProPRE(newData.Id);
                if (projectInfo.ProPREs != null)
                {
                    _PREBusiness.AddListProPRE(projectInfo.ProPREs, newData.Id);
                }

                if (projectInfo.ProImgs != null)
                {
                    _ProjectBusiness.AddProImgList(projectInfo.ProImgs, newData.Id);
                }
                     
                ef.SaveChanges();
                result.ResultCode = 1;
                result.ResultData = newData;
            }
            catch (DbEntityValidationException dex)
            {
                dex.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(result);
        }
        /// <summary>
        /// 获取项目列表页
        /// </summary>
        /// <param name="selProjectList"></param>
        /// <returns></returns>
        public JsonResult SelProjectListTable(SelProjectList selProjectList) {
            ResultModel result = new ResultModel();
            selProjectList.EndTime = selProjectList.EndTime.AddDays(1);
            TableHelper _TableHelper = selProjectList.ConvertToT<TableHelper>();
            try
            {
                PageHelper pageHelper = new PageHelper(_TableHelper.PageIndex, _TableHelper.PageSize);
                var queryUserList = SelIQProjectList(selProjectList);
                 var userList = PagingFunction(queryUserList, ref pageHelper);
                _TableHelper.data = userList.ConvertToExpand();
                string tableHtml = RenderPartialViewToString(this, "_normalTable", _TableHelper);
                // string tableHtml = PartialView("_normalTable", _TableHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = tableHtml, pageInfo = pageHelper };
                //_TableHelper.data = queryUserList.ConvertToExpand();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(result);
        }
        /// <summary>
        /// 获取项目列表数据
        /// </summary>
        /// <param name="selProjectList">查询条件类</param>
        /// <returns></returns>
        public JsonResult SelProjectListData(SelProjectList selProjectList) {         
                ResultModel result = new ResultModel();
                selProjectList.EndTime = selProjectList.EndTime.AddDays(1);
               TableHelper _TableHelper = selProjectList.ConvertToT<TableHelper>();
               try
                {
                    PageHelper pageHelper = new PageHelper(_TableHelper.PageIndex, _TableHelper.PageSize);
                    var queryUserList = SelIQProjectList(selProjectList);
                    var userList = PagingFunction(queryUserList, ref pageHelper);                                                    
                    result.ResultCode = 1;
                result.ResultData = new {data = userList, pageInfo = pageHelper };
                    //_TableHelper.data = queryUserList.ConvertToExpand();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return Json(result);
            }
        /// <summary>
        /// 获取项目列表的查询接口
        /// </summary>
        /// <param name="selProjectList"></param>
        /// <returns></returns>
        private IQueryable<dynamic> SelIQProjectList(SelProjectList selProjectList) {
            var query= (from p in _ProjectBusiness.GetProjectListByQuery(selProjectList)
                                       join a in _AreaBusiness.GetAllAreaInfo() on p.AreaId equals a.Id
                                       join u in _userBusiness.GetAllUserInfo() on p.ProManager equals u.Id
                                       join c in _constantBusiness.GetAllData() on p.ProPhaseId equals c.Id
                                       orderby p.InsertTime descending
                                       select new
                                       {
                                           p.Id,
                                           p.CompName,
                                           p.ProName,
                                           p.InvestmentAmount,
                                           p.ValueOfAssessment,
                                           p.InsertTime,
                                           AreaName = a.Name,
                                           u.UserName,
                                           ProPhase = c.ItemName
                                       });
            return query;

        }
        /// <summary>
        /// 删除项目（软删除）
        /// </summary>
        /// <param name="proId">项目ID</param>
        /// <param name="remark">删除备注</param>
        /// <returns></returns>
        public JsonResult DelProject(string proId,string remark) {
            ResultModel result = new ResultModel();
            try
            {
                if (_ProjectBusiness.DleProject(proId, remark, loginUser.Id))
                {
                    ef.SaveChanges();
                    result.ResultCode = 1;
                }
                else
                {
                    result.ResultMsg = "删除失败！";
                }
            }
            catch (Exception)
            {
                result.ResultMsg = "删除失败！";
            }
            return Json(result);
        }

       
        /// <summary>
        /// 查询项目详细信息
        /// </summary>
        /// <param name="proID"></param>
        /// <returns></returns>
        private ReProjectInfo SelProjectInfo(string proID) {
            dynamic result = null;
            try
            {
                var query = from p in _ProjectBusiness.GetProjectInfoById(proID)
                            join u in _userBusiness.GetAllUserInfo() on p.ProManager equals u.Id
                            join a in _AreaBusiness.GetAllAreaInfo() on p.AreaId equals a.Id
                            join c in _constantBusiness.GetAllData() on p.ProPhaseId equals c.Id
                            select new ReProjectInfo
                            {
                                Id= p.Id,
                                InvestmentLogic= p.InvestmentLogic,
                                InvestmentTime= p.InvestmentTime,
                                Originator= p.Originator,
                                OriginatorEmail=p.OriginatorEmail,
                                OriginatorPhone=p.OriginatorPhone,
                                FinancingScale=p.FinancingScale,
                                ProName=p.ProName,
                                ProApp=  p.ProApp,
                                ProBrief= p.ProBrief,
                                ProWebUrl= p.ProWebUrl,
                                ProWeChat= p.ProWeChat,
                                AreaId=p.AreaId,
                                ProManager=p.ProManager,
                                ProPhaseId=p.ProPhaseId,
                                CompName= p.CompName,
                                Contact= p.Contact,
                                ContactEmail= p.ContactEmail,
                                ContactPhone= p.ContactPhone,
                                InvestmentAmount = p.InvestmentAmount,
                                UserName = u.UserName,
                                AreaName= a.Name,
                                ProPhaseName=c.ItemName,
                                
                            };
                result = query.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        /// <summary>
        /// 获取项目图片列表
        /// </summary>
        /// <param name="proId">项目ID</param>
        /// <returns></returns>
        private List<dynamic> GetProjectImgs(string proId) {
            List<dynamic> result = null;
            try
            {
                var query = from pi in ef.tb_project_image.Where(pi => pi.ProId == proId)
                            join f in _FileBusiness.GetAllData() on pi.FileId equals f.Id
                            select new {
                                pi.Id,
                                imgId=f.Id,
                                f.FileSName,
                                FilePath = f.FilePath.Replace("~", BaseUrl)
                          };
                result = query.ToList().ConvertToExpand();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        /// <summary>
        /// 获取项目PRE选项
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        private List<int?> GetProjectPREs(string proId)
        {
            List<int?> result = new List<int?>();
            try
            {
                result = ef.tb_Pro_PRE.Where(p => p.fk_ProjectID == proId).Select(p => p.fk_PREID).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        #endregion

        #region    ##ProjectDocment##
        public JsonResult SelProjectFileById(string proFileId) {
            ResultModel resultModel = new ResultModel();
            try
            {
                var data = (from p in _ProjectDocmentBusiness.GetProjectDocmentById(proFileId)
                            join f in _FileBusiness.GetProjectFile() on p.FileId equals f.Id
                            select new 
                            {                               
                                p.Id,
                                p.ProId,
                                p.ProPhaseId,
                                p.DocmentTypeId,
                                p.SortTime,
                                p.FileDesc,
                                FilePath = f.FilePath,
                                FileSize = f.FileSize,
                                FileSName = f.FileSName,
                                FileType = f.FileType,
                                f.InsertTime
                            }).FirstOrDefault();
                resultModel.ResultCode = 1;
                resultModel.ResultData = data;
            }
            catch (Exception)
            {

                throw;
            }
            return Json(resultModel);
        }
        public JsonResult SelProjectDocmentList(SelProjectDocmentList selProjectDocmentList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selProjectDocmentList.ConvertToT<TableHelper>();
            try
            {                 
          var query = (from pd in _ProjectDocmentBusiness.GetProjectDocmentListByProId(selProjectDocmentList.ProId)
                       join f in _FileBusiness.GetAllData() on pd.FileId equals f.Id
                       join u in _userBusiness.GetAllUserInfo() on pd.Account equals u.Id
                       join t in _constantBusiness.GetAllData() on pd.DocmentTypeId equals t.Id
                       join r  in _constantBusiness.GetAllData() on pd.ProPhaseId equals r.Id                      
                       select new
                       {
                           pd.Id,
                           pd.ProId,                          
                           pd.FileDesc,
                           pd.InsertTime,
                           u.UserName,
                           f.FileType,
                           f.FileSName,
                           DocmentTypeName=t==null?"":t.ItemName,
                           ProPhaseName=r==null?"":r.ItemName
                       });
                _TableHelper.data = query.ToList().ConvertToExpand();
                string tableHtml = RenderPartialViewToString(this, "_normalTable", _TableHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = tableHtml, pageInfo = new { } };
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result);
        }
        public JsonResult SelProjectDocmentDownList(SelProjectDocmentList selProjectDocmentList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selProjectDocmentList.ConvertToT<TableHelper>();
            try
            {
                var query = (from pd in _ProjectDocmentBusiness.GetProjectDocmentListByProId(selProjectDocmentList.ProId)
                             join f in _FileBusiness.GetAllData() on pd.FileId equals f.Id
                             join u in _userBusiness.GetAllUserInfo() on pd.Account equals u.Id
                             join t in _constantBusiness.GetAllData() on pd.DocmentTypeId equals t.Id
                             join r in _constantBusiness.GetAllData() on pd.ProPhaseId equals r.Id
                             orderby pd.InsertTime descending
                             select new
                             {
                              
                                 pd.Id,
                                 pd.ProId,
                                 pd.FileDesc,
                                 pd.InsertTime,
                                 u.UserName,
                                 f.FileType,
                                 FileSize=f.FileSize,
                                 f.FileSName,
                                 FilePath= f.FilePath.Replace("~", BaseUrl),
                                 DocmentTypeName = t == null ? "" : t.ItemName,
                                 ProPhaseName = r == null ? "" : r.ItemName
                             });
                _TableHelper.data = query.ToList().ConvertToExpand();
                string tableHtml = RenderPartialViewToString(this, "_downloadTable", _TableHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = tableHtml, pageInfo = new { } };
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result);
        }
        private List<dynamic> GetProjectDocmentListByProId(string ProId) {
            var query = (from pd in _ProjectDocmentBusiness.GetProjectDocmentListByProId(ProId)
                                     join f in _FileBusiness.GetAllData() on pd.FileId equals f.Id
                                     join u in _userBusiness.GetAllUserInfo() on pd.Account equals u.Id
                                     join t in _constantBusiness.GetAllData() on pd.DocmentTypeId equals t.Id
                                     join r in _constantBusiness.GetAllData() on pd.ProPhaseId equals r.Id
                                     select new
                                     {
                                         pd.Id,
                                         pd.ProId,
                                         pd.FileDesc,
                                         pd.InsertTime,
                                         u.UserName,
                                         f.FileType,
                                         f.FileSName,
                                         DocmentTypeName = t == null ? "" : t.ItemName,
                                         ProPhaseName = r == null ? "" : r.ItemName
                                     });
            return query.ToList().ConvertToExpand(); 

        }
        /// <summary>
        /// 保存项目文档
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="FileDesc"></param>
        /// <param name="ProId"></param>
        /// <param name="DocmentTypeId"></param>
        /// <param name="FileId"></param>
        /// <param name="ProPhaseId"></param>
        /// <returns></returns>
        public JsonResult SaveProjectDocment(string Id, string FileDesc, string ProId, string DocmentTypeId,string FileId, string ProPhaseId)
        {
            ResultModel resultModel = new ResultModel();                
            try
            {
                tb_project_docment newData = new tb_project_docment();
                if (String.IsNullOrEmpty(ProId))
                {
                    newData.ProId = GetNewGuid();
                }
                else
                {
                    newData.ProId = ProId;
                }
                if (String.IsNullOrEmpty(newData.Id))
                {
                    newData.Id= GetNewGuid();
                    newData.InsertTime = DateTime.Now;
                    newData.Account = loginUser.Id;                 
                    newData.FileDesc = FileDesc;
                    newData.ProPhaseId = ProPhaseId;
                    newData.DocmentTypeId = DocmentTypeId;
                    newData.FileId = FileId;
                    ef.tb_project_docment.Add(newData);
                }
                else
                {
                    newData = _ProjectDocmentBusiness.GetProjectDocmentById(Id).FirstOrDefault();                   
                    newData.FileDesc = FileDesc;
                    newData.ProPhaseId = ProPhaseId;
                    newData.DocmentTypeId = DocmentTypeId;
                    newData.FileId = FileId;
                }
                ef.SaveChanges();
                resultModel.ResultCode = 1;
                resultModel.ResultData = newData;
            }
            catch (DbEntityValidationException dex)
            {
                dex.ToString();
            }
            catch (Exception ex)
            {


            }

            return Json(resultModel);
        }
        /// <summary>
        /// 删除项目文档
        /// </summary>
        /// <param name="pdID"></param>
        /// <returns></returns>
        public JsonResult DelProjectDocment(string pdID)
        {
            ResultModel result = new ResultModel();
            try
            {
                if (_ProjectDocmentBusiness.DelProjectDocmentById(pdID))
                {
                    ef.SaveChanges();
                    result.ResultCode = 1;
                }
            }
            catch (Exception)
            {                
            }
            return Json(result);
        }
        #endregion

        #region ProjectTxt
        /// <summary>
        /// 保存访谈纪要
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ProId"></param>
        /// <param name="Area"></param>
        /// <param name="Subject"></param>
        /// <param name="InnerMan"></param>
        /// <param name="OuterMan"></param>
        /// <param name="Content"></param>
        /// <param name="SortTime"></param>
        /// <returns></returns>
        public JsonResult SaveProjectTxtModel(string Id,string ProId,string Area,
                                  string Subject,string InnerMan,string OuterMan,string Content,string SortTime)
        {
            ResultModel result = new ResultModel();
            try
            {
                tb_interview_record _newdata = new tb_interview_record();
                if (String.IsNullOrEmpty(ProId))
                {
                    _newdata.ProId = Guid.NewGuid().ToString("N");

                }
                else
                {
                    _newdata.ProId = ProId;
                }
                _newdata.Id = Guid.NewGuid().ToString("N");
                _newdata.Area = Area;
                _newdata.Subject = Subject;
                _newdata.InnerMan = InnerMan;
                _newdata.OuterMan = OuterMan;
                _newdata.Content = Content;
                _newdata.SortTime = Convert.ToDateTime(SortTime);
                _newdata.UpdateTime = DateTime.Now;
                _newdata.CreateTime = DateTime.Now;
                ef.tb_interview_record.Add(_newdata);
                ef.SaveChanges();
                result.ResultCode = 1;
                result.ResultData = _newdata;
            }
            catch (Exception)
            {
               
            }
            return Json(result);
        }
        /// <summary>
        /// 获取访谈纪要列表
        /// </summary>
        /// <param name="selProjectDocmentList"></param>
        /// <returns></returns>
        public JsonResult SelProjectTxtList(SelProjectDocmentList selProjectDocmentList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selProjectDocmentList.ConvertToT<TableHelper>();
            try
            {
                var query =  _InterviewRecordBusiness.GetDataListByProId(selProjectDocmentList.ProId);
                _TableHelper.data = query.ToList().ConvertToExpand();
                string tableHtml = RenderPartialViewToString(this, "_normalTable", _TableHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = tableHtml, pageInfo = new { } };
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result);
        }
        /// <summary>
        /// 删除项目访谈纪要
        /// </summary>
        /// <param name="pdID"></param>
        /// <returns></returns>
        public JsonResult DelProjectTxt(string ptID)
        {
            ResultModel result = new ResultModel();
            try
            {
                if (_InterviewRecordBusiness.DelInterviewRecord(ptID))
                {
                    ef.SaveChanges();
                    result.ResultCode = 1;
                }
            }
            catch (Exception)
            {
            }
            return Json(result);
        }
        private List<dynamic> GetProjectTxtListByProId(string proId) {
            var query = _InterviewRecordBusiness.GetDataListByProId(proId);
            return query.ToList().ConvertToExpand();
        }
        #endregion

        #endregion






    }
}