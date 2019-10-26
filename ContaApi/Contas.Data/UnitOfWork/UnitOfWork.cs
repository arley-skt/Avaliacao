using Contas.Data.Context;
using Contas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ContasContext context;

        public UnitOfWork(ContasContext context)
        {
            this.context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
