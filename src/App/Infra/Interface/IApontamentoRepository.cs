using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Interface
{
    public interface IApontamentoRepository
    {
        public IEnumerable<ApontamentoBase> GetAll();
    }
}
