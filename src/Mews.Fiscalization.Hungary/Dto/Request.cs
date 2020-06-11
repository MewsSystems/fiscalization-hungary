using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Hungary.Dto
{
    [Serializable]
    public abstract class Request
    {
        public Request()
        {
        }

        public Request(RequestMetadata metadata)
        {
            Header = metadata.Header;
            User = metadata.User;
            Software = metadata.Software;
        }

        [XmlElement("header")]
        public Header Header { get; set; }

        [XmlElement("user")]
        public User User { get; set; }

        [XmlElement("software")]
        public Software Software { get; set; }
    }
}