namespace MyWebServer.Server.HTTP
{
    using System.Collections.Generic;
    public class HttpRequest
    {
        private HttpMethod Method { get; set; }
        public string Url { get; set; }

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();
        public string Body { get; set; }
    }
}
