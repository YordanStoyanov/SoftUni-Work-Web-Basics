namespace MyWebServer.Server.Results
{
    using MyWebServer.Server.HTTP;
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response, string html) 
            : base(response, html, HttpContentType.Html)
        {
        }

        public HtmlResult(HttpResponse response, string text, string contentType) 
            : base(response, text, contentType)
        {
        }
    }
}
