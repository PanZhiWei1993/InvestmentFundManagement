using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Xml;
using System.IO;

namespace RDO.Commen
{
    /// <summary>
    /// 类型转换
    /// </summary>
    public static class ExpandT
    {
        /// <summary>
        /// 使用反射将一个数据模型类的数据存入另外一个模型
        /// </summary>
        /// <typeparam name="T">返回的模型</typeparam>
        /// <param name="obj">传入的模型和数据</param>
        /// <returns></returns>
        public static T ConvertToT<T>(this object obj) where T : new()
        {
            T reT = new T();
            Type type = typeof(T);
            PropertyInfo[] rePropInfos = typeof(T).GetProperties();
            PropertyInfo[] objPropInfos = obj.GetType().GetProperties();
            for (int i = 0; i < rePropInfos.Length; i++)
            {
                PropertyInfo reInfo = rePropInfos[i];
                //查看传入的模型是否存在该属性
                for (int j = 0; j < objPropInfos.Length; j++)
                {
                    PropertyInfo objInfo = objPropInfos[j];
                    //属性名称和属性类型相同则判定是同一属性（不区分大小写）
                    if (reInfo.Name.ToLower().Equals(objInfo.Name.ToLower()) && reInfo.PropertyType.Name == objInfo.PropertyType.Name)
                    {
                        object value = objInfo.GetValue(obj, null);
                        if (value!=null && value !=DBNull.Value)
                            reInfo.SetValue(reT, value, null);
                        break;
                    }
                }
            }
            return reT;
        }
        

        /// <summary>
        /// 使用反射将一个数据模型类的数据存入另外一个模型
        /// </summary>
        /// <typeparam name="T">返回的模型</typeparam>
        /// <param name="obj">传入的模型和数据</param>
        /// <param name="reT">已经有的数据模型</param>
        /// <returns></returns>
        public static T ConvertToT<T>(this object obj,T reT) where T : new()
        {
            if(reT==null)
               reT = new T();
            Type type = typeof(T);
            PropertyInfo[] rePropInfos = typeof(T).GetProperties();
            PropertyInfo[] objPropInfos = obj.GetType().GetProperties();
            for (int i = 0; i < rePropInfos.Length; i++)
            {
                PropertyInfo reInfo = rePropInfos[i];
                //查看传入的模型是否存在该属性
                for (int j = 0; j < objPropInfos.Length; j++)
                {
                    PropertyInfo objInfo = objPropInfos[j];
                    //属性名称和属性类型相同则判定是同一属性（不区分大小写）
                    if (reInfo.Name.ToLower().Equals(objInfo.Name.ToLower()) && reInfo.PropertyType.Name == objInfo.PropertyType.Name)
                    {
                        object value = objInfo.GetValue(obj, null);
                        if (value != null && value != DBNull.Value)
                            reInfo.SetValue(reT, value, null);
                        break;
                    }
                }
            }
            return reT;
        }

        /// <summary>
        /// 使用反射将一个数据模型列表的数据存入另外一个模型列表
        /// </summary>
        /// <typeparam name="T">返回的模型</typeparam>
        /// <param name="objs">传入的模型和数据</param>
        /// <returns></returns>
        public static List<T> ConvertToIList<T>(this IList objs) where T : new()
        {
            List<T> reInfos = new List<T>();
            foreach (var item in objs)
            {
                reInfos.Add(item.ConvertToT<T>());
            }
            return reInfos;
        }
        /// <summary>
        /// 对模型中所有string字段进行防注入处理
        /// </summary>
        /// <typeparam name="T">要进行处理的模型</typeparam>
        /// <param name="obj">模型数据</param>
        /// <returns></returns>
        public static T SqlParamEscape<T>(this T obj) where T :new()
        {
            T reT = new T();
            Type type = typeof(T);
            PropertyInfo[] rePropInfos = typeof(T).GetProperties();
            PropertyInfo[] objPropInfos = obj.GetType().GetProperties();
            for (int i = 0; i < rePropInfos.Length; i++)
            {
                PropertyInfo reInfo = rePropInfos[i];
                //查看传入的模型是否存在该属性
                for (int j = 0; j < objPropInfos.Length; j++)
                {
                    PropertyInfo objInfo = objPropInfos[j];
                    if (reInfo.Name.ToLower().Equals(objInfo.Name.ToLower()))
                    {
                        object value = objInfo.GetValue(obj, null);
                        if (value != null && value != DBNull.Value)
                        {
                            //属性是string则进行防注入处理
                            value = reInfo.PropertyType.Name.ToLower() == "string" ? value.ToString().SqlParamEscape() : value;
                            reInfo.SetValue(reT, value, null);
                            break;
                        }
                            
                    }
                }
            }
            return reT;
        }
        /// <summary>
        /// 将匿名类型列表数据转换成ExpandoObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="infos"></param>
        /// <returns></returns>
        public static List<dynamic> ConvertToExpand<T>(this List<T> infos)
        {
            List<dynamic> oneList = new List<dynamic>();
            foreach (var one in infos)
            {
                dynamic dyObject = new ExpandoObject();
                // User为一个Class
                Type t = one.GetType();
                // 获取类的所有公共属性
                System.Reflection.PropertyInfo[] pInfo = t.GetProperties();
                // 遍历公共属性
                var dyreult = (IDictionary<string, object>)dyObject;
                foreach (System.Reflection.PropertyInfo pio in pInfo)
                {
                    string fieldName = pio.Name;        // 公共属性的Name
                    Type pioType = pio.PropertyType;    // 公共属性的类型
                    dyreult.Add(fieldName, pio.GetValue(one));
                }
                oneList.Add(dyObject);
            }
            return oneList;
        }
        /// <summary>
        /// 将匿名类型列表数据转换成Xml数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <param name="listAddText">子集出现list时添加的数据</param>
        /// <returns></returns>
        public static XmlDocument ConvertToXml<T>(this T datas,string listAddText="item")
        {
            XmlDocument xmldoc = new XmlDocument();
            System.Reflection.PropertyInfo[] pio = datas.GetType().GetProperties();
            foreach (var item in pio)
            {
                string fieldName = item.Name;        // 公共属性的Name
                XmlNode _XmlNode = xmldoc.CreateElement(fieldName);
                Type pioType = item.PropertyType;    // 公共属性的类型
                if (pioType is System.Collections.IList)
                {
                    XmlNode addNode = xmldoc.CreateElement(listAddText);
                    var nowData = item.GetValue(datas);
                    _XmlNode.AppendChild(trunXmlNodeTreeValue(xmldoc, addNode, nowData, listAddText));
                }
                else
                {
                    _XmlNode.InnerText = item.GetValue(datas).ToString();
                }
                xmldoc.AppendChild(_XmlNode);
            }
            return xmldoc;
        }
        public static XmlNode trunXmlNodeTreeValue(XmlDocument xmldoc,XmlNode xmlNode,object datas,string listAddText)
        {
            System.Reflection.PropertyInfo[] pio = datas.GetType().GetProperties();
            foreach (var item in pio)
           {
                string fieldName = item.Name;        // 公共属性的Name
                XmlNode nowNode = xmldoc.CreateElement(fieldName);
                Type pioType = item.PropertyType;    // 公共属性的类型
                if (pioType is System.Collections.IList)
                {
                    XmlNode addNode= xmldoc.CreateElement(listAddText);
                    var nowData =item.GetValue(datas);
                    //nowNode.AppendChild(getXmlNodeTreeValue(xmldoc, addNode, nowData, listAddText));
                }
                else
                {
                    nowNode.InnerText=item.GetValue(datas).ToString();
                }                
                xmlNode.AppendChild(nowNode);                
            }           
            return xmlNode;
        }
        #region
        //    /// <summary>
        //    /// 将匿名类型列表数据转换成ExpandoObject
        //    /// </summary>      
        //    /// <param name="infos"></param>
        //    /// <returns></returns>
        //    public static Dictionary<string,object> xmlConvertToExpand(this Stream infos)
        //    {
        //        Dictionary<string, object> oneList = new Dictionary<string, object>();
        //        XmlTextReader _XmlTextReader = new XmlTextReader(infos);
        //        while (_XmlTextReader.Read())
        //        {
        //            try
        //            {
        //                if (_XmlTextReader.AttributeCount > 0)
        //                {
        //                    List<Dictionary<string, object>> _dyObject = new List<Dictionary<string, object>>();
        //                    for (int i = 0; i < _XmlTextReader.AttributeCount; i++)
        //                    {
        //                        Dictionary<string, object> dyObject = new Dictionary<string, object>();                            
        //                        _XmlTextReader.MoveToAttribute(i);
        //                        dyObject.Add(_XmlTextReader.Name, _XmlTextReader.Value);                            
        //                    }
        //                    //_dyObject.Add(dyObject);
        //                }
        //                else
        //                {
        //                    dynamic dyObject = new ExpandoObject();
        //                    var dyreult = (IDictionary<string, object>)dyObject;
        //                    //dyreult.Add(_XmlTextReader.Name, _XmlTextReader.Value);
        //                    //oneList.Add(dyObject);
        //                }
        //            }
        //            catch (Exception )
        //            {


        //            }           
        //        }                     
        //        return oneList;
        //    }

        //    public static Dictionary<string, object> getXmlNodeTreeValue(XmlNodeList nodeList)
        //    {
        //       Dictionary<string, object> _dyObject = new Dictionary<string, object>();
        //        foreach (XmlNode item in nodeList)
        //        {

        //            if (item.HasChildNodes)
        //            {
        //                Dictionary<string, object> childNodes = getXmlNodeTreeValue(nodeList);
        //                if (_dyObject[item.Name] != null)
        //                {
        //                    if (_dyObject[item.Name].GetType() is System.Collections.IList)
        //                    {
        //                        _dyObject[item.Name];
        //                    }
        //                    else
        //                    {
        //                        _dyObject[item.Name] = new List<Dictionary<string, object>>()
        //                    }
        //                }
        //                _dyObject.Add(item.Name, childNodes);
        //            }
        //            else
        //            {                   
        //                  _dyObject.Add(item.Name, item.InnerText);
        //            }
        //        }
        //        return _dyObject;
        //    }
     #endregion
    }
}