using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models
{
    public class TableHelper:TableOption
    {
        public TableHelper() {          
        }
        public TableHelper(List<dynamic> _data,
            bool _isHasAction = false, string _actionID = "",
            string _doEitFunction="", string _doDelFunction="")
        {
            data = data;           
           
            actionID = _actionID;
            isHasAction = _isHasAction;
            doEitFunction = _doEitFunction;
            doDelFunction = _doDelFunction;
        }
        /// <summary>
        /// 数据
        /// </summary>
        public List<dynamic> data { get; set; }
        public int IndexStar { get { return (PageIndex - 1) * PageSize > 0 ? (PageIndex - 1) * PageSize : 0; } set { } }
       
        

    }
  

}