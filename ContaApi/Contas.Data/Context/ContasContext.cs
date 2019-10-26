using Contas.Domain.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Data.Context
{
    public class ContasContext : DbContext
    {
        public ContasContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conta>().HasKey(t => t.Id);
            //modelBuilder.Entity<Conta>().HasOne(t => t.Lancamento);
            modelBuilder.Entity<Conta>().HasOne(t => t.Tipo);
            

            modelBuilder.Entity<Lancamento>().HasKey(t => t.Id);
            modelBuilder.Entity<Lancamento>().HasOne(t => t.Tipo);
            modelBuilder.Entity<Lancamento>().HasOne(t => t.ContaOrigem);

            modelBuilder.Entity<TipoConta>().HasKey(t => t.Id);

            modelBuilder.Entity<TipoLancamento>().HasKey(t => t.Id);

           

        }
    }
}
