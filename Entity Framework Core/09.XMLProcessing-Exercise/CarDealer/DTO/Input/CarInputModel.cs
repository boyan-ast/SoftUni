using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("Car")]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartIdDto[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}