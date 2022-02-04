namespace MyWebServer.Server.Responses
{
    using MyWebServer.Server.Common;
    using MyWebServer.Server.HTTP;
    using System.Text;

    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string content, string contentType)
            : base(HttpStatusCode.OK) 
            => this.PrepareContent(content, contentType);
    }
}
