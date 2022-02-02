using MyWebServer.Server;
using MyWebServer.Server.Responses;
using MyWebServer.Server.TextResponses;
using System.Threading.Tasks;

public class StartUp
{
    public static async Task Main()
        => await new HTTPServer(
            routers => routers
            .MapGet("/", new TextResponse("Hello from my web server."))
            .MapGet("/Cats", new HtmlResponse("Hello from the cats!"))
            .MapGet("/Dogs", new HtmlResponse("Hello from the dogs!")))
        .Start();
}