﻿namespace MyWebServer.Server.HTTP
{
    using DocumentFormat.OpenXml.ExtendedProperties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyWebServer.Server.HTTP;

    public class HttpRequest
    {
        private const string newLine = "\r\n";
        public HttpMethod Method { get; set; }
        public string Path { get; set; }
        public IReadOnlyDictionary<string, string> Query { get; private set; }
        public IReadOnlyDictionary<string, string> Form { get; private set; }
        public IReadOnlyDictionary<string, HttpHeader> Headers { get; private set; }
        public IReadOnlyDictionary<string, HttpCookie> Cookies { get; private set; }
        public string Body { get; set; }
        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(newLine);
            var startLine = lines.First().Split(" ");
            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];
            var (path, query) = ParseUrl(url);
            var headerCollection = ParseHttpHeaderCollection(lines.Skip(1));
            var bodyLines = lines.Skip(headerCollection.Count + 2).ToArray();
            var body = string.Join(newLine, bodyLines);
            var form = ParseForm(headerCollection, body);

            return new HttpRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headerCollection,
                Body = body,
                Form = form
            };
        }


        private static Dictionary<string, HttpHeader> ParseHttpHeaderCollection(IEnumerable<string> headerLines)
        {
            var headerCollection = new Dictionary<string, HttpHeader>();
            foreach (var headerLine in headerLines)
            {
                if (headerLine == String.Empty)
                {
                    break;
                }

                var indexOfColon = headerLine.IndexOf(":");
                var headerName = headerLine.Substring(0, indexOfColon);
                var headerValue = headerLine[(indexOfColon + 1)..].Trim();

                headerCollection.Add(headerName, new HttpHeader(headerName, headerValue));
            }
            return headerCollection;
        }
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
        private static (string, Dictionary<string, string>) ParseUrl(string url)
        {
            var urlParts = url.Split('?');
            var path = urlParts[0].ToLower();
            var query = urlParts.Length > 1 
                ? ParseQuery(urlParts[1]) 
                : new Dictionary<string, string>();
            return (path, query);
        }

        private static Dictionary<string, string> ParseQuery(string queryString) 
            => queryString
            .Split('&')
            .Select(part => part
            .Split('='))
            .Where(part => part.Length == 2)
            .ToDictionary(part => part[0], part => part[1]);

        private static Dictionary<string, string> ParseForm(Dictionary<string, HttpHeader> headerCollection, string body)
        {
            var result = new Dictionary<string, string>();
            if (headerCollection.ContainsKey(HttpHeader.ContentType) 
                && headerCollection[HttpHeader.ContentType].Value == HttpContentType.FormUrlEncoded)
            {
                result = ParseQuery(body);
            }
            return result;
        }
    }
}
