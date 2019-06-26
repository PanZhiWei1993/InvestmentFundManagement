using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testAmazeUI.Models;

namespace testAmazeUI.Controllers
{
    public class ConstantController : BaseController
    {
        /// <summary>
        /// 获取项目阶段选项
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetSelectBtn_PjRank(string deValue=null) {
            var data = _constantBusiness.GetPjRankList().Select(c => new BtnSelected { Value = c.Id, Name = c.ItemName }).ToList();
            return PartialView("_normalSelectBtn", new SelBtnModel(data, deValue));
        }
        /// <summary>
        /// 获取行业标签选项
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetSelectBtn_TradeType(string deValue = null)
        {
            var data = _constantBusiness.GetTradeTypeList().Select(c => new BtnSelected { Value = c.Id, Name = c.ItemName }).ToList();
            return PartialView("_normalSelectBtn", new SelBtnModel(data, deValue));
        }
        /// <summary>
        /// 获取项目文件类型选项
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetSelectBtn_PjTextType(string deValue = null)
        {
            var data = _constantBusiness.GetPjTextTypeList().Select(c => new BtnSelected { Value = c.Id, Name = c.ItemName }).ToList();          
            return PartialView("_normalSelectBtn", new SelBtnModel(data, deValue));
        }
        /// <summary>
        /// 获取项目类型选项
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetSelectBtn_PjType(string deValue = null)
        {
            var data = _constantBusiness.GetPjTypeList().Select(c => new BtnSelected { Value = c.Id, Name = c.ItemName }).ToList();
            return PartialView("_normalSelectBtn", new SelBtnModel(data,deValue));
        }
        /// <summary>
        /// 获取地区选项
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetSelectBtn_AreaList(string deValue = null)
        {
            try
            {
                var data = _AreaBusiness.GetAreaListOrderByCode().Select(c => new BtnSelected { Value = c.Id.ToString(), Name = c.Name }).ToList();
                return PartialView("_normalSelectBtn", new SelBtnModel(data, deValue));
            }
            catch (Exception)
            {

                return PartialView("_normalSelectBtn", null);
            }
        }
        /// <summary>
        /// 获取管理员选项
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetSelectBtn_UserManege(string deValue = null)
        {
            try
            {
                var data = _userBusiness.GetManegerList().Select(c => new BtnSelected { Value = c.Id, Name = c.UserName }).ToList();
                return PartialView("_normalSelectBtn", new SelBtnModel(data, deValue));
            }
            catch (Exception)
            {

                return PartialView("_normalSelectBtn", null);
            }
        }
        /// <summary>
        /// 获取PRE选项
        /// </summary>
        /// <param name="deValue">默认值</param>
        /// <returns></returns>
        public PartialViewResult GetCheckBoxs_PRE(List<int?> ProjectPREs)
        {
            try
            {
                var data =_PREBusiness.GetAllPRE().Select(c => new BtnSelected { Value = c.Id.ToString(), Name = c.PdName }).ToList();
                return PartialView("_normalCheckBoxs", new CheckBoxModel(data, ProjectPREs));
            }
            catch (Exception)
            {

                return PartialView("_normalCheckBoxs", null);
            }
        }
    }
}