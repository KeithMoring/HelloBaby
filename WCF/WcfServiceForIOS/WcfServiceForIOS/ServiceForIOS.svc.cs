using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

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
    }
        #endregion

}
