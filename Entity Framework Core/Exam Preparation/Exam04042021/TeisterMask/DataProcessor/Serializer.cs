namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Include(p => p.Tasks)
                .AsEnumerable()
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new ProjectOutputModel
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ProjectTaskOutputModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.Tasks.Length)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectOutputModel[]), new XmlRootAttribute("Projects"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, projects, ns);

            return writer.ToString();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                   .Include(x => x.EmployeesTasks)
                   .ThenInclude(et => et.Task)
                   .AsEnumerable()
                   .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                   .Select(e => new EmployeeOutputModel
                   {
                       Username = e.Username,
                       Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .Select(et => et.Task)
                        .Select(t => new TaskOutputModel
                        {
                            TaskName = t.Name,
                            OpenDate = t.OpenDate,
                            DueDate = t.DueDate,
                            LabelType = t.LabelType.ToString(),
                            ExecutionType = t.ExecutionType.ToString()
                        })
                        .OrderByDescending(t => t.DueDate)
                        .ThenBy(t => t.TaskName)
                        .ToArray()
                   })
                   .OrderByDescending(e => e.Tasks.Count())
                   .ThenBy(e => e.Username)
                   .Take(10)
                   .ToArray();

            var settings = new JsonSerializerSettings
            {
                Culture = CultureInfo.InvariantCulture,
                DateFormatString = @"MM/dd/yyyy",
                Formatting = Formatting.Indented
            };

            string employeesJson = JsonConvert.SerializeObject(employees, settings);

            return employeesJson;
        }
    }
}