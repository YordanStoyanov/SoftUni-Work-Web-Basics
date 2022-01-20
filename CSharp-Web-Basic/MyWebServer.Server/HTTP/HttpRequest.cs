namespace MyWebServer.Server.HTTP
{
    using System.Collections.Generic;
    public class HttpRequest
    {
        private HttpMethod Method { get; set; }
        public string Url { get; set; }

        public Dictionary<string, HttpHeader> Headers { get; } = new Dictionary<string, HttpHeader>();
        public string Body { get; set; }
    }
}
