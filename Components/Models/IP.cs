using System.ComponentModel;
using System.Xml.Serialization;

namespace MulTools.Components.Models
{
    [XmlRoot("IP")]
    public class IP
    {
        [XmlElement("IPDZ"), Description("IP地址")]
        public string IPDZ
        {
            get;
            set;
        }
        [XmlElement("ZWYM"), Description("子网掩码")]
        public string ZWYM
        {
            get;
            set;
        }
        [XmlElement("MRWG"), Description("默认网关")]
        public string MRWG
        {
            get;
            set;
        }
        [XmlElement("FDNS"), Description("首选DNS")]
        public string FDNS
        {
            get;
            set;
        }
        [XmlElement("SDNS"), Description("备选DNS")]
        public string SDNS
        {
            get;
            set;
        }
        [XmlElement("NAME"), Description("配置名称")]
        public string Name
        {
            get;
            set;
        }
    }
}
