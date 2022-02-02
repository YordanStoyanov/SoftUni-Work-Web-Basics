using MyWebServer.Server;
using MyWebServer.Server.TextResponses;
using System.Threading.Tasks;

public class StartUp
{
    public static async Task Main()
        => await new HTTPServer(
            routers => routers
            .MapGet("/", new TextResponse("Hello from my web server."))
            .MapGet("/Cats", new TextResponse("<h1>Hello from the cats!</h1>", "text/html"))
            .MapGet("/Dogs", new TextResponse("<h1>Hello from the dogs!</h1>", "text/html")))
        .Start();
}