using Challenge.MELI.Domain.Dtos;
using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Service
{
    public interface IStatsService
    {
        Task AddStatsAsync(InformationFraudDto informationFraudDto);
        Task UpdateStatsAsync(StatsDto statsDto, InformationFraudDto informationFraudDto);
        Task<StatsDto> GetStatsAsync();
    }
}
