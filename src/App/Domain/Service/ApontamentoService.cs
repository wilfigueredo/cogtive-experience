using App.Domain.Entities;
using App.Domain.Interface;
using App.DTO;
using App.Infra.Interface;
using App.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Service
{
    public class ApontamentoService : IApontamentoService
    {
        private readonly IApontamentoRepository _apontamentoRepository;
        List<ApontamentoBase> Apontamentos;

        public ApontamentoService()
        {
            _apontamentoRepository = new ApontamentoRepository();
            Apontamentos = new List<ApontamentoBase>(_apontamentoRepository.GetAll());
        }

        public TimeSpan GetHorasManutencao()
        {
            TimeSpan HorasManutencao = new TimeSpan();

            foreach (var item in Apontamentos)
            {
                if (item is ApontamentoManutencao)
                    HorasManutencao = HorasManutencao.Add(item.DataFim.Subtract(item.DataInicio));
            }

            return HorasManutencao;
        }

        public ApontamentoProducaoDTO GetQuantidadesProduzidas()
        {
            var apontamentosProducao = new ApontamentoProducaoDTO();
            var apontamentoProducoes = new List<ApontamentoProducao>();
            foreach (var item in Apontamentos)
            {
                if (item is ApontamentoProducao)
                {
                    apontamentosProducao.QuantidadeTotal = apontamentosProducao.QuantidadeTotal + ((ApontamentoProducao)item).Quantidade;
                    apontamentoProducoes.Add(((ApontamentoProducao)item));
                }
            }
            var apontamentos = apontamentoProducoes.GroupBy(p => p.NumeroLote)
                               .Select(q => new ApontamentoProducao(q.First().IdApontamento, q.First().DataInicio, q.First().DataFim, q.First().IdEvento, q.First().NumeroLote.Value, q.Sum(c => c.Quantidade))).OrderByDescending(x => x.Quantidade);

            apontamentosProducao.ApontamentoProducoes.Add(apontamentos.ElementAt(0));
            apontamentosProducao.ApontamentoProducoes.Add(apontamentos.ElementAt(1));
            apontamentosProducao.ApontamentoProducoes.Add(apontamentos.ElementAt(2));

            return apontamentosProducao;

        }

        public GapDTO GetGaps()
        {
            GapDTO gap = new GapDTO();
            for (int i = 0; i < Apontamentos.Count; i++)
            {
                DateTime dataInicio = Apontamentos[i].DataFim;
                DateTime dataFim;
                if (Apontamentos.Count > i + 1)
                {
                    dataFim = Apontamentos[i + 1].DataInicio;

                    if (HasGap(dataInicio, dataFim))
                    {
                        gap.Quantidade = gap.Quantidade + 1;
                        gap.PeriodoTotal = gap.PeriodoTotal.Add(dataFim.Subtract(dataInicio));
                    }
                }
            }
            return gap;
        }

        private bool HasGap(DateTime dataInicio, DateTime dataFim)
        {
            return dataFim > dataInicio;
        }
    }
}
