using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void SaveMany(IEnumerable<T> entity);
        Task<T> GetById(int id);
    }
}
