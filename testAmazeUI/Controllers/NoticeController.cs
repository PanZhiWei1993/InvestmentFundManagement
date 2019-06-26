using RDO.Commen;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testAmazeUI.Models;
using testAmazeUI.Models.resultModel;
using testAmazeUI.Models.selTableView;

namespace testAmazeUI.Controllers
{
    public class NoticeController : BaseController
    {
        #region ##页面初始化##
        // GET: Notice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AppendNoticeView()
        {
            return View();
        }

        public ActionResult NoticeDetailedView() {
            string NoId = Request["NoId"];
            ViewBag.NoticeInfo = SelNoticeInfoByNoID(NoId);          
            return View();
        }

        public ActionResult EditNoticeView() {
            string NoId = Request["NoId"];
            ViewBag.NoticeInfo = SelNoticeInfoByNoID(NoId);
            return View();
        }
        #endregion



        #region ##页面接口##

        #region ##公告相关Notice##
        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="selNoticeList"></param>
        /// <returns></returns>
        public JsonResult SelNoticeListTable(SelNoticeList selNoticeList) {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selNoticeList.ConvertToT<TableHelper>();
            try
            {
                PageHelper pageHelper = new PageHelper(_TableHelper.PageIndex, _TableHelper.PageSize);
                var query = from n in _NoticeBusiness.GetNoticeListByQuery(selNoticeList.BeginTime, selNoticeList.EndTime, selNoticeList.KeyWord)
                            join u in _userBusiness.GetAllUserInfo() on n.ContactAccount equals u.Id
                            join a in _AreaBusiness.GetAllAreaInfo() on n.NAddress equals a.Id
                            orderby n.InsertTime descending
                            select new
                            {
                                n.Id,
                                n.InsertTime,
                                n.NDate,
                                n.NoticeNO,
                                n.NTheme,                                
                                u.UserName,
                                AreaName=a.Name
                               
                            };
                var userList = PagingFunction(query, ref pageHelper).ConvertToExpand();

                foreach (var item in userList)
                {
                    string id = item.Id;
                    item .NFlieNum = _NoticeDocmentBusiness.GetNoticeDocmentListByNoticeId(id).Count();
                }
                _TableHelper.data = userList;
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

        public JsonResult SelNoticeListData(SelNoticeList selNoticeList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selNoticeList.ConvertToT<TableHelper>();
            try
            {
                PageHelper pageHelper = new PageHelper(_TableHelper.PageIndex, _TableHelper.PageSize);
                var query = SelNoticeListIQ(selNoticeList);
                var userList = PagingFunction(query, ref pageHelper);             
                // string tableHtml = PartialView("_normalTable", _TableHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = userList, pageInfo = pageHelper };
                //_TableHelper.data = queryUserList.ConvertToExpand();
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result);
        }


        private IQueryable<dynamic> SelNoticeListIQ(SelNoticeList selNoticeList) {
            var query = from n in _NoticeBusiness.GetNoticeListByQuery(selNoticeList.BeginTime, selNoticeList.EndTime, selNoticeList.KeyWord)
                        join u in _userBusiness.GetAllUserInfo() on n.ContactAccount equals u.Id
                        join a in _AreaBusiness.GetAllAreaInfo() on n.NAddress equals a.Id
                        orderby n.InsertTime descending
                        select new
                        {
                            n.Id,
                            n.InsertTime,
                            n.NDate,
                            n.NoticeNO,
                            n.NTheme,
                            u.UserName,
                            AreaName = a.Name,
                            NFlieNum = 0
                        };
            return query;
        }
        /// <summary>
        /// 添加公告信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="NDate"></param>
        /// <param name="NTheme"></param>
        /// <param name="Content"></param>
        /// <param name="NAddress"></param>
        /// <returns></returns>
        public JsonResult AddNoticeData(string Id,string NDate,string NTheme,string Content,int NAddress) {
            ResultModel result = new ResultModel();
            try
            {
                tb_notice newData = new tb_notice();
                newData.Id = String.IsNullOrEmpty(Id)?Guid.NewGuid().ToString("N"):Id;
                newData.NDate = Convert.ToDateTime(NDate);
                newData.NTheme = NTheme;
                newData.Content = Content;
                newData.NAddress = NAddress;
                newData.NoticeNO = "";
                newData.InsertTime = DateTime.Now;
                newData.UdateTime = DateTime.Now;
                newData.ContactAccount = loginUser.Id;
                newData.IsUsed = true;
                ef.tb_notice.Add(newData);
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
        public JsonResult EditNoticeData(string Id, string NDate, string NTheme, string Content, int NAddress)
        {
            ResultModel result = new ResultModel();
            try
            {
                tb_notice newData = _NoticeBusiness.GetNoticeByID(Id).FirstOrDefault();              
                newData.NDate = Convert.ToDateTime(NDate);
                newData.NTheme = NTheme;
                newData.Content = Content;
                newData.NAddress = NAddress;        
                newData.UdateTime = DateTime.Now;                            
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

        public JsonResult DelNotice(string NoId, string remark) {
            ResultModel result = new ResultModel();
            try
            {
                if (_NoticeBusiness.DeleteNoticeInfo(NoId,remark,loginUser.Id)) {
                    ef.SaveChanges();
                    result.ResultCode = 1;
                }
            }
            catch (Exception ex)
            {
                result.ResultMsg = "删除失败！";
            }
            return Json(result);
        }

        #endregion

        #region ##公告附件相关NoticeDocment##
        /// <summary>
        /// 保存公告附件信息
        /// </summary>
        /// <param name="Id">公告附件ID（区分新增还是修改）</param>
        /// <param name="FileDesc">文件描述</param>
        /// <param name="NoticeId">公告ID</param>
        /// <param name="FileId">文件ID</param>
        /// <returns></returns>
        public JsonResult SaveNoticeDocment(string Id, string FileDesc, string NoticeId, string FileId)
        {
            tb_notice_docment noticeFileModel = new tb_notice_docment();
            noticeFileModel.Id = Id;
            noticeFileModel.FileDesc = FileDesc;
            noticeFileModel.NoticeId = NoticeId;
            noticeFileModel.FileId = FileId;
           
            ResultModel resultModel = new ResultModel();
            try
            {
                if (String.IsNullOrEmpty(noticeFileModel.NoticeId)) {
                    noticeFileModel.NoticeId = GetNewGuid();
                }
                if (String.IsNullOrEmpty(noticeFileModel.Id))
                {
                   noticeFileModel.Account = loginUser.Id;
                   noticeFileModel = _NoticeDocmentBusiness.AddData(noticeFileModel);
                }
                else
                {
                    noticeFileModel = _NoticeDocmentBusiness.UpdateData(noticeFileModel);
                }
                ef.SaveChanges();
                resultModel.ResultCode = 1;
                resultModel.ResultData = noticeFileModel;
            }
            catch (DbEntityValidationException dex)
            {
                dex.ToString();
            }
            catch (Exception ex)
            {
                throw;

            }

            return Json(resultModel);
        }
        /// <summary>
        /// 根据公告附件id获取公告附件信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult SleNoticeDocmentById(string Id) {
            ResultModel resultModel = new ResultModel();
            try
            {
                var data = (from n in _NoticeDocmentBusiness.GetDataById(Id)
                           join f in _FileBusiness.GetNoticeFile() on n.FileId equals f.Id
                           select new FileDocmentInfo
                           {
                               Id = n.Id,
                               FileDesc = n.FileDesc,
                               NoticeId = n.NoticeId,
                               FileId = n.FileId,
                               Account = n.Account,
                               InsertDate = n.InsertDate,
                               FilePath = f.FilePath,
                               FileSize = f.FileSize,
                               FileSName = f.FileSName,
                               FileType = f.FileType
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
        /// <summary>
        /// 根据公告ID获取公告附件列表
        /// </summary>
        /// <param name="selNoticeDocmentList">包含公告附件id</param>
        /// <returns></returns>
        public JsonResult SelNoticeDocmentList(SelNoticeDocmentList selNoticeDocmentList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selNoticeDocmentList.ConvertToT<TableHelper>();
            try
            {
             
                var query
                    =(from nd in _NoticeDocmentBusiness.GetNoticeDocmentListByNoticeId(selNoticeDocmentList.NoticeId)
                               join f in _FileBusiness.GetAllData() on nd.FileId equals f.Id into _f from f in _f.DefaultIfEmpty()
                               join u in _userBusiness.GetAllUserInfo() on nd.Account equals u.Id into _u
                      from u in _u.DefaultIfEmpty()
                      select new {
                                   nd.NoticeId,
                                   nd.Id,
                                   nd.FileDesc,
                                   nd.InsertDate,
                                   UserName=u==null?"": u.UserName,
                                   FileType= f==null?"":f.FileType,
                                   FileSName = f == null ? "" : f.FileSName   
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
        /// <summary>
        /// 获取可下载列表
        /// </summary>
        /// <param name="selNoticeDocmentList"></param>
        /// <returns></returns>
        public JsonResult SelNoticeDocmentDownList(SelNoticeDocmentList selNoticeDocmentList)
        {
            ResultModel result = new ResultModel();
            TableHelper _TableHelper = selNoticeDocmentList.ConvertToT<TableHelper>();
            try
            {

                var query
                  = (from nd in _NoticeDocmentBusiness.GetNoticeDocmentListByNoticeId(selNoticeDocmentList.NoticeId)
                     join f in _FileBusiness.GetAllData() on nd.FileId equals f.Id into _f
                     from f in _f.DefaultIfEmpty()
                     join u in _userBusiness.GetAllUserInfo() on nd.Account equals u.Id into _u
                     from u in _u.DefaultIfEmpty()
                     select new
                     {
                         nd.NoticeId,
                         nd.Id,
                         nd.FileDesc,
                         nd.InsertDate,                       
                         UserName = u == null ? "" : u.UserName,
                         FileType = f == null ? "" : f.FileType,
                         FileSName = f == null ? "" : f.FileSName,
                         FileSize = f == null ? "" : f.FileSize.ToString(),
                         FilePath = f == null ? "" : f.FilePath.Replace("~",BaseUrl)
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
        /// <summary>
        /// 删除公告附件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DelNoticeDocment(string NDId)
        {
            ResultModel result = new ResultModel();
            try
            {
                var delData = _NoticeDocmentBusiness.GetDataById(NDId).FirstOrDefault();
                if (delData != null)
                {
                    ef.tb_notice_docment.Remove(delData);
                    ef.SaveChanges();
                    result.ResultCode = 1;
                }
                else
                {
                    result.ResultMsg = "数据异常，删除失败！";
                }
            }
            catch (Exception ex)
            {
                result.ResultMsg = "数据异常，删除失败！";
            }
            return Json(result);
        }
        #endregion
        #endregion


        #region ##私有方法##
        private ReNoticeInfo SelNoticeInfoByNoID(string NoId) {
            ReNoticeInfo result = new ReNoticeInfo();
            try
            {
                var data = (from n in _NoticeBusiness.GetNoticeByID(NoId)
                          join a in _AreaBusiness.GetAllAreaInfo() on n.NAddress equals a.Id into _a from a in _a.DefaultIfEmpty()
                            join ca in _userBusiness.GetAllUserInfo().DefaultIfEmpty() on n.ContactAccount equals ca.Id 
                            into _ca from ca in _ca.DefaultIfEmpty()
                            join cu in _userBusiness.GetAllUserInfo().DefaultIfEmpty() on n.InsertUser equals cu.Id
                            into _cu from cu in _cu.DefaultIfEmpty()
                            join pu in _userBusiness.GetAllUserInfo().DefaultIfEmpty() on n.UpdateUser equals pu.Id
                             into _pu
                            from pu in _pu.DefaultIfEmpty()
                            select new ReNoticeInfo
                          {
                              Id= n.Id,
                              InsertTime= n.InsertTime,
                              NDate=  n.NDate,
                              NTheme=n.NTheme,
                              NoticeNO=  n.NoticeNO,
                              NAddress=n.NAddress,
                              UdateTime= n.UdateTime,
                              Content= n.Content,
                              Area = a==null?"":a.Name,
                              ContactAccount=ca==null?"":ca.UserName,
                              InsertUser= cu == null ? "" : cu.UserName,
                              UpdateUser= pu == null ? "" : pu.UserName
                          }).FirstOrDefault();
                if (data != null)
                    result = data;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        #endregion

    }
}