namespace MyWebServer.Server
{
    using MyWebServer.Server.HTTP;
    using MyWebServer.Server.Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class HTTPServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        public HTTPServer(string ipAddress, int port, Action<IRoutingTable> routingTable)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = 9090;
            listener = new TcpListener(this.ipAddress, port);
        }
        public HTTPServer(int port, Action<IRoutingTable> routingTable) 
            : this("127.0.0.1", port, routingTable)
        {
        }
        public HTTPServer(Action<IRoutingTable> routingTable) 
            : this(5000, routingTable)
        {
        }
        public async Task Start()
        {
            this.listener.Start();
            Console.WriteLine("Server is started!");
            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();
                Console.WriteLine("Server is connected!");
                var networkStream = connection.GetStream();
                var requestText = await this.ReadRequest(networkStream);
                Console.WriteLine(requestText);
                var request = HttpRequest.Parse(requestText);
                await WriteResponse(networkStream);
                connection.Close();
            }

        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var sb = new StringBuilder();
            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (networkStream.DataAvailable);
            return sb.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream)
        {
            var content = @"
<html>
    <head>
        <link rel=""icon"" href= ""data:,"">
    </head>
        <body>
            Hello from my server!
        </body>
</html>";
            var contentLength = content.Length;
            var response = $@"
HTTP/1.1 200 OK
Date: {DateTime.UtcNow.ToString("r")}
Server: My web server
Content-length: {contentLength}
Content-type: text/html; charset=UTF-8
{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            Console.WriteLine("response");
            await networkStream.WriteAsync(responseBytes);
        }
    }
}