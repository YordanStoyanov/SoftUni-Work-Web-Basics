using MyWebServer.Server;
using MyWebServer.Server.TextResponses;
using System.Threading.Tasks;

public class StartUp
{
    public static async Task Main()
        => await new HTTPServer(
            routers => routers
            .MapGet("/", new TextResponse("Hello from my web server."))
            .MapGet("/Cats", new TextResponse("Hello from the cats!")))
        .Start();

        //var server = new HTTPServer("127.0.0.1", 9090);
        //await server.Start();
}