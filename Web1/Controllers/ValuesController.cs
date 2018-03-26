using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;

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

        [HttpGet("exceptions")]
        public async Task<IActionResult> GetExceptions()
        {
            var factory = new ServiceProxyFactory();
            var proxy = factory.CreateServiceProxy<IStateless1>(new Uri("fabric:/ExceptionSerializationApplication/Stateless1"));

            try
            {
                await proxy.HelloExceptions();
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
