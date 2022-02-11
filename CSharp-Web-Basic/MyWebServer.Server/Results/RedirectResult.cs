namespace MyWebServer.Server.Results
{
    using MyWebServer.Server.HTTP;

    class RedirectResult : ActionResult
    {
        public RedirectResult(HttpResponse response, string location)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(HttpHeader.Location, location);
        }
    }
}
