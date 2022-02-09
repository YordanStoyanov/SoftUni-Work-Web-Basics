namespace CSharp_Web_Basic.Controllers
{
    using MyWebServer.Server;
    using MyWebServer.Server.HTTP;
    using System;
    public class CatsController : Controller
    {
        public CatsController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse CreateCat() => View("CreateCat");
        public HttpResponse Save()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"]; 
            return Text($"{name} - {age}");
        }
    }
}
