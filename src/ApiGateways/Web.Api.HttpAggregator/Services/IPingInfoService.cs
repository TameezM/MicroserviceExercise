using System.Threading.Tasks;

namespace Web.Api.HttpAggregator.Services
{
    public interface IPingInfoService
    {
        public Task<string> GetPingInfo(string address);
    }
}
