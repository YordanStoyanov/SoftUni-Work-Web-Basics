namespace MyWebServer.Server.Results
{
    using MyWebServer.Server.HTTP;
    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult() 
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
