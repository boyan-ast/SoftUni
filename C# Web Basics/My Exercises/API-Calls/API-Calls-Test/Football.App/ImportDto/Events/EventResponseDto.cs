namespace Football.App.ImportDto.Event
{
    public class EventResponseDto
    {
        public EventTimeInfo Time { get; set; }

        public TeamInfoDto Team { get; set; }

        public EventPlayerInfo Player { get; set; }

        public EventAssistInfo Assist { get; set; }

        public string Type { get; set; }

        public string Detail { get; set; }
    }
}
