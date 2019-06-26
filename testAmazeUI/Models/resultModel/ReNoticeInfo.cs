using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.resultModel
{
    public class ReNoticeInfo
    {
        public string Id { get; set; }
        public string NTheme { get; set; }
        public string NoticeNO { get; set; }
        public string Content { get; set; }
        public Nullable<int>  NAddress { get; set; }
        public string Area { get; set; }
        public string ContactAccount { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<DateTime> InsertTime { get; set; }
        public Nullable<DateTime> NDate { get; set; }
        public Nullable<DateTime> UdateTime { get; set; }
    }
}