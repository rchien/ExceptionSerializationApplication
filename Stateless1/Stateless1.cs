using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Stateless1
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class Stateless1 : StatelessService, IStatelessInCommon, IStatelessInSvc
    {
        public Stateless1(StatelessServiceContext context)
            : base(context)
        { }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }

        public Task HelloException()
        {
            var rand = new Random();
            switch (rand.Next() % 3)
            {
                case 0:
                    throw new ArgumentNullException();
                    break;
                case 1:
                    throw new NullReferenceException();
                    break;
                case 2:
                    throw new Exception();
                    break;
            }

            return Task.CompletedTask;
        }

        public async Task HelloExceptionFromCommon()
        {
            await HelloException();
        }

        public async Task HelloExceptionFromSvc()
        {
            await HelloException();
        }
    }

   
}
