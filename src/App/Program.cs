using App.Domain.Interface;
using App.Domain.Service;
using App.Infra.Interface;
using App.Infra.Repository;
using System;
using System.IO;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            IApontamentoService apontamentoService = new ApontamentoService();
            var gaps = apontamentoService.GetGaps();

            Console.WriteLine($"GAPS");
            Console.WriteLine($"\r\nQuantidade de GAPS: {gaps.Quantidade} \r\nPeriodoTotal: {Convert.ToInt32(gaps.PeriodoTotal.TotalHours)}:{gaps.PeriodoTotal.Minutes}:{gaps.PeriodoTotal.Seconds}");
            Console.WriteLine($"\r\n ------------------------------------------------------------------------------------------------------------------");

            var apontamentodProducao = apontamentoService.GetQuantidadesProduzidas();

            Console.WriteLine($"Apontamentos produção");
            Console.WriteLine($"\r\nQuantidade Produzida: {apontamentodProducao.QuantidadeTotal} \r\n1º Lote: {apontamentodProducao.ApontamentoProducoes[0].NumeroLote} produziu {apontamentodProducao.ApontamentoProducoes[0].Quantidade}");
            Console.WriteLine($"2º Lote: {apontamentodProducao.ApontamentoProducoes[1].NumeroLote} produziu {apontamentodProducao.ApontamentoProducoes[1].Quantidade}");
            Console.WriteLine($"3º Lote: {apontamentodProducao.ApontamentoProducoes[2].NumeroLote} produziu {apontamentodProducao.ApontamentoProducoes[2].Quantidade}");
            Console.WriteLine($"\r\n ------------------------------------------------------------------------------------------------------------------");

            var apontamentodHorasManutencao = apontamentoService.GetHorasManutencao();

            Console.WriteLine($"Apontamentos horas manutenção");
            Console.WriteLine($"\r\nPeríodo Total De Manutenção: {Convert.ToInt32(apontamentodHorasManutencao.TotalHours)}:{apontamentodHorasManutencao.Minutes}:{apontamentodHorasManutencao.Seconds}");
            Console.WriteLine($"\r\n ------------------------------------------------------------------------------------------------------------------");

            Console.ReadLine();
        }
    }
}
