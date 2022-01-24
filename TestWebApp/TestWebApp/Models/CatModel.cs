using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Data;

namespace TestWebApp.Models
{
    public class CatModel
    {
        private List<Cat> data;
        public string Name { get; init; }
        public int Age { get; init; }
        public string Owner { get; init; }
        public int Count { get { return data.Count(); } }
    }
}
