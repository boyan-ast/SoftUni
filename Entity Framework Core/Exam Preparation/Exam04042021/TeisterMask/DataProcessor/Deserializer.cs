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
            StringBuilder result = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectInputModel[]), new XmlRootAttribute("Projects"));

            ProjectInputModel[] projectsDto = xmlSerializer.Deserialize(new StringReader(xmlString)) as ProjectInputModel[];

            List<Project> projects = new List<Project>();

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;

                bool isValidOpenDate = DateTime.TryParseExact(projectDto.OpenDate, @"dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isValidOpenDate)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!String.IsNullOrEmpty(projectDto.DueDate))
                {
                    DateTime dueDateCheck;

                    bool isValidDueDate = DateTime.TryParseExact(projectDto.DueDate, @"dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateCheck);

                    if (!isValidDueDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateCheck;
                }

                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isValidTaskOpenDate = DateTime.TryParseExact(taskDto.OpenDate, @"dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    bool isValidTaskDueDate = DateTime.TryParseExact(taskDto.DueDate, @"dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isValidTaskOpenDate || !isValidTaskDueDate || (taskOpenDate < project.OpenDate) || 
                        (project.DueDate.HasValue && taskDueDate > project.DueDate.Value))
                    {
                        result.AppendLine(ErrorMessage);
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

                    project.Tasks.Add(task);
                }

                projects.Add(project);

                result.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<EmployeeInputModel[]>(jsonString);

            var employees = new List<Employee>();

            StringBuilder sb = new StringBuilder();

            var tasksIds = context.Tasks.Select(x => x.Id);

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskDtoId in employeeDto.Tasks.Distinct())
                {
                    if (!tasksIds.Contains(taskDtoId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { TaskId = taskDtoId });
                }

                employees.Add(employee);

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

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