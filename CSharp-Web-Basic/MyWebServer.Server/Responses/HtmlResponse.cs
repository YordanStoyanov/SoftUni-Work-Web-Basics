namespace MyWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html) 
            : base(html, "text/plain; charset=UTF-8")
        {
        }

        public HtmlResponse(string text, string contentType) 
            : base(text, contentType)
        {
        }
    }
}
