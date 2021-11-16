using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output
{
    [XmlRoot("Users")]
    public class UsersOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserOutputModel[] Users { get; set; }
    }
}
