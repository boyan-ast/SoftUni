using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectXmlOutputModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ProjectTaskXmlOutputModel[] Tasks { get; set; }
    }
}
