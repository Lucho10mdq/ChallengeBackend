using Challenge.MELI.Domain.Dtos;
using System.Threading.Tasks;

namespace Challenge.MELI.Domain.Interface.Repository.Query
{
    public interface IStatsQuery
    {
        Task<StatsDto> GetStatsAsync();
    }
}
