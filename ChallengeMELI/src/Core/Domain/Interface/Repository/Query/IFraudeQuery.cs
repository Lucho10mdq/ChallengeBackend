using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Repository.Query
{
    public interface  IFraudeQuery
    {
        Task<InformationFraudDto> GetInformationFraudeAsync(string ip);
    }
}
