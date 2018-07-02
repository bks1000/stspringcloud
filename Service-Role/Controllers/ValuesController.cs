using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service_Role.IService;
using Steeltoe.Common.Discovery;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service_Role.Controllers
{
    /// <summary>
    /// 本类用于测试：1,将服务注册到Eureka；2，调用service-user服务
    /// </summary>
    //参考：https://www.colabug.com/2973462.html
    //使用：https://www.nuget.org/packages/Pivotal.Discovery.ClientCore/2.0.1  来和eureka交互
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly DiscoveryHttpClientHandler _handler;

        private IEurekaClientService _eurekaClientService;//此类构造中，包含了 DiscoverHttpClientHandler

        private const string ProductUrl = "http://service-user/hi?name={0}&token=aaa";

        public ValuesController(IDiscoveryClient client, ILoggerFactory logFactory, IEurekaClientService eurekaClientService)
        {
            _handler = new DiscoveryHttpClientHandler(client);
            _eurekaClientService = eurekaClientService;
        }

        // GET api/values
        [HttpGet]
        public async Task<OkObjectResult> Get()
        {
            //var client = new HttpClient(_handler, false);
            //return Ok(await client.GetStringAsync(string.Format(ProductUrl,111)));
            return Ok(await _eurekaClientService.GetServices("aaa"));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<OkObjectResult> Get(string id)
        {
            var client = new HttpClient(_handler, false);
            return Ok(await client.GetStringAsync(string.Format(ProductUrl, id)));
            //return Ok( await _eurekaClientService.GetServices(id));
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
