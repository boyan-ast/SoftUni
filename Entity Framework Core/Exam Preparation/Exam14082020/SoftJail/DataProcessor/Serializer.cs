
using SoftJail.Data;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ExportDto;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor
{
    public class Serializer
    {
        public static string JsonConver { get; private set; }

        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new PrisonerJsonOutputModel
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => po.Officer)
                        .Select(o => new OfficerJsonOutputModel
                        {
                            OfficerName = o.FullName,
                            Department = o.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(double.Parse(p.PrisonerOfficers.Sum(po => po.Officer.Salary).ToString("f2")), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string prisonersJson = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return prisonersJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(",");

            var prisoners = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new PrisonerXmlOutputModel
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails.Select(m => EncryptMessage(m)).ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PrisonerXmlOutputModel[]), new XmlRootAttribute("Prisoners"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, prisoners, ns);

            return writer.ToString();
        }

        private static MessageXmlOutputModel EncryptMessage(Mail m)
        {
            char[] charArray = m.Description.ToCharArray();
            Array.Reverse(charArray);

            MessageXmlOutputModel encryptedMessage = new MessageXmlOutputModel();
            encryptedMessage.Description = new string(charArray);

            return encryptedMessage;
        }
    }
}