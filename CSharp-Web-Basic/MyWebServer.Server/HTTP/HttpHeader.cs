namespace MyWebServer.Server.HTTP
{
    using MyWebServer.Server.Common;
    public class HttpHeader
    {
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string HttpVersion = "HTTP/1.1";
        public const string Server = "Server";
        public const string MyWebServer = "My web server";
        public const string Date = "Date";
        public const string Location = "Location";
        public HttpHeader(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; init; }
        public string Value { get; init; }

        public override string ToString()
            => $"{this.Name}: {this.Value}";
    }
}
