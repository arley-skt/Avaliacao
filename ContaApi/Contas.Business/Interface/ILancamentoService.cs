using Contas.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Business.Interface
{
    public interface ILancamentoService
    {
        void RealizaLancamento();

        Task<bool> GeraLancamento(List<LancamentoDto> Lista);
    }
}
