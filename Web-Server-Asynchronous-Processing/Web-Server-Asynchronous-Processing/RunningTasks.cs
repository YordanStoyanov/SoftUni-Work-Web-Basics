using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web_Server_Asynchronous_Processing
{
    public class RunningTasks
    {
        public async Task Run()
        {
            var result = await DoSomething();
            Console.WriteLine(result);
        }

        public Task<int> DoSomething()
        {
            return Task.Run(() =>
            {
                return 100;
            });
        }
    }
}
