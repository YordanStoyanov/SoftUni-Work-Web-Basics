namespace CSharp_Web_Basic.Controllers
{
    using MyWebServer.Server;
    using MyWebServer.Server.HTTP;
    using MyWebServer.Server.Results;

    public class AccountController : Controller
    {
        public AccountController(HttpRequest request) 
            : base(request)
        {
        }
        public ActionResult ActionWithCookies()
        {
            this.Response.AddCookie("My-cookie", "My-value");
            return Text("Hello");
        }
    }
}
