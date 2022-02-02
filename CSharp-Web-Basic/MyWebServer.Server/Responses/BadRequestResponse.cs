namespace MyWebServer.Server.Responses
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
