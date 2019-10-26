using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Business.Dto
{
    public class ContaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public TipoContaDto Tipo { get; set; }
    }
}
