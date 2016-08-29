using GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for Orleans Silo to start. Press Enter to proceed...");
            Console.ReadLine();

            var myOrleansClient = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30000);
            GrainClient.Initialize(myOrleansClient);

            var helloGrain = GrainClient.GrainFactory.GetGrain<IHelloGrain>(new Guid());
            var result = helloGrain.SayHello("Thuru").GetAwaiter().GetResult();
            Console.WriteLine(result);

            Console.WriteLine("** End **");
        }
    }
}
