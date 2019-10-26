using Contas.Data.Context;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Data.Repositories
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(ContasContext context) : base(context)
        {
        }

        public async Task<(Conta, bool Erro)> GetContaInclude(int Id)
        {
            try
            {
                return (await dbSet.Include(x=>x.Tipo).Where(x => x.Id == Id).FirstOrDefaultAsync(),true);

            }
            catch (Exception e)
            {
                return (new Conta(), false);
            }
        }
    }
}
