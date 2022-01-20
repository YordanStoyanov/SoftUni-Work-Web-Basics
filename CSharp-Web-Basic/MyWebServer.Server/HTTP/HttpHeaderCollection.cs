using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.HTTP
{
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> heareds;
        public HttpHeaderCollection()
        {
            this.heareds = new Dictionary<string, HttpHeader>();
        }
    }
}
