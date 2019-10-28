using AutoMapper;
using Contas.Business.Dto;
using Contas.Business.Interface;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Business.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly IMapper mapper;
        private readonly IContaRepository contaRepository;
        private readonly ILancamentoRepository lancamentoRepository;
        private readonly ITipoContaRepository tipoContaRepository;
        private readonly ITipoLancamentoRepository tipoLancamentoRepository;
        private readonly IUnitOfWork unitOfWork;
        public LancamentoService(IMapper mapper, IContaRepository contaRepository, ILancamentoRepository lancamentoRepository,
            ITipoContaRepository tipoContaRepository, ITipoLancamentoRepository tipoLancamentoRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.contaRepository = contaRepository;
            this.tipoContaRepository = tipoContaRepository;
            this.tipoLancamentoRepository = tipoLancamentoRepository;
            this.lancamentoRepository = lancamentoRepository;
            this.unitOfWork = unitOfWork;
        }      

        public async Task<bool> GeraLancamento(List<LancamentoDto> Lista)
        {
            try
            {
                if (Lista.Any())
                {
                    var lista = mapper.Map(Lista, new List<Lancamento>());

                    foreach (var c in lista)
                    {
                        c.ContaOrigem = await contaRepository.GetById(c.ContaOrigem.Id);
                        c.ContaDestino = await contaRepository.GetById(c.ContaDestino.Id);
                        c.Tipo = await tipoLancamentoRepository.GetById(c.Tipo.Id);
                    }

                    lancamentoRepository.SaveMany(lista);

                    await unitOfWork.CommitAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public void RealizaLancamento()
        {
            var Lista = new List<LancamentoDto>();
            var dados1 = new LancamentoDto(0, 10, DateTime.Now, new TipoLancamentoDto(), new ContaDto(), new ContaDto());
            var dados2 = new LancamentoDto(0, 10, DateTime.Now, new TipoLancamentoDto(), new ContaDto(), new ContaDto());
            Lista.Add(dados1); Lista.Add(dados2);

            var Json = JsonConvert.SerializeObject(Lista);
        }
    }
}
