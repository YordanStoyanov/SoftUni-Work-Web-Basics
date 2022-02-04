namespace MyWebServer.Server.Responses
{
    using MyWebServer.Server.HTTP;
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text) 
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}
