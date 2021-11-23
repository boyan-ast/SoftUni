namespace P01_HospitalDatabase
{
    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new HospitalContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
