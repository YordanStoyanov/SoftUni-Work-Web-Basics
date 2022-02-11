namespace MyWebServer.Server.Results
{
    using MyWebServer.Server.HTTP;
    public class TextResult : ContentResult
    {
        public TextResult(HttpResponse response, string text) 
            : base(response, text, HttpContentType.PlainText)
        { 
        }
    }
}
