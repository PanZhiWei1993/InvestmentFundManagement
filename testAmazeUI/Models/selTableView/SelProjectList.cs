using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.selTableView
{
    public class SelProjectList:TableOption
    {
        public string KeyWord { get; set; }
        public string ProPhaseId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public string ProManager { get; set; }
        public string ProType { get; set; }     
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}