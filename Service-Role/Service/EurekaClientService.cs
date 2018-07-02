using Microsoft.Extensions.Logging;
using Service_Role.Core;
using Service_Role.IService;
using Steeltoe.Common.Discovery;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service_Role.Service
{
    public class EurekaClientService : IEurekaClientService
    {
        DiscoveryHttpClientHandler handler;

        private const string GET_SERVICES_URL = "http://service-user/hi?name={0}&token=aaa";
        private ILogger _logger;

        public EurekaClientService(IDiscoveryClient client, ILoggerFactory logFactory = null)
        {
            handler = new DiscoveryHttpClientHandler(client, logFactory?.CreateLogger(typeof(EurekaClientService)));
            _logger = logFactory?.CreateLogger(typeof(EurekaClientService));
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient(handler, false);
            return client;
        }

        public async Task<string> GetServices(string name)
        {
            _logger?.LogInformation("GetServices");
            var client = GetClient();
            return await client.GetStringAsync(string.Format(GET_SERVICES_URL,name));
        }

        public async Task<string> GetServicesWithHystrix(string name)
        {
            _logger?.LogInformation("GetServicesWithHystrix");
            var client = GetClient();
            var result = await client.GetStringAsync(string.Format(GET_SERVICES_URL,name));
            _logger?.LogInformation("GetServicesWithHystrix returning: " + result);
            return result;
        }
    }
}
