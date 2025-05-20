using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.LeituraUseCases.BuscarTotalLeituraMesId
{
    public class BuscarTotalLeituraMesIdRequest(string token) : IRequest<BuscarTotalLeituraMesIdResponse>
    {
        public string Token { get; set; } = token;
    }
}