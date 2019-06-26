using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.resultModel
{
    public class ReProjectInfo
    {
        public string Id { get; set; }

        public string InvestmentLogic { get; set; }
        public Nullable<DateTime>  InvestmentTime { get; set; }
        public string Originator { get; set; }
        public string OriginatorEmail { get; set; }
        public string OriginatorPhone { get; set; }
        public string ProApp { get; set; }
        public string ProBrief { get; set; }
        public string ProWebUrl { get; set; }
        public string ProWeChat { get; set; }
        public string CompName { get; set; }
        public string Contact { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ProManager { get; set; }
        public string UserName { get; set; }
        public Nullable<int>  AreaId { get; set; }
        public string AreaName { get; set; }
        public string ProPhaseId { get; set; }
        public string ProPhaseName { get; set; }
        public string ProName { get; set; }
        public string FinancingScale { get; set; }
        public string InvestmentAmount { get; set; }
    }
}