using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Photocopier.Models
{
    [Serializable, XmlRoot("Copiers")]
    public class Copier
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "ShortDescription")]
        public string ShortDescription { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
        [XmlElement(ElementName = "ImgPath")]
        public string ImgPath { get; set; }
        [XmlElement(ElementName = "Thumbnail")]
        public string Thumbnail { get; set; }
    }
}