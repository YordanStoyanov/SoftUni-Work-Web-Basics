using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.HTTP
{
    public class HttpHeaderCollection : IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> heareds;
        public HttpHeaderCollection()
        {
            this.heareds = new Dictionary<string, HttpHeader>();
        }

        public void Add(string name, string value)
        {
            var header = new HttpHeader(name, value);
            this.heareds.Add(name, header);
        }

        public IEnumerator<HttpHeader> GetEnumerator()
            => this.heareds.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public int Count => this.heareds.Count;
    }
}
