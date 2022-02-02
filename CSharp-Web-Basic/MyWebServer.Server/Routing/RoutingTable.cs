namespace MyWebServer.Server.Routing
{
    using MyWebServer.Server.Common;
    using MyWebServer.Server.HTTP;
    using MyWebServer.Server.TextResponses;
    using System.Collections.Generic;

public class RoutingTable : IRoutingTable
{
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;
        public RoutingTable()
            => this.routes = new()
            {
                [HttpMethod.Get] = new(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new()
            };

        public IRoutingTable Map(
            string url,
            HttpMethod method,
            HttpResponse response) 
            => method switch
            {
                HttpMethod.Get => this.MapGet(url, response),
                _ => throw new System.Exception(),
            };

        public IRoutingTable MapGet(
            string url,
            HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));
            this.routes[HttpMethod.Get][url] = response;
            return this;
        }

        public IRoutingTable MapPost(
            string url,
            HttpResponse response)
        {
            return null;
        }

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestURL = request.Url;
            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestURL))
            {
                return new NotFoundResponse();
            }
            return this.routes[requestMethod][requestURL];
        }
    }
}
