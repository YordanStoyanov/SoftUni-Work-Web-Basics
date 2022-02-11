namespace MyWebServer.Server.Results
{
    using MyWebServer.Server.HTTP;
    public class NotFoundResult : ActionResult
    {
        public NotFoundResult(HttpResponse response)
            : base(response) 
            => this.StatusCode = HttpStatusCode.NotFound;
    }
}
