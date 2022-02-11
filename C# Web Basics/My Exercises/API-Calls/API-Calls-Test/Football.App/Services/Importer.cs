using Football.App.Data.Models;
using Football.App.ImportDto.Teams;
using Microsoft.EntityFrameworkCore;

namespace Football.App.Services
{
    public class Importer : IImporter
    {
        private const int LeagueId = 172;
        private const int Season = 2021;

        private readonly IAdminServices adminService;
        private readonly DbContext data;


        public Importer(
            IAdminServices adminService,
            DbContext applicationDbContext)
        {
            this.adminService = adminService;
            this.data = applicationDbContext;
        }

        public IEnumerable<TeamStadiumDto> TeamsAndStadiumsDto { get; private set; } = new List<TeamStadiumDto>();

        public async Task ImportPlayers()
        {

        }

        public async Task ImportStadiums()
        {
            if (!this.TeamsAndStadiumsDto.Any())
            {
                this.TeamsAndStadiumsDto = (await this.adminService.GetTeamsAndStadiumsJsonAsync(LeagueId, Season)).ToList();
            }
        }

        public async Task ImportTeams()
        {
            if (!this.TeamsAndStadiumsDto.Any())
            {
                this.TeamsAndStadiumsDto = (await this.adminService.GetTeamsAndStadiumsJsonAsync(LeagueId, Season)).ToList();
            }

            foreach (var teamDto in this.TeamsAndStadiumsDto)
            {
                var team = new Team
                {
                    ExternId = teamDto.Team.Id,
                    Name = teamDto.Team.Name,
                    Logo = teamDto.Team.Logo,
                    Stadium = new Stadium
                    {
                        ExternId = teamDto.Stadium.Id,
                        Name = teamDto.Stadium.Name,
                        City = teamDto.Stadium.City,
                        Capacity = teamDto.Stadium.Capacity,
                        Image = teamDto.Stadium.Image
                    }
                };

                await this.data.AddAsync(team);
            }

            await this.data.SaveChangesAsync();
        }
    }
}
