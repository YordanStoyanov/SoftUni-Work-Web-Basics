namespace MyWebServer.Server.HTTP
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; init; }

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();
        public string Content { get; init; }
    }
}
