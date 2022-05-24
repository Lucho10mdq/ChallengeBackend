using Challenge.MELI.Application.UseCase.Fraude.Get;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeMELI.UseCase.Fraud.V1
{
    public partial class FraudController
    {
        [HttpGet]
        [Route("{ip}")]
        [ProducesResponseType(typeof(GetFraudResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInformation(string ip)
        {
           var response = await _mediator.Send(new GetIPQuery(ip));

            return Ok(response);
        }
    }
}
