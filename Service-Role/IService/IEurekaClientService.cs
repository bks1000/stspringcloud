using System.Threading.Tasks;

namespace Service_Role.IService
{
    public interface IEurekaClientService
    {
        Task<string> GetServices(string name);
    }
}
