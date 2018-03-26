using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Stateless1;

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("exception/common")]
        public async Task<IActionResult> GetExceptionFromCommon()
        {
            var factory = new ServiceProxyFactory();
            var proxy = factory.CreateServiceProxy<IStatelessInCommon>(new Uri("fabric:/ExceptionSerializationApplication/Stateless1"));

            try
            {
                await proxy.HelloExceptionFromCommon();
            }
            catch (AggregateException aex)
            {
                Console.WriteLine(aex.Message);
            }

            return Ok();
        }

        [HttpGet("exception/svc")]
        public async Task<IActionResult> GetExceptionFromSvc()
        {
            var factory = new ServiceProxyFactory();
            var proxy = factory.CreateServiceProxy<IStatelessInSvc>(new Uri("fabric:/ExceptionSerializationApplication/Stateless1"));

            try
            {
                await proxy.HelloExceptionFromSvc();
            }
            catch (AggregateException aex)
            {
                Console.WriteLine(aex.Message);
            }

            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
