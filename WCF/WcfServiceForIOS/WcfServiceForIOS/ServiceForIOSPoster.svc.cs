using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using WcfServiceForIOS.Model;
using WcfServiceForIOS.Tools;
using System.Reflection;

namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceForIOSPoster”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceForIOSPoster.svc 或 ServiceForIOSPoster.svc.cs，然后开始调试。
   
    public class ServiceForIOSPoster : IServiceForIOSPoster
    {
        
        public ConnectStatus SavePoster(Poster newPoster)
        {
            if (newPoster != null)
            {
                try
                {
                    List<sqlparameters> paras = new List<sqlparameters>();
                    sqlparameters para_user_id = new sqlparameters("P_User_ID", newPoster.User_ID);
                    sqlparameters para_poster = new sqlparameters("P_Poster_Input", newPoster.PosterInput);

                    paras.AddParas(para_poster, para_user_id);
                    DataConn con = new DataConn();
                    con.StroedGet("PKG_Poster_New", paras);
                }
                catch (Exception e) {
                    WcfLog.Log(logLevel.Error,e);
                    return ConnectStatus.ActionFailed;
                }

            }
            else {
                return ConnectStatus.ActionFailed;
            }
            return ConnectStatus.ActionSuccess;
        }
        /// <summary>
        /// 取得该用户的帖子,获得总记录数，分页表，第一个是总记录数，第二个是分页表
        /// </summary>
        /// <param name="User_ID"></param>
        /// <param name="pageStart"></param>
        /// <param name="pageEnd"></param>
        /// <returns></returns>
        public List<Poster> GetPosterByUserID(string User_ID, int pageStart, int pageEnd)
        {
            List<Poster> posterList = new List<Poster>();
            try
            {
                if (pageStart >= 0 && pageEnd >= pageStart)
                {

                    DataConn conn = new DataConn();
                    sqlparameters para_user_id = new sqlparameters("r_User_ID", User_ID);
                    sqlparameters para_page_start = new sqlparameters("startPageNum", pageStart);
                    sqlparameters para_page_end = new sqlparameters("endPageNum", pageEnd);
                    List<sqlparameters> paras = new List<sqlparameters> { para_user_id, para_page_start, para_page_end };
                    List<DataTable> dts = conn.StroedGetTableList("PKG_Get_Poster_ByUserID", paras);
                    //获得dts有两个表，第一个是记录数，第二个是帖子内容
                  /*
                    Type t = typeof(Poster);                    
                    PropertyInfo[] propertys = t.GetProperties();
                    DataTable dt_poster = dts[1];
                    for (int i = 0; i < dt_poster.Rows.Count; i++)
                    {
                        object poster_o = Activator.CreateInstance(t);
                        foreach (PropertyInfo p in propertys)
                        {
                            if (dts[1].Columns.Contains(p.Name))
                            {
                                p.SetValue(poster_o, Convert.ChangeType(dt_poster.Rows[i][p.Name].ToString(), p.PropertyType), null);

                            }
                        }
                        posterList.Add(poster_o as Poster);
                    }
                   */
                    posterList = DataTableToObject<Poster>.ToT(dts[1]);
                    return posterList;

                }
                else
                {
                    return posterList;
                }
            }
            catch (Exception e)
            {
                
                WcfLog.Log(logLevel.Error, e);
                return posterList;
            }
        }

        public string GetPosterByUserIDTest(string User_ID, int pageStart, int pageEnd) {
            DataTable dt = new DataTable();
            if (pageStart >= 0 && pageEnd >= pageStart)
            {

                DataConn conn = new DataConn();
                sqlparameters para_user_id = new sqlparameters("r_User_ID", User_ID);
                sqlparameters para_page_start = new sqlparameters("startPageNum", pageStart);
                sqlparameters para_page_end = new sqlparameters("endPageNum", pageEnd);
                List<sqlparameters> paras = new List<sqlparameters> { para_user_id, para_page_start, para_page_end };
                List<DataTable> dts = conn.StroedGetTableList("PKG_Get_Poster_ByUserID", paras);
                dt = dts[1];
            }
            return ObjectToJson.Serialize(dt,false);
        }
        public string JSONData(string Posterid)
        {
            return "This poster id is " + Posterid + "from json";
        }

    }
}
