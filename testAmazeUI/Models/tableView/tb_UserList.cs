using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models.tableView
{
    public class tb_UserList
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }       
        public string Utype { get; set; }       
        public Nullable<System.DateTime> InsertTime { get; set; }    
    }
}