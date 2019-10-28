using Contas.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Business.Interface
{
    public interface IMensagemService
    {
        void Enviar(string Msg);
        List<LancamentoDto> ConsumirMensagem();

    }
}
