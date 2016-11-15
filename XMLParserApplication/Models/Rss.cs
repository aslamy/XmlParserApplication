using System.Xml.Serialization;

namespace XMLParserApplication.Models
{
    [XmlRoot(ElementName = "rss")]
    public class Rss
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
}