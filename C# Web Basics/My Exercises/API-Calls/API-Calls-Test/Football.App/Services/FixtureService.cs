using Football.App.Data;
using Football.App.Data.Models;
using System.Globalization;

namespace Football.App.Services
{
    public class FixtureService : IFixtureService
    {
        private readonly IAdminService adminService;
        private readonly ApplicationDbContext data;

        public FixtureService(
            IAdminService adminService,
            ApplicationDbContext data)
        {
            this.adminService = adminService;
            this.data = data;
        }

        public async Task ImportFixtures(int gameweek, int season)
        {
            var fixturesInfo = await this.adminService.GetAllFixturesByGameweekAsync(gameweek, season);

            foreach (var fixtureDto in fixturesInfo)
            {
                var externId = fixtureDto.Fixture.Id;
                var fixtureGameweek = this.data.Gameweeks.FirstOrDefault(gw => gw.Number == gameweek);
                var fixtureDate = this.ParseFixtureDate(fixtureDto.Fixture.Date.Split("T")[0]);
                var homeTeamId = this.data.Teams.FirstOrDefault(t => t.ExternId == fixtureDto.Teams.HomeTeam.Id).Id;
                var awayTeamId = this.data.Teams.FirstOrDefault(t => t.ExternId == fixtureDto.Teams.AwayTeam.Id).Id;
                var status = fixtureDto.Fixture.Status.Status;
                var homeGoals = fixtureDto.Goals.HomeGoals;
                var awayGoals = fixtureDto.Goals.AwayGoals;

                var newFixture = new Fixture
                { 
                    ExternId = externId,
                    Gameweek = fixtureGameweek,
                    Date = fixtureDate,
                    HomeTeamId = homeTeamId,
                    AwayTeamId = awayTeamId,
                    Status = status,
                    HomeGoals = homeGoals,
                    AwayGoals = awayGoals
                };

                await this.data.Fixtures.AddAsync(newFixture);
            }

            await this.data.SaveChangesAsync();
        }


        private DateTime ParseFixtureDate(string dateString)
        {
            DateTime.TryParseExact(
                dateString,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime date);

            return date;
        }
    }
}
