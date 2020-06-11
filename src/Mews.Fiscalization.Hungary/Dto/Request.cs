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
        public Header Header { get; }

        [XmlElement("user")]
        public User User { get; }

        [XmlElement("software")]
        public Software Software { get; }
    }
}