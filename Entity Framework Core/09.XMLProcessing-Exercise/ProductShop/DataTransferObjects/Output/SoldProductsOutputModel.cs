using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output
{
    [XmlType("SoldProducts")]
    public class SoldProductsOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductOutputModel[] Products { get; set; }
    }
}
