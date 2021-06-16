using App.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Interface
{
    public interface IApontamentoService
    {
        public GapDTO GetGaps();
        ApontamentoProducaoDTO GetQuantidadesProduzidas();
        TimeSpan GetHorasManutencao();
    }
}
