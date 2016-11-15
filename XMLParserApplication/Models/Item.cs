using System.Xml.Serialization;

namespace XMLParserApplication.Models
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        public int Id { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "pubDate")]
        public string PublishedDate { get; set; }

        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }
    }
}