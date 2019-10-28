using Contas.Data.Context;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Data.Repositories
{
    public class BaseRepository<T>:IRepository<T> where T:BaseModel
    {
        protected readonly ContasContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ContasContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();

        }

        public void Save(T entity) => dbSet.Add(entity);//.Context.SaveChanges();

        public void SaveMany(IEnumerable<T> entity) => dbSet.AddRange(entity);
        public async Task<T> GetById(int id) => await dbSet.FindAsync(id);
    }
}
