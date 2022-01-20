using MyWebServer.Server;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class StartUp
{
    public static async Task Main()
    {
        var server = new HTTPServer("127.0.01.1", 9090);
        await server.Start();
    }
}