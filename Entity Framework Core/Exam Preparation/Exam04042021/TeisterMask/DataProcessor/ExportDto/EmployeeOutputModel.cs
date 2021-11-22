using System;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class EmployeeOutputModel
    {
        public string Username { get; set; }

        public TaskOutputModel[] Tasks { get; set; }
    }

    public class TaskOutputModel
    {
        public string TaskName { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }

        public string LabelType { get; set; }

        public string ExecutionType { get; set; }
    }
}
