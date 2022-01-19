using System.Net;
using System.Net.Sockets;
using System.Text;

var ipAddress = IPAddress.Parse("127.0.0.1");
var port = 9090;
var serverListener = new TcpListener(ipAddress, port);
serverListener.Start();
Console.WriteLine("Server is started!");
while (true)
{
    var connection = await serverListener.AcceptTcpClientAsync();
    Console.WriteLine("Server is connected!");
    var networkStream = connection.GetStream();
    var content = "Hello from the server";
    var contentLength = content.Length;
    var response = $@"HTTP/1.1 200 OK
Content-length: {contentLength}
{content}";
    var responseBytes = Encoding.UTF8.GetBytes(response);
    Console.WriteLine("response");
    await networkStream.WriteAsync(responseBytes);
    connection.Close();
}