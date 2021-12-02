namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => po.Officer)
                        .Select(o => new
                        {
                            OfficerName = o.FullName,
                            Department = o.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = decimal.Parse($"{p.PrisonerOfficers.Sum(po => po.Officer.Salary):f2}")
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string jsonText = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonText;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PrisonerXmlOutputModel[]), new XmlRootAttribute("Prisoners"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            string[] selectedPrisoners = prisonersNames.Split(",");

            var prisoners = context.Prisoners
                .ToArray()
                .Where(p => selectedPrisoners.Contains(p.FullName))
                .Select(p => new PrisonerXmlOutputModel
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new PrisonerMessageXmlOutputModel
                        {
                            Description = EncryptMessage(m.Description)
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            xmlSerializer.Serialize(writer, prisoners, ns);

            return writer.ToString();
        }

        private static string EncryptMessage(string inputMessage)
        {
            char[] charArray = inputMessage.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}