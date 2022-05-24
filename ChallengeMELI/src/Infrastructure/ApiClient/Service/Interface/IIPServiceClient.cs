using Challenge.MELI.ApiClient.Response;
using Refit;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service.Interface
{
    public interface IIPServiceClient
    {
        [Get("/{ip}")]
        Task<ApiResponse<IpResponse>> GetIpCountryByIpAsync(string ip, [Query] string access_key, [Query] string format);
    }
}
