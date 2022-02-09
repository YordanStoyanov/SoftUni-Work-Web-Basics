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
        protected HttpResponse Html(string html) 
            => new HtmlResponse(html); 
        protected HttpResponse Redirection(string location)
            => new RedirectResponse(location);
        protected HttpResponse View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName);
    //    protected HttpResponse View(string view, object model = null)
    //        => new ViewResponse(view);
    }
}
