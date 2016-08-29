using System;
using System.Threading.Tasks;

using Orleans;
using Orleans.Runtime.Configuration;
using Grains;
using GrainInterfaces;
using Orleans.Runtime.Host;

namespace DevTestHost
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        private static SiloHost siloHost;

        static void Main(string[] args)
        {
            // The Orleans silo environment is initialized in its own app domain in order to more
            // closely emulate the distributed situation, when the client and the server cannot
            // pass data via shared memory.
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                //AppDomainInitializerArguments = args,
            });


            //Console.WriteLine("Waiting for Orleans Silo to start. Press Enter to proceed...");
            //Console.ReadLine();

            //var myOrleansClient = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30000);
            //GrainClient.Initialize(myOrleansClient);

            //var helloGrain = GrainClient.GrainFactory.GetGrain<IHelloGrain>(new Guid());
            //var result = helloGrain.SayHello("Thuru").GetAwaiter().GetResult();
            //Console.WriteLine(result);

            //Console.WriteLine("** End **");


            //var config = ClientConfiguration.LocalhostSilo();
            //GrainClient.Initialize(config);

            // Test grains here
            //var helloGrain = GrainClient.GrainFactory.GetGrain<IHelloGrain>(new Guid());
            //var result = helloGrain.SayHello("Thuru").GetAwaiter().GetResult();
            //Console.WriteLine(result);

            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

            hostDomain.DoCallBack(ShutdownSilo);
        }

        static void InitSilo(string[] args)
        {
            siloHost = new SiloHost(System.Net.Dns.GetHostName());
            siloHost.ConfigFileName  = "OrleansConfiguration.xml";

            siloHost.InitializeOrleansSilo();
            var startedok = siloHost.StartOrleansSilo();

            if (!startedok)
                throw new Exception("Fucked up again");


            //hostWrapper = new OrleansHostWrapper(args);

            //if (!hostWrapper.Run())
            //{
            //    Console.Error.WriteLine("Failed to initialize Orleans silo");
            //}
        }

        static void ShutdownSilo()
        {
            if (siloHost != null)
            {
                siloHost.Dispose();
                GC.SuppressFinalize(siloHost);
                siloHost = null;
            }


            //if (hostWrapper != null)
            //{
            //    hostWrapper.Dispose();
            //    GC.SuppressFinalize(hostWrapper);
            //}
        }

        private static OrleansHostWrapper hostWrapper;
    }
}
