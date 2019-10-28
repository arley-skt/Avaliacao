using AutoMapper;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Contas.Data.Context;
using Microsoft.EntityFrameworkCore;
using Contas.Business.Mapping;
using Contas.Data.Injetor;
using Contas.Business.Injetor;
using System.Threading.Tasks;
using Contas.Business.Interface;
using System.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Contas.ProcessarLancamento
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            
        }

        public static async Task MainAsync(string[] args)
        {
            Init startup = new Init();
            startup.Load();            

            var processarLancamento = startup.ServiceProvider.GetService<ILancamentoService>();

            var ConsomeMsg = startup.ServiceProvider.GetService<IMensagemService>();

            try
            {

                //await              


                Console.WriteLine("Processando Fila");
                var lista = ConsomeMsg.ConsumirMensagem();
                if (lista!= null)
                {
                    Console.WriteLine("Gravando Dados Fila");

                    await processarLancamento.GeraLancamento(lista);
                }
                else
                {
                    Console.WriteLine("Fila Vazia");
                }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro No Processo");
            }
        }
    }

    public class Init
    {
        public IConfiguration Configuration { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public void Load()
        {
            var builder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        

        private void ConfigureServices(IServiceCollection services)
        {
            // Context
            services.AddDbContext<ContasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // AutoMapper
            services.AddAutoMapper(typeof(MappingObj));


            // Serviços e Repositórios
            RepositoryInjetor.Add(services);
            InjetorServices.Add(services);

        }
    }
}

