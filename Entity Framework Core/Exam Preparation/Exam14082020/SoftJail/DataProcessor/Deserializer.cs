namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var departmentsDto = JsonConvert.DeserializeObject<DepartmentJsonInputModel[]>(jsonString);

            foreach (var departmentDto in departmentsDto)
            {
                bool isValidModel = true;

                if (!IsValid(departmentDto))
                {
                    output.AppendLine("Invalid Data");
                    isValidModel = false;
                    continue;
                }

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        output.AppendLine("Invalid Data");
                        isValidModel = false;
                        break;
                    }
                }

                if (!isValidModel)
                {                 
                    continue;
                }

                Department department = new Department
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells
                        .Select(c => new Cell
                        {
                            CellNumber = c.CellNumber,
                            HasWindow = c.HasWindow
                        })
                        .ToList()
                };

                context.Departments.Add(department);
                context.SaveChanges();

                output.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }


            return output.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var prisonersDto = JsonConvert.DeserializeObject<PrisonerJsonInputModel[]>(jsonString);

            foreach (var prisonerDto in prisonersDto)
            {
                bool isValidModel = true;

                if (!IsValid(prisonerDto))
                {
                    output.AppendLine("Invalid Data");
                    isValidModel = false;
                    continue;
                }

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        output.AppendLine("Invalid Data");
                        isValidModel = false;
                        break;
                    }
                }

                if (!isValidModel)
                {
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(
                    prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime incarcerationDate);

                bool isReleaseDateValid = true;

                DateTime? releaseDate = null;

                if (prisonerDto.ReleaseDate != null)
                {
                    DateTime releaseDateParsed;

                    isReleaseDateValid = DateTime.TryParseExact(
                        prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out releaseDateParsed);

                    releaseDate = releaseDateParsed;
                }

                if (!isIncarcerationDateValid || !isReleaseDateValid)
                {
                    output.AppendLine("Invalid Data");
                    isValidModel = false;
                    continue;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = prisonerDto.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    }).ToList()
                };

                context.Prisoners.Add(prisoner);
                context.SaveChanges();

                output.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OfficerXmlInputModel[]), new XmlRootAttribute("Officers"));

            OfficerXmlInputModel[] officersDto = xmlSerializer.Deserialize(new StringReader(xmlString)) as OfficerXmlInputModel[];

            foreach (var officerModel in officersDto)
            {
                if (!IsValid(officerModel))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                bool isPositionValid = Enum.TryParse<Position>(officerModel.Position, out Position position);
                bool isWeaponValid = Enum.TryParse<Weapon>(officerModel.Weapon, out Weapon weapon);

                if (!isPositionValid || !isWeaponValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = officerModel.Name,
                    Salary = officerModel.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerModel.DepartmentId,
                    OfficerPrisoners = officerModel.Prisoners.Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.Id
                    }).ToList()
                };

                context.Officers.Add(officer);
                context.SaveChanges();

                output.AppendLine($"Imported {officer.FullName} ({officerModel.Prisoners.Length} prisoners)");
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}