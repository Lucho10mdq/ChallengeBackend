using Challenge.MELI.Helpers;
using MediatR;

namespace Challenge.MELI.Application.UseCase.Fraude.Get
{
    public class GetIPQuery : IRequest<Response<GetFraudResponse>>
    {
        public string Ip { get; set; }

        public GetIPQuery(string ip) 
        {
            Ip = ip;
        }
    }
}
