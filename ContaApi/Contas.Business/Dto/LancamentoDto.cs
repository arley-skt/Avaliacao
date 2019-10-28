using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Business.Dto
{
    public class LancamentoDto
    {      

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamentoDto Tipo { get; set; }
        public ContaDto ContaOrigem { get; set; }
        public ContaDto ContaDestino { get; set; }

        public LancamentoDto()
        {
        }
        public LancamentoDto(int Id, decimal Valor, DateTime Data, TipoLancamentoDto Tipo, ContaDto ContaOrigem, ContaDto ContaDestino)
        {
            this.Id = Id;
            this.Valor = Valor;
            this.Data = Data;
            this.Tipo = Tipo;
            this.ContaOrigem = ContaOrigem;
            this.ContaDestino = ContaDestino;

        }

      
    }
}
