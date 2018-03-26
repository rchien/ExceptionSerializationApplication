using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Stateless1
{
    public interface IStatelessInSvc : IService
    {
        Task HelloExceptionFromSvc();
    }
}