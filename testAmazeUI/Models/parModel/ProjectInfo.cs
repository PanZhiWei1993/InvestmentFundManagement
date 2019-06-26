using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.parModel
{
    /// <summary>
    /// 项目管理模型
    /// </summary>
    public class ProjectInfo
    {
        public string  Id {get;set;}
        public string CompName   {get;set;}
        public string ProName { get; set; }
        public string ProPhaseId {get;set;}
        public Nullable<int> AreaId { get;set;}
        public string ProManager { get;set;}
        public string ProWebUrl  {get;set;}
        public string ProApp  {get;set;}
        public string ProWeChat  {get;set;}
        public string Originator  {get;set;}
        public string OriginatorPhone  {get;set;}
        public string OriginatorEmail { get; set;}
        public string Contact  {get;set;}
        public string ContactEmail  {get;set;}
        public string ContactPhone  {get;set;}
        public string ProBrief  {get;set;}
        public string InvestmentLogic  {get;set;}
        public string InvestmentAmount  {get;set;}
        /// <summary>
        /// 融资规模
        /// </summary>
        public string FinancingScale { get; set; }
        public List<string> ProImgs { get; set; }
        public List<int> ProPREs { get; set; }
    }
}