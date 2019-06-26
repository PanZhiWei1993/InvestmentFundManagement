
using System;
using System.Net;
using System.Text;
using System.Linq;

namespace RDO.Commen
{
    /// <summary>
    /// 对sql脚本处理
    /// </summary>
    public static class ExpandString
    {
        /// <summary>
        /// 得到一个八位随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetNonceString(int length = 8)
        {
            var sb = new StringBuilder();
            var rnd = new Random();
            for (var i = 0; i < length; i++)
                sb.Append((char)rnd.Next(97, 123));
            return sb.ToString();
        }
        /// <summary>
        /// 转义sql参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string SqlParamEscape(this string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                param = param.Replace("'", "''");
                //param = param.Replace("_", "[_]");
                //param = param.Replace("%", "[%]");
            }
            return param;
        }
        /// <summary>
        /// 转换微博的时间格式
        /// </summary>
        /// <param name="weibo_date"></param>
        /// <returns></returns>
        public static DateTime WeiboDate(this string weibo_date)
        {
            DateTime result = default(DateTime);
            if (weibo_date.Length>20)
            {
                string date = weibo_date.Insert(20, "UTC");
                result = DateTime.ParseExact(date, "ddd MMM d HH:mm:ss UTCK yyyy", new System.Globalization.CultureInfo("en-us"));
            }
            return result;
        }

        /// <summary>
        /// 将时间转换成比较人性化的字符串显示
        /// </summary>
        /// <param name="createTime_"></param>
        /// <returns></returns>
        public static string EnGoodTime(this DateTime createTime_)
        {
            string result;
            if ((-(createTime_ - DateTime.Now)).TotalMinutes.ToString("00") == "00")
            {
                result ="刚刚";
            }
            else if (-(createTime_ - DateTime.Now).TotalMinutes <= 30)
                result = string.Format("{0}分钟前", (-(createTime_ - DateTime.Now)).TotalMinutes.ToString("00"));
            else if (createTime_.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
            {
                result = "今天 ";
                result += createTime_.ToString("HH:mm");
            }
            else
                result = createTime_.ToString("yyyy年MM月dd日 HH:mm");
            return result;
        }

        /// <summary>
        /// 省略字符串
        /// </summary>
        /// <param name="strContent">需要做省略的字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string Ellipsis(this string strContent, int length)
        {
            do
            {
                if (strContent.Length <= length) break;
                else strContent = strContent.Substring(0, length) + "...";
            } while (false);
            return strContent;
        }
        /// <summary>
        /// 过滤Html标签
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static string HtmlFilter(this string htmlStr)
        {
            htmlStr = string.IsNullOrEmpty(htmlStr) ? "" : htmlStr;
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, @"<[^>]+>", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, @"&[^;]+;", "");
            return htmlStr;
        }

        /// <summary>
        /// 过滤部分HTML标签
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static string HtmlFilterContent(this string htmlStr)
        {
            htmlStr = string.IsNullOrEmpty(htmlStr) ? "" : htmlStr;
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, @"<[^ip]+>", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, @"&[^;]+;", "");
            return htmlStr;
        }

        /// <summary>
        /// 统一文字大小
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static string Style20(this string htmlStr)
        {
            return Style(htmlStr, 18, 32);
        }
        /// <summary>
        /// 统一设置文字格式
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="lineheight">行高</param>
        /// <returns></returns>
        public static string Style(this string htmlStr, int fontSize, int lineheight)
        {
            string reHtmlStr = "";
            htmlStr = string.IsNullOrEmpty(htmlStr) ? "" : htmlStr;
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, @"<script>[^<]*</script>", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, @"<style>[^<]*</style>", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "font-size:[^;\"}]+[;]{0,1}", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "color:[^;\"}]+[;]{0,1}", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "font-family:[^;\"}]+[;]{0,1}", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "line-height:[^;\"}]+[;]{0,1}", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "margin[^:] *:[^;\"}]+[;]{0,1}", "");
            //htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "\\s+", "");
            htmlStr = System.Text.RegularExpressions.Regex.Replace(htmlStr, "&[^;]+;", "");
            //font-family:黑体;
            reHtmlStr += string.Format("<div style=\"font-size:{0}px;line-height:{1}px;\">", fontSize, lineheight, fontSize * 2);//text-indent:{2}px
            reHtmlStr += htmlStr;
            reHtmlStr += "</div>";
            return reHtmlStr;
        }
        /// <summary>
        /// 用逗号分隔的字符串转换成sql中的In数组
        /// </summary>
        /// <param name="str">用逗号分割的字符串</param>
        /// <returns></returns>
        public static string SqlIn(this string str)
        {
            string ids = "('',";
            string[] ids_ = str.SqlParamEscape().Split(',');
            for (int i = 0; i < ids_.Length; i++)
            {
                string imgId = ids_[i];
                if (string.IsNullOrEmpty(imgId.Trim()))
                {
                    ids += string.Format("'{0}'", imgId);
                    ids += i == ids_.Length - 1 ? "" : ",";
                }
            }
            ids += ")";
            return ids;
        }
        /// <summary>
        /// 强制转换为时间格式
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static System.DateTime ConvertDateTimeE(this string date)
        {
            try
            {
                return System.Convert.ToDateTime(date);
            }
            catch //(System.Exception)
            {
                return default(System.DateTime);
            }
        }
        /// <summary>
        /// 强制转换为int32类型
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int ConvertInt32E(this string str)
        {
            try
            {
                return System.Convert.ToInt32(str);
            }
            catch //(System.Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 前位填充字符
        /// </summary>
        /// <param name="oldStr">旧字符</param>
        /// <param name="fillStr">填充字符</param>
        /// <param name="num">填充到的位数</param>
        /// <returns></returns>
        public static string AheadFillCharacter(this string oldStr, string fillStr, int num) {
            oldStr = fillStr + oldStr;
            while (oldStr.Length < num)
            {
                oldStr = AheadFillCharacter(oldStr, fillStr, num);
            }
            return oldStr;
        }
        #region #格式化URL#
        /// <summary>
        /// 格式化Url
        /// </summary>
        /// <param name="urlPath"></param>
        /// <param name="parentPath"></param>
        /// <returns></returns>
        public static string FomatUrl(this string urlPath, string parentPath)
        {
            string fomatUrl = urlPath;
            do
            {
                if (string.IsNullOrEmpty(urlPath.Trim()))
                    break;
                if (urlPath.Contains("http://") || urlPath.Contains("https://"))
                    break;
                if (string.IsNullOrEmpty(parentPath) || !(parentPath.Contains("http://") || parentPath.Contains("https://")))
                    break;
                string httpHead = parentPath.Substring(0, parentPath.IndexOf(':') + 1);
                Uri uri = WebRequest.Create(parentPath).RequestUri;
                string hostName = uri.Host;
                string port = uri.Port.ToString();
                if (port != "80") hostName += string.Format(":{0}", port);
                parentPath = uri.AbsolutePath;

                if (urlPath.Length >= 2 && urlPath.Substring(0, 2).Equals("./"))
                    urlPath = urlPath.Substring(2);
                if (urlPath.Length >= 1 && urlPath.Substring(0, 1).Equals("/"))
                    urlPath = urlPath.Substring(1);
                while ((parentPath.Length <= 0 || parentPath.Equals("/")) && urlPath.Contains("../"))
                {
                    urlPath = urlPath.Replace("../", "");
                }
                if (urlPath.Contains("../"))
                {
                    string[] _parentPath = parentPath.Split('/');
                    _parentPath = _parentPath.Where(p => p != "").ToArray();
                    string[] _urlPath = urlPath.Split('/');
                    int ddCount = _urlPath.Where(u => u == "..").Count();
                    for (int i = 0; i < _urlPath.Length; i++)
                    {
                        string _url = _urlPath[i];


                        if (_url == "..")
                            _urlPath[i] = _parentPath[(_parentPath.Length - ddCount) + i];
                        else break;

                    }
                    urlPath = string.Join("/", _urlPath);
                }
                else
                    urlPath = string.Concat(parentPath.Substring(0, parentPath.LastIndexOf("/") + 1), urlPath);
                if (string.IsNullOrEmpty(urlPath))
                    break;
                while (urlPath.Length >= 1 && urlPath.Substring(0, 1).Equals("/"))
                {
                    urlPath = urlPath.Substring(1);
                }

                fomatUrl = string.Format("{0}//{1}/{2}", httpHead, hostName, urlPath);
            } while (false);
            return fomatUrl;

        }
        #endregion
    }
}