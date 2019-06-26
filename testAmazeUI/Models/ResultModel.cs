using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAmazeUI.Models
{
    /// <summary>
    /// 返回结果类
    /// </summary>
    public class ResultModel
    {
        public ResultModel()
        {
            ResultCode = 0;
        }
        /// <summary>
        /// 状态码 1成功 0失败
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string ResultMsg { get; set; }
        /// <summary>
        /// 需要返回的其他数据
        /// </summary>
        public dynamic ResultData { get; set; }
    }
}