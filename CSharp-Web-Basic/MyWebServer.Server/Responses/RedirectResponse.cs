﻿namespace MyWebServer.Server.Responses
{
    using MyWebServer.Server.HTTP;

    class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpStatusCode.Found) 
            => this.Headers.Add("Location", location);
    }
}
