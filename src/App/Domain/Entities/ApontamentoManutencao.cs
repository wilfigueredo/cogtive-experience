using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class ApontamentoManutencao : ApontamentoBase
    {
        public ApontamentoManutencao(int idApontamento, DateTime dataInicio, DateTime dataFim, int idEvento) : base(idApontamento, dataInicio, dataFim, idEvento) { }
    }
}
