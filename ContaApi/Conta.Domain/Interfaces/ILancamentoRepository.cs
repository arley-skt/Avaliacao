using Contas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contas.Domain.Interfaces
{
    public interface ILancamentoRepository:IRepository<Lancamento>
    {
    }
}

//insert into TipoConta(descricao) values('Corrente')
//insert into TipoConta(descricao) values('Poupanca')

//insert into TipoLancamento(descricao) values('Debito')
//insert into TipoLancamento(descricao) values('Credito')

//select* from lancamento

//select* from TipoConta conta

//insert into Conta(Nome, Cpf, TipoId) values('Joao Silva','123.456.963-63',1)
//insert into Conta(Nome, Cpf, TipoId) values('jose Silva','564.653.963-69',1)
