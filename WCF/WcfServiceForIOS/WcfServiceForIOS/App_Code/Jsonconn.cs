﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using System.IO;//MemoryStream
using System.Text;//StringBuilder
using System.Web.Script.Serialization;
using System.Data;

/// <summary>
/// Json 的摘要说明
/// </summary>
public static class Jsonconn
{


    public static string ToJsJson(this object item)
    {

        DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());

        using (MemoryStream ms = new MemoryStream())
        {

            serializer.WriteObject(ms, item);

            StringBuilder sb = new StringBuilder();

            sb.Append(Encoding.UTF8.GetString(ms.ToArray()));

            return sb.ToString();

        }

    }

    /// <summary>
    /// Json反序列化,用于接收客户端Json后生成对应的对象
    /// </summary>
    public static T FromJsonTo<T>(this string jsonString)
    {

        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

        T jsonObject = (T)ser.ReadObject(ms);

        ms.Close();

        return jsonObject;

    }

    /// <summary>
    /// 序列化方法（带分页）
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string Serialize(DataTable dt)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt.Columns)
            {
                result.Add(dc.ColumnName, dr[dc].ToString());
            }
            list.Add(result);
        }
        int count = 0;
        try
        {
            count = Convert.ToInt32(dt.TableName);
        }
        catch (System.Exception ex)
        {
            count = dt.Rows.Count;
        }
        string strReturn = "";
        if (count == 0)
        {
            strReturn = "{\"totalCount\":0,\"data\":[]}";
        }
        else
        {
            strReturn = ConventToJson(list, count);
        }
        return strReturn;
    }

    /// <summary>
    /// 转换为JSON对象
    /// </summary>
    /// <returns></returns>
    public static string ConventToJson<T>(List<T> list, int count)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string strJson = serializer.Serialize(list);
        strJson = strJson.Substring(1);
        strJson = strJson.Insert(0, "{" + "\"" + "totalCount" + "\"" + " :" + "\"" + count + "\"" + "," + "\"" + "data" + "\"" + ":[");
        strJson += "}";

        return strJson;
    }

    /// <summary>
    /// 不需要分页
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="flag">false</param>
    /// <returns></returns>
    public static string Serialize(DataTable dt, bool flag)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt.Columns)
            {
                result.Add(dc.ColumnName, dr[dc].ToString());
            }
            list.Add(result);
        }
        return serializer.Serialize(list); ;
    }
}
