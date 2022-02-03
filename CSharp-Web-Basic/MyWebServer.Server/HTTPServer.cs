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
        private readonly RoutingTable routingTable;

        public HTTPServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = 9090;
            listener = new TcpListener(this.ipAddress, port);
            routingTableConfiguration(this.routingTable = new RoutingTable());
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
                //Console.WriteLine("Server is connected!");
                var networkStream = connection.GetStream();
                var requestText = await this.ReadRequest(networkStream);
                //Console.WriteLine(requestText);
                var request = HttpRequest.Parse(requestText);
                var response = this.routingTable.ExecuteRequest(request);
                await WriteResponse(networkStream, response);
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

        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            Console.WriteLine("response");
            await networkStream.WriteAsync(responseBytes);
        }
    }
}