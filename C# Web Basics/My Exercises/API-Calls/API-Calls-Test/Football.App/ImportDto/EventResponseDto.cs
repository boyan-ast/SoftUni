namespace Football.App.ImportDto
{
    public class EventResponseDto
    {
        public EventTimeInfo Time { get; set; }

        public EventTeamInfo Team { get; set; }

        public EventPlayerInfo Player { get; set; }

        public EventAssistInfo Assist { get; set; }

        public string Type { get; set; }

        public string Detail { get; set; }
    }
}
