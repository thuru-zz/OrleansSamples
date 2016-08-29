using System.Threading.Tasks;
using Orleans;
using GrainInterfaces;
using System;

namespace Grains
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class HelloGrain : Grain, IHelloGrain
    {
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"Hello - {name}");
        }
    }
}
