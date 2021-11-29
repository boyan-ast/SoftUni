using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserXmlOutputModel
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public UserPurchaseXmlOutputModel[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
