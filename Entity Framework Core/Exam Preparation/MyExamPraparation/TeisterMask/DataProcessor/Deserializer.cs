namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectXmlInputModel[]), new XmlRootAttribute("Projects"));

            TextReader reader = new StringReader(xmlString);

            var projectsDto = xmlSerializer.Deserialize(reader) as ProjectXmlInputModel[];

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isProjectOpenDateValid = DateTime
                    .TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = null;

                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    bool isProjectDueDateValid = DateTime
                        .TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validProjectDueDate);

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDueDate = validProjectDueDate;
                }

                List<Task> projectTasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime
                        .TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    bool isTaskDueDateValid = DateTime
                        .TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid || 
                        taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    projectTasks.Add(task);
                }

                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                    Tasks = projectTasks
                };

                context.Projects.Add(project);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            EmployeeJsonInputModel[] employeesDto = JsonConvert.DeserializeObject<EmployeeJsonInputModel[]>(jsonString);

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                int[] tasksIds = context.Tasks.Select(t => t.Id).ToArray();

                List<int> employeeTasksIds = new List<int>();

                foreach (int taskDtoId in employeeDto.Tasks.Distinct())
                {
                    if (!tasksIds.Contains(taskDtoId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employeeTasksIds.Add(taskDtoId);
                }

                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    EmployeesTasks = employeeTasksIds
                        .Select(t => new EmployeeTask
                        {
                            TaskId = t
                        })
                        .ToArray()
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}