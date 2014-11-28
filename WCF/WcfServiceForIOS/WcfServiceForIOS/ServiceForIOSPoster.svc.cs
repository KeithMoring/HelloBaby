using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using WcfServiceForIOS.Model;
using WcfServiceForIOS.Tools;

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
        public string JSONData(string Posterid)
        {
            return "This poster id is " + Posterid + "from json";
        }

    }
}
