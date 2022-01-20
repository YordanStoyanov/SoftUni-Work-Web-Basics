namespace MyWebServer.Server
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HTTPServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        public HTTPServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = 9090;
            listener = new TcpListener(this.ipAddress, this.port);
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
                var request = await this.ReadRequest(networkStream);
                Console.WriteLine(request);
                await WriteResponse(networkStream);
                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var sb = new StringBuilder();
            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
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
            Hello from the server!
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