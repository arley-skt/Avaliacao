using Contas.Data.Context;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Data.Repositories
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ContasContext context) : base(context)
        {
        }
    }
}
