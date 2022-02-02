namespace MyWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text) 
            : base(text, "text/plain; charset=UTF-8")
        {
        }

        public HtmlResponse(string text, string contentType) 
            : base(text, contentType)
        {
        }
    }
}
