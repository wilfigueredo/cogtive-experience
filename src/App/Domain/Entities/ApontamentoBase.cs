using App.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class ApontamentoBase
    {
        public ApontamentoBase(int idApontamento, DateTime dataInicio, DateTime dataFim, int idEvento)
        {
            IdApontamento = idApontamento;
            DataInicio = dataInicio;
            DataFim = dataFim;            
            IdEvento = idEvento;
        }
        public int IdApontamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }        
        public int IdEvento { get; set; }       
    }
}
