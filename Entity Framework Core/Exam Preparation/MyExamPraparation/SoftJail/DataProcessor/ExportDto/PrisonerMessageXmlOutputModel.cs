using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class PrisonerMessageXmlOutputModel
    {
        public string Description { get; set; }
    }
}
