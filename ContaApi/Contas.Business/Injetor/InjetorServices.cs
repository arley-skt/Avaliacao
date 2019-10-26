using Contas.Business.Interface;
using Contas.Business.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Business.Injetor
{
    public class InjetorServices
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<ILancamentoService, LancamentoService>();           

        }
    }
}
