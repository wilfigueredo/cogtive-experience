using App.Domain.Entities;
using App.Domain.Factory;
using App.Infra.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App.Infra.Repository
{
    public class ApontamentoRepository : IApontamentoRepository
    {
        public IList<ApontamentoBase> apontamentos;
        private readonly IApontamentoFactory apontamentoFactory;
        StreamReader csvreader;

        public ApontamentoRepository()
        {
            csvreader = new StreamReader(@"..\..\..\..\..\data\data.csv");
            apontamentoFactory = new ApontamentoFactory();
        }
        
        public IEnumerable<ApontamentoBase> GetAll()
        {
            apontamentos = new List<ApontamentoBase>();
            while (!csvreader.EndOfStream)
            {
                var linha = csvreader.ReadLine();
                var data = linha.Split(';');                
                var apontamento = apontamentoFactory.GetInstanceApontamento(Convert.ToInt32(data[4]), Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), Convert.ToDateTime(data[2]), string.IsNullOrEmpty(data[3]) ? null : (int?)Convert.ToInt32(data[3]), Convert.ToInt32(data[5]));
                apontamentos.Add(apontamento);
            };

            return apontamentos.ToList();
        }
    }
}
