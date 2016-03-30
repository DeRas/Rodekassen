using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rodekassen
{
    class BackgroundWork
    {
        static TimeSpan waitForWork = new TimeSpan(0, 0, 0, 5, 0);
        static ManualResetEventSlim shutdownEvent = new ManualResetEventSlim(false);
        static void Main(string[] args)
        {
            System.Threading.Thread thread = new Thread(DoWork);
            thread.Name = "My Worker Thread, Dude";
            thread.Start();

            Console.ReadLine();
            shutdownEvent.Set();
            thread.Join();
        }

        public static void DoWork()
        {
            do
            {
                //wait for work timeout or shudown event notification
                shutdownEvent.Wait(waitForWork);

                //if shutting down, exit the thread
                if (shutdownEvent.IsSet)
                    return;

                //TODO: Do Work here


            } while (true);

        }
    }
}
