using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Application.UseCases.LeituraUseCases.BuscarTotalLeituraMesId
{
    public class BuscarTotalLeituraMesIdResponse
    {
        public int TotalLeitura { get; set; }
        
        public BuscarTotalLeituraMesIdResponse(int totalLeitura)
        {
            TotalLeitura = totalLeitura;
        }
    }
}