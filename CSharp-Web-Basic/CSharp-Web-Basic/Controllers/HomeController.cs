using MyWebServer.Server;
using MyWebServer.Server.HTTP;
using MyWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Web_Basic.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index() 
            => new TextResponse("Hello from my web server.");

        public HttpResponse LocalRedirect() => Redirection("/Cats");

        public HttpResponse ToSoftUni() => Redirection("https://softuni.bg");
    }
}
