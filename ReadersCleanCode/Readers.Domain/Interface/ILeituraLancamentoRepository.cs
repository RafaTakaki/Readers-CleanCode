using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readers.Models;

namespace Readers.Domain.Interface
{
    public interface ILeituraLancamentoRepository
    {
        Task<bool> LancarLeituraTempo(LeituraLancamento leituraLancamento);

    }
}