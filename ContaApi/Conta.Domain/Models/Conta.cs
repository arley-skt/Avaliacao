using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Domain.Models
{
    public class Conta : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public TipoConta Tipo { get; set; }
        //public Lancamento Lancamento {get;set;}
    }
}
