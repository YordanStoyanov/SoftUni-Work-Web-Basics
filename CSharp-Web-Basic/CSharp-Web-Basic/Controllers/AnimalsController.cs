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
    public class AnimalsController : Controller
    {

        public AnimalsController(HttpRequest request) 
            : base (request)
        {
        }
        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            var query = this.Request.Query;
            var catName = query.ContainsKey(nameKey)
            ? query["Name"]
            : "the cats";
            var result = $"<h1>Hello from {catName}!</h1>";
            return Html(result);
        }

        public HttpResponse Dogs() => View("Dogs");
        public HttpResponse Bunnies() => View("Rabbits");
        public HttpResponse Turtles() => View("Wild/Turtles");
    }
}
