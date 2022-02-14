namespace Football.App.ImportDto.Players
{
    public class ApiPlayersResponseDto
    {
        public int Results { get; init; }

        public TeamPlayersInfoDto[] Response { get; set; }
    }
}
