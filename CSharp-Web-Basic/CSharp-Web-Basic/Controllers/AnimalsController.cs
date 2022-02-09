using CSharp_Web_Basic.Models.Animals;
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
            const string ageKey = "Age";
            var query = this.Request.Query;
            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";
            var catAge = query.ContainsKey(ageKey) ? int.Parse(query[ageKey]) : 0;

            var catViewModel = new CatViewModel
            {
                Name = catName,
                Age = catAge
            };
            return View(catViewModel);
        }

        public HttpResponse Dogs() => View("Dogs");
        public HttpResponse Bunnies() => View("Rabbits");
        public HttpResponse Turtles() => View("Wild/Turtles");
    }
}
