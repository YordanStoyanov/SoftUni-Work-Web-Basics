namespace MyWebServer.Server.HTTP
{
    using DocumentFormat.OpenXml.ExtendedProperties;
    using System.Collections.Generic;
    public class HttpRequest
    {
        private const string newLine = "\r\n";
        private HttpMethod Method { get; set; }
        public string Url { get; set; }
        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();
        public string Body { get; set; }
        //public static HttpRequest Parse(string request)
        //{
        //    var lines = request.Split(newLine);
        //    var startLine = lines.First().Split(" ");
        //    var method = ParseHttpMethod(startLine[0]);
        //    var url = startLine[1];

        //}
        private static HttpMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new System.InvalidOperationException()

            };
        }
    }
}
