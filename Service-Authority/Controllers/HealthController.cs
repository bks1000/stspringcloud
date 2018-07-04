using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Service_Authority.Controllers
{
    /// <summary>
    /// consul系统健康检查
    /// </summary>
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private static readonly HttpClient _httpClient;

        static HealthController()
        {
            _httpClient = new HttpClient();
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get() => Ok("ok");
    }
}