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
            StringBuilder sb = new StringBuilder();

            DepartmentJsonInputModel[] departmentsDto = JsonConvert.DeserializeObject<DepartmentJsonInputModel[]>(jsonString);

            foreach (var department in departmentsDto)
            {
                if (!IsValid(department))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                bool isDepartmentValid = true;

                foreach (var cell in department.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isDepartmentValid = false;
                        break;
                    }
                }

                if (!isDepartmentValid)
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                Department validDepartment = new Department
                {
                    Name = department.Name,
                    Cells = department.Cells
                        .Select(c => new Cell
                        {
                            CellNumber = c.CellNumber,
                            HasWindow = c.HasWindow
                        })
                        .ToArray()
                };

                context.Departments.Add(validDepartment);
                context.SaveChanges();

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Length} cells");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonersDto = JsonConvert.DeserializeObject<PrisonerJsonInputModel[]>(jsonString);

            foreach (var prisoner in prisonersDto)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                bool isInDateValid = DateTime
                    .TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isInDateValid)
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (!String.IsNullOrEmpty(prisoner.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime
                        .TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validReleaseDate);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine($"Invalid Data");
                        continue;
                    }

                    releaseDate = validReleaseDate;
                }

                bool isPrisonerValid = true;

                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        isPrisonerValid = false;
                        break;
                    }
                }

                if (!isPrisonerValid)
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                Prisoner validPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = prisoner.Mails
                        .Select(m => new Mail
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        })
                        .ToArray()
                };

                context.Prisoners.Add(validPrisoner);
                context.SaveChanges();

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OfficerXmlInputModel[]), new XmlRootAttribute("Officers"));

            TextReader reader = new StringReader(xmlString);

            OfficerXmlInputModel[] officersDto = xmlSerializer.Deserialize(reader) as OfficerXmlInputModel[];

            foreach (var officer in officersDto)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                bool isPositionValid = Enum.TryParse<Position>(officer.Position, out Position position);
                bool isWeaponValid = Enum.TryParse<Weapon>(officer.Weapon, out Weapon weapon);

                if (!isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                Officer validOfficer = new Officer
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners
                        .Select(p => new OfficerPrisoner
                        {
                            PrisonerId = p.Id
                        })
                        .ToArray()
                };

                context.Officers.Add(validOfficer);
                context.SaveChanges();

                sb.AppendLine($"Imported {officer.Name} ({officer.Prisoners.Length} prisoners)");
            }

            return sb.ToString().TrimEnd();
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