using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contas.Domain.Models;

namespace Contas.Domain.Interfaces
{
    public interface IContaRepository:IRepository<Conta>
    {
        Task<(Conta, bool Erro)> GetContaInclude(int Id);
    }
}
