using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DTO
{
    public class ApontamentoProducaoDTO
    {
        public ApontamentoProducaoDTO()
        {
            ApontamentoProducoes = new List<ApontamentoProducao>();
        }
        public List<ApontamentoProducao> ApontamentoProducoes { get; set; }
        public int QuantidadeTotal { get; set; }
    }
}
