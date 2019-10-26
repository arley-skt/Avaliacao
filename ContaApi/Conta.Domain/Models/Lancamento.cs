using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Domain.Models
{
    public class Lancamento : BaseModel
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamento Tipo {get;set;}
        public Conta ContaOrigem { get; set; }
        public Conta ContaDestino { get; set; }
    }
}
