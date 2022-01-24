using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Data
{
    public class DBContext
    {
        public IEnumerable<Cat> AllCat()
        {
            return new List<Cat>
            {
                new Cat{Id = 1, Name = "Pesho", Age = 1, Owner = new Owner{ Id = 1, Name = "Yordan"}},
                new Cat{Id = 2, Name = "Gosho", Age = 1, Owner = new Owner{ Id = 2, Name = "Yordan"}}
            };
        }
    }
}
