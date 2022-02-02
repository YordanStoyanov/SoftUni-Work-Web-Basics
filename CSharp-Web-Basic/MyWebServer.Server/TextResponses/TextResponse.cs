namespace MyWebServer.Server.TextResponses
{
    using MyWebServer.Server.Common;
    using MyWebServer.Server.HTTP;
    using System.Text;

    public class TextResponse : HttpResponse
    {
        public TextResponse(string text) 
            : this(text, "text/plain; charset=UTF-8")
        {
        }

        public TextResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);
            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();
            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Length", contentLength);

            this.Content = text;
        }
    }
}
