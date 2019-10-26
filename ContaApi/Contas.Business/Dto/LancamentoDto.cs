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
    }
}
