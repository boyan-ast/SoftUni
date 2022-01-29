namespace Football.App
{
    public class Header
    {
        public Header(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; init; }
        public string Value { get; init; }
    }
}
