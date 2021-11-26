namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerJsonOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public OfficerJsonOutputModel[] Officers { get; set; }

        public double TotalOfficerSalary { get; set; }
    }
}
