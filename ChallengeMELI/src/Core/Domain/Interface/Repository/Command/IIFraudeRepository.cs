using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Repository.Command
{
    public interface IIFraudeRepository
    {
        Task AddFraudeAsync(InformationFraudDto informationFraudDto);
    }
}
