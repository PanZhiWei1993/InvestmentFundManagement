using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.selTableView
{
    public class SelNoticeList : TableOption
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string KeyWord { get; set; }
    }
}