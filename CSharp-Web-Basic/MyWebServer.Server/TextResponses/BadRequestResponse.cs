namespace MyWebServer.Server.TextResponses
{
    using MyWebServer.Server.HTTP;
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse() 
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
