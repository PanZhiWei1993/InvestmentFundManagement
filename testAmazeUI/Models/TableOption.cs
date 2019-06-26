using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models
{
    public class TableOption:PageHelper
    {
        public TableOption() {
            actionID = "";
            doEitFunction = "";
            doDelFunction = "";
            isHasAction = false;
            TBcolumns = new List<string>();
        }

        public TableOption(List<string> _TBcolumns,string _actionID="", string _doEitFunction = "", string _doDelFunction = "", bool _isHasAction = false) {
            actionID = _actionID;
            doEitFunction = _doEitFunction;
            doDelFunction = _doDelFunction;
            isHasAction = _isHasAction;
            TBcolumns = _TBcolumns;
        }
        public List<string> TBcolumns { get; set; }
        /// <summary>
        /// 操作时用到的字段
        /// </summary>
        public string actionID { get; set; }
        /// <summary>
        /// 操作修改方法
        /// </summary>
        public string doEitFunction { get; set; }
        /// <summary>
        /// 操作删除方法
        /// </summary>
        public string doDelFunction { get; set; }
        /// <summary>
        /// 是否添加操作
        /// </summary>
        public bool isHasAction { get; set; }
    }
}