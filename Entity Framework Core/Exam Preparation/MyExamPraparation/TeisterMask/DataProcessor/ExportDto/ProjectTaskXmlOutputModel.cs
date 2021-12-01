using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class ProjectTaskXmlOutputModel
    {
        public string Name { get; set; }

        public string Label { get; set; }
    }
}
