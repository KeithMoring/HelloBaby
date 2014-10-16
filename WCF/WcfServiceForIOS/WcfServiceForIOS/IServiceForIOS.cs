using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServiceForIOS”。
    [ServiceContract]
    public interface IServiceForIOS
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Xml,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "json/{id}")]
        string JSONData(string id);
        [OperationContract]
        [WebInvoke(Method = "POST",
                 RequestFormat = WebMessageFormat.Xml,
                 ResponseFormat = WebMessageFormat.Xml,
                 BodyStyle = WebMessageBodyStyle.Bare,
                 UriTemplate = "Poster")]
        ResponsePoster PosterManager(RequestPoster reqData);

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 BodyStyle = WebMessageBodyStyle.Wrapped,
                 UriTemplate = "PosterJson/{name}/{level}/{note}/{mm}")]
        ResponsePoster PosterManagerJson(string name, string level, string note,string mm);

        ///Creat new user
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "createUser"
            )]
        int NewUser(string name,int sex,string Md5_password,string role,string email,string phoneNum);
        
    }
    [DataContract(Namespace = "http://www.entlib.com/business")]
    public class RequestPoster {
        [DataMember]
        public string PosterData { get; set; }
    }
    [DataContract]
    public class ResponsePoster {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Level { get; set; }
        [DataMember]
        public string Note { get; set; }
    }
    
}
