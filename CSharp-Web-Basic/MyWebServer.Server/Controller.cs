namespace MyWebServer.Server
{
    using MyWebServer.Server.HTTP;
    using MyWebServer.Server.Responses;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller(HttpRequest request)
            => this.Request = request;
        protected HttpRequest Request { get; private set; }
        protected HttpResponse Response(string text)
            => new TextResponse(text);
        protected HttpResponse Text(string text)
            => new TextResponse(text);
        protected HttpResponse Html(string html) 
            => new HtmlResponse(html); 
        protected HttpResponse Redirection(string location)
            => new RedirectResponse(location);
        protected HttpResponse View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, this.GetControllerName(), null);
        protected HttpResponse View(string viewName, object model)
            => new ViewResponse(viewName, this.GetControllerName(), model);
        protected HttpResponse View(object model, [CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, this.GetControllerName(), model);

        private string GetControllerName()
        {
            return this.GetType().Name.Replace(nameof(Controller), string.Empty);
        }
    }
}
