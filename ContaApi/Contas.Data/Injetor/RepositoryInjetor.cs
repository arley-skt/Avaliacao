using Contas.Data.Repositories;
using Contas.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Data.Injetor
{
    public static class RepositoryInjetor
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ITipoContaRepository, TipoContaRepository>();
            services.AddScoped<ITipoLancamentoRepository, TipoLancamentoRepository>();

        }
    }
}
