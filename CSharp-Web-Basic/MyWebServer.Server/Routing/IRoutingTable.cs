namespace MyWebServer.Server.Routing
{
    using MyWebServer.Server.HTTP;
    using System;
<<<<<<< HEAD

=======
>>>>>>> edf02670b93d14198f089930ba0724975919e8d2
    public interface IRoutingTable
    {
        IRoutingTable Map(HttpMethod method, string path, HttpResponse response);
        IRoutingTable Map(HttpMethod method,string path, Func<HttpRequest, HttpResponse> responseFunction);
        IRoutingTable MapGet(string path, HttpResponse response);
        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);
<<<<<<< HEAD
        
        IRoutingTable MapPost(string path, HttpResponse response);
        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);
        
=======
        IRoutingTable MapPost(string path, HttpResponse response);
        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);
>>>>>>> edf02670b93d14198f089930ba0724975919e8d2
    }
}
