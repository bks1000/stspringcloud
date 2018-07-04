using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Mvc;

namespace Service_Authority.Controllers
{
    /// <summary>
    /// consul系统健康检查
    /// </summary>
    [Route("[controller]")]
    public class DefaultController : Controller
    {
        private static readonly HttpClient _httpClient;

        static DefaultController()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 获取所有consul中的服务
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public String Get()
        {
            StringBuilder builder = new StringBuilder();
            using (var consulClient = new ConsulClient(c => c.Address = new Uri($"http://{Program.IP}:8500")))
            {
                var services = consulClient.Agent.Services().Result.Response;
                foreach (var service in services.Values)
                {
                    builder.Append($"id={service.ID},name={service.Service},ip={service.Address},port={service.Port}");
                    builder.Append("</br>");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// 调用java服务
        /// </summary>
        /// <returns></returns>
        [Route("call")]
        [HttpGet]
        public String CallService()
        {
            //return _httpClient.GetStringAsync($"http://{Program.IP}:8502/hi").Result;//调用JAVA registry-consul服务
            //return _httpClient.GetStringAsync($"http://registry-consul/hi").Result; //错误


            var consulClient = new ConsulClient(c => c.Address = new Uri($"http://{Program.IP}:8500"));
            var services = consulClient.Agent.Services().Result.Response.Values.Where(a => a.Service.Equals("registry-consul"));//找到服务名称为registry-consul的服务

            //通过随机数获取一个随机索引 去除索引为生成的随机数的服务
            Random r = new Random();
            int index = r.Next(services.Count());
            var service = services.ElementAt(index);
            //var service = services.ElementAt(0);

            //服务
            using (var httpContent = new StringContent("{phoneNum:'119',msg:'help'}", Encoding.UTF8, "application/json"))
            {
                //_httpClient.PostAsync($"http://{service.Address}:{service.Port}/hi",httpContent);
                return _httpClient.GetStringAsync($"http://{service.Address}:{service.Port}/hi").Result;
            }
        }
    }
}