using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceForIOS.Model
{
    [DataContract]
    public class Poster
    {
        [DataMember]
        public string OwnerName { get; set; }
        [DataMember]
        public string Title {get;set; }
         [DataMember]
        public string Content { get; set; }
         [DataMember]
        public int VisitNum { get; set; }
         [DataMember]
        public int FavorNum { get; set; }
         [DataMember]
        public int LoveNum { get; set; }
         [DataMember]
        public int OppsitionNum { get; set; }
         [DataMember]
        public int ScoresNun { get; set; }
    }
}