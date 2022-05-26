using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Service
{
    public interface IFraudService
    {
        Task<InformationFraudDto> GetInformationFraudeAsync(string ip);
    }
}
