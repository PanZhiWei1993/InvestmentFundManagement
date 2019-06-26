using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models
{
    /// <summary>
    /// 分页帮助类
    /// </summary>
    public class PageHelper
    {
        //public PageHelper() {
        //    PageIndex = 1;
        //    PageSize = 10;
        //}
        public PageHelper(int _PageIndex=1, int _PageSize=10, int allcount = 0)
        {
            PageIndex = _PageIndex;
            PageSize = _PageSize;
            DataCount = allcount;
            //PageStar = pageStar;
            //PageCount = pageCount;
        }
        ///// <summary>
        ///// 分页外观（页码开始）
        ///// </summary>
        //public int PageStar { get; set; }
        ///// <summary>
        ///// 分页外观（页码显示数量）
        ///// </summary>
        //public int PageCount { get; set; }

        /// <summary>
        /// 现在所在页码数
        /// </summary>

        public int PageIndex
        {
            get
            {
                if (_PageIndex <= 0)
                    return 1;
                else
                    return _PageIndex;
            }
            set { _PageIndex = value; }
        }
        private int _PageIndex { get; set; }
        /// <summary>
        /// 一页显示数据条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int DataCount { get; set; }
        ///// <summary>
        ///// 总页数
        ///// </summary>
        //public int AllPage { get { return allPage; }set { }  }
        //private int allPage {
        //    get
        //    {
        //        if (AllCount == 0)
        //        {
        //            return 1;
        //        }
        //        else {
        //            return AllCount % PageSize > 0 ? AllCount / PageSize + 1 : AllCount / PageSize;                                          
        //        }
        //    }           
        //}
    }
}