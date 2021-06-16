using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Factory
{
    public interface IApontamentoFactory
    {
        public ApontamentoBase GetInstanceApontamento(int idEvento, int idApontamento, DateTime dataInicio, DateTime dataFim, int? numeroLote, int quantidade);
    }
}
