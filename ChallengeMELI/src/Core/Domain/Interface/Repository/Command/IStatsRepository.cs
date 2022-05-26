using Challenge.MELI.Domain.Dtos;
using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Repository.Command
{
    public interface IStatsRepository
    {
        Task AddStatsAsync(StatsDto statsDto);
        Task UpdateStatsAsync(StatsDto statsDto);
    }
}
