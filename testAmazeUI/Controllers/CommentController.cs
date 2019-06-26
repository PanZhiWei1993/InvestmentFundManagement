using RDO.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testAmazeUI.Models;
using testAmazeUI.Models.selTableView;

namespace testAmazeUI.Controllers
{
    public class CommentController : BaseController
    {
        /// <summary>
        /// 获取项目评论列表
        /// </summary>
        /// <param name="queryCondition"></param>
        /// <returns></returns>
        public JsonResult GetProjectCommentListData(SelProjectDocmentList queryCondition)
        {
            ResultModel result = new ResultModel();
           
            TableHelper _TableHelper = queryCondition.ConvertToT<TableHelper>();
            try
            {
                PageHelper pageHelper = new PageHelper(_TableHelper.PageIndex, _TableHelper.PageSize);
                var queryUserList = (from c in _CommentBusiness.SleCommenyByProjectId(queryCondition.ProId)
                                     join u in ef.tb_user on c.Account equals u.Id
                                     select new {
                                         c.Account,
                                         c.Content,
                                         c.Id,
                                         c.InsertTime,
                                         c.ProId,
                                         c.Subject,
                                         c.ProPhase,
                                         AccountName = u.UserName,
                                         AccountIcon= u.AccountIcon.Replace("~", BaseUrl)
                                     }
                                    ).OrderByDescending(c=>c.InsertTime);
                var commentList = PagingFunction(queryUserList, ref pageHelper);
                result.ResultCode = 1;
                result.ResultData = new { data = commentList, pageInfo = pageHelper };               
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(result);
        }
        /// <summary>
        /// 获取最新评论列表
        /// </summary>
        /// <param name="count">获取个数</param>
        /// <returns></returns>
        public JsonResult GetNewCommentListData(int count) {
            ResultModel result = new ResultModel();
            try
            {
                var queryList = (from c in _CommentBusiness.SelAllData()
                                     join u in ef.tb_user on c.Account equals u.Id
                                     join p in ef.tb_project on c.ProId equals p.Id
                                     select new
                                     {
                                         c.Account,
                                         c.Content,
                                         c.Id,
                                         c.InsertTime,
                                         c.ProId,
                                         c.Subject,
                                         c.ProPhase,
                                         p.ProName,
                                         AccountName = u.UserName,
                                         AccountIcon = u.AccountIcon.Replace("~", BaseUrl)
                                     }
                                 ).OrderByDescending(c => c.InsertTime);
                var data = queryList.Take(count).ToList();
                result.ResultCode = 1;
                result.ResultData = data;
            }
            catch (Exception ex)
            {

                
            }
            return Json(result);
        }
        /// <summary>
        /// 获取评论信息
        /// </summary>
        /// <param name="Id">评论ID</param>
        /// <returns></returns>
        public JsonResult GetCommentData(string Id) {
            ResultModel result = new ResultModel();
            try
            {
                var data = _CommentBusiness.GetCommentInfoByComId(Id).FirstOrDefault();
                result.ResultCode = 1;
                result.ResultData = data;
            }
            catch (Exception ex)
            {

               
            }
            return Json(result);
        }
        /// <summary>
        /// 保存评论信息
        /// </summary>
        /// <param name="CommentModel"></param>
        /// <returns></returns>
        public JsonResult SaveComment(tb_comment CommentModel) {
            ResultModel result = new ResultModel();
            try
            {
                if (String.IsNullOrEmpty(CommentModel.Id))
                {
                    CommentModel.Id = GetNewGuid();
                    CommentModel.InsertTime = DateTime.Now;
                    CommentModel.Account = loginUser.Id;
                    ef.tb_comment.Add(CommentModel);
                }
                else
                {
                    var commentData = _CommentBusiness.GetCommentInfoByComId(CommentModel.Id).FirstOrDefault();
                    commentData.Subject = CommentModel.Subject;
                    commentData.Content = CommentModel.Content;
                }
                ef.SaveChanges();
                result.ResultCode = 1;
            }
            catch (Exception ex)
            {
             
            }
            return Json(result);
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public JsonResult DelComment(string comId)
        {
            ResultModel result = new ResultModel();
            try
            {
                if (_CommentBusiness.DelComment(comId))
                {
                    ef.SaveChanges();
                    result.ResultCode = 1;
                }                  
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(result);
        }
    }
}