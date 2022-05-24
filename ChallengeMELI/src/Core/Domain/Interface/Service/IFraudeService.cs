using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Service
{
    public interface IFraudeService
    {
        Task<InformationFraudDto> GetInformationFraudeAsync(string ip);
    }
}
