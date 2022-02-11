using Football.App.ImportDto.Teams;

namespace Football.App.ImportDto.Players
{
    public class TeamPlayersInfoDto
    {
        public TeamInfoDto Team { get; init; }

        public PlayerInfoDto[] Players { get; init; }
    }
}
