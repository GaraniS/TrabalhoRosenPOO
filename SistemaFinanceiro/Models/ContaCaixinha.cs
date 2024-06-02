using SistemaFinanceiro.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Models;

public class ContaCaixinha(long numero, decimal saldo, Cliente cliente, Agencia agencia)
    : Conta(numero, saldo, cliente, agencia)
{
    public override void Depositar(decimal valor)
    {
        if (valor < 1)
        {
            throw new OperacaoInvalidaException("Conta Caixinha não aceita depósitos inferiores a R$1,00");
        }

        base.Depositar(valor + 1);
    }

    public override decimal Sacar(decimal valor)
    {
        VerificarValorMaiorQueZero(valor, "O valor do saque deve ser superior a R$0,00");
        if (Saldo < valor + 5) throw new OperacaoInvalidaException("Saldo insuficiente para saque.");
        Saldo -= (valor + 5);
        return Saldo;
    }
}
