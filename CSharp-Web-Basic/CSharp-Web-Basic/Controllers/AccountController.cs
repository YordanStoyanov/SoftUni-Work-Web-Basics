namespace CSharp_Web_Basic.Controllers
{
    using MyWebServer.Server;
    using MyWebServer.Server.HTTP;
    using MyWebServer.Server.Results;
    using System;

    public class AccountController : Controller
    {
        public AccountController(HttpRequest request) 
            : base(request)
        {
        }
        public ActionResult ActionWithCookies()
        {
            const string cookieName = "My-cookie";
            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];
                return Text($"Cookies already exist {cookie}");
            }
            this.Response.AddCookie(cookieName, "My-value");
            return Text("Cookies set");
        }

        public HttpResponse ActionWithSession()
        {
            const string currentDateKey = "CurrentDate";
            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                var currentDate = this.Request.Session[currentDateKey];
                return Text($"Stored date {currentDate}");
            }
            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();
            return Text("Date stored");
        }
    }
}
