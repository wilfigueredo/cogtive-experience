using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Factory
{
    public class ApontamentoFactory : IApontamentoFactory
    {
        public ApontamentoBase GetInstanceApontamento(int idEvento, int idApontamento, DateTime dataInicio, DateTime dataFim, int? numeroLote, int quantidade)
        {
            if (idEvento == 1 || idEvento == 2)
                return new ApontamentoProducao(idApontamento, dataInicio, dataFim, idEvento, numeroLote.Value, quantidade);
            if (idEvento == 19)
                return new ApontamentoManutencao(idApontamento, dataInicio, dataFim, idEvento);
            return new ApontamentoBase(idApontamento, dataInicio, dataFim, idEvento);
        }
    }
}
