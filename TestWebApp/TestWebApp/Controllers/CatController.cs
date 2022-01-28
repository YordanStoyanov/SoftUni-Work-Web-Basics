using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class CatsController : Controller
    {
        private readonly DBContext data;
        public CatsController()
        {
            this.data = new DBContext();
        }
        public IActionResult CatsView()
        {
            return View();
        }
        public IActionResult List()
        {
            var cats = this.data
                .AllCat()
                .Select(
                c => new CatModel
                {
                    Name = c.Name, Age = c.Age, Owner = c.Owner.Name
                }).ToList();

            if (!cats.Any())
            {
                return NotFound();
            }

            return View(cats);
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
