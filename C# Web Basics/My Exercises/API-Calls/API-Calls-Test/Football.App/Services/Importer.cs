using Football.App.Data;
using Football.App.Data.Models;
using Football.App.Data.Models.Enums;
using Football.App.ImportDto.Teams;

namespace Football.App.Services
{
    public class Importer : IImporter
    {
        private const int LeagueId = 172;
        private const int Season = 2021;

        private readonly IAdminServices adminService;
        private readonly ApplicationDbContext data;


        public Importer(
            IAdminServices adminService,
            ApplicationDbContext applicationDbContext)
        {
            this.adminService = adminService;
            this.data = applicationDbContext;
        }

        public IEnumerable<TeamStadiumDto> TeamsAndStadiumsDto { get; private set; } = new List<TeamStadiumDto>();

        public async Task ImportPlayers()
        {
            var teamIds = this.data.Teams
                .Select(t => new
                {
                    Id = t.Id,
                    ExternId = t.ExternId
                })
                .ToList();

            foreach (var team in teamIds)
            {
                var squadDto = await this.adminService.GetTeamSquadJsonAsync(team.ExternId);

                foreach (var player in squadDto.Players)
                {
                    var newPlayer = new Player
                    {
                        ExternId = player.Id,
                        Name = player.Name,
                        Age = player.Age,
                        Number = player.Number,
                        Position = Enum.Parse<Position>(player.Position, true),
                        TeamId = team.Id
                    };

                    await this.data.Players.AddAsync(newPlayer);
                }
            }

            await this.data.SaveChangesAsync();
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
