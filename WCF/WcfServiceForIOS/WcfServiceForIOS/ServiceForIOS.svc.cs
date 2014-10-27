using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
//using log4net;
using System.Reflection;


namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceForIOS”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceForIOS.svc 或 ServiceForIOS.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
   
    
    public class ServiceForIOS : IServiceForIOS
    {
        #region example
        public void DoWork()
        {
        }
        public string XMLData(string Posterid) {
            return "This poster id is" + Posterid;
        }
        public string JSONData(string Posterid) {
            return "This poster id is " + Posterid + "from json";
        }

        public ResponsePoster PosterManager(RequestPoster reqData) {
            var data = reqData.PosterData.Split('|');
            var response = new ResponsePoster
            {
                Name = data[0],
                Level = data[1],
                Note = data[2]
            };
            return response;
        }

        public ResponsePoster PosterManagerJson(string name,string levle,string note,string mm)
        {
            ResponsePoster response = new ResponsePoster { Name = name, Level = levle, Note = note };
            return response;
        }
        #endregion
        /// <summary>
        /// Create new user, 0 failed network, 1 success, 2 username has existed, 3 phonenum has existed
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="Md5_password"></param>
        /// <param name="role"></param>
        /// <param name="email"></param>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public int NewUser(string name, int sex, string Md5_password, string role, string email, string phoneNum)
        {
            try
            {
                DataConn dataconn = new DataConn();
                List<sqlparameters> parameters = new List<sqlparameters>();
                sqlparameters p_name = new sqlparameters("r_user_name", name);
                parameters.Add(p_name);               
                string exist_num=dataconn.getdata("get_exist",parameters,"int",2,"PKG_Exist_User");
                if (exist_num == "1") {

                    return 2;
                }
                sqlparameters p_sex = new sqlparameters("r_user_sex", sex);
                parameters.Add(p_sex);
                sqlparameters p_Md5_password = new sqlparameters("r_user_Password", Md5_password);
                parameters.Add(p_Md5_password);
                sqlparameters p_role = new sqlparameters("r_Role", role);
                parameters.Add(p_role);
                sqlparameters p_email = new sqlparameters("r_user_email", email);
                parameters.Add(p_email);
                sqlparameters p_phoneNum = new sqlparameters("r_user_phoneNum", phoneNum);
                parameters.Add(p_phoneNum);
                dataconn.StroedGet("PKG_Creat_User", parameters);
                return 1;
            }
            catch (Exception e) {
               // ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
               // log.Error("E",e);
                WcfLog.Log(logLevel.Error,e);
                return 0; }
            
        }

        public void testLog() {
            try
            {
                int a = 0;
                int b = 9;
                int c = b / a;
            }
            catch (Exception e) {
               // ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                //log.Error("E", e);
                WcfLog.Log(logLevel.Error, e);
            }
        }

        
    }
      


}
