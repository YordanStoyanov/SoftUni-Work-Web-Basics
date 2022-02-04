namespace MyWebServer.Server.Responses
{
    using MyWebServer.Server.HTTP;
    using System.IO;
    using MyWebServer.Server.Responses;

    public class ViewResponse : HttpResponse
    {
        public ViewResponse(string viewPath)
            : base(HttpStatusCode.OK) 
            => this.GetHtml(viewPath);

        private void GetHtml(string viewPath)
        {
            viewPath = Path.GetFullPath("./" + viewPath.TrimStart('/'));

            if (!File.Exists(viewPath))
            {
                var statusCode = HttpStatusCode.NotFound;
                return;
            }

            var viewContent = File.ReadAllText(viewPath);
            this.PrepareContent(viewContent, HttpContentType.Html);
        }
    }
}
