using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
	public interface IHelloGrain : IGrainWithGuidKey
    {
        Task<string> SayHello(string name);
    }
}
