using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.HTTP
{
    public enum HttpStatusCode
    {
        OK = 200,
        Found = 304,
        BadRequest = 400,
        NotFound = 404
    }
}
