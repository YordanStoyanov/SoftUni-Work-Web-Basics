using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Web_Server_Asynchronous_Processing
{
    public class RunningThread
    {
        public void Run()
        {
            Console.WriteLine();
            Thread thread = new Thread(() =>
            {
                for (int i = 200; i < 300; i++)
                {
                    var current = i;
                    Console.WriteLine($"Current nubmer is {current}");
                }
            });
            thread.Start();//startirane na treda
            thread.Join();//izchakvane na zavurshvaneto na treda predi da prodaljavame natatak
        }
    }
}
