using Challenge.MELI.Application.Exceptions;
using Challenge.MELI.Domain.Dtos;
using Challenge.MELI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeMELI.UseCase.Stast.V1
{
    public partial class StatsController
    {
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(StatsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStats()
        {
            var response = await _statsService.GetStatsAsync();

            if(response is null) 
            {
                throw new GenericException(MessageGeneral.NotFound, MessageGeneral.Stats);
            }

            return Ok(response);
        }
    }
}
