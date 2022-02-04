namespace MyWebServer.Server.Responses
{
    using MyWebServer.Server.HTTP;
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html) 
            : base(html, HttpContentType.Html)
        {
        }

        public HtmlResponse(string text, string contentType) 
            : base(text, contentType)
        {
        }
    }
}
