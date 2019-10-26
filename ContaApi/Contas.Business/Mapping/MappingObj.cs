using AutoMapper.Configuration;
using Contas.Business.Dto;
using Contas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Business.Mapping
{
    public class MappingObj : MapperConfigurationExpression
    {
        public MappingObj()
        {
            CreateMap<Lancamento, LancamentoDto>()
            .ReverseMap();

            CreateMap<Conta, ContaDto>()
           .ReverseMap();

            CreateMap<TipoLancamento, TipoLancamentoDto>()
           .ReverseMap();

            CreateMap<TipoConta, TipoContaDto>()
           .ReverseMap();

        }
    }
}
