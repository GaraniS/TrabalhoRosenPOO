using SistemaFinanceiro.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Models;

public class ContaEspecial : Conta
{
    public ContaEspecial(long numero, decimal saldo, decimal limite, Cliente cliente, Agencia agencia)
        : base(numero, saldo, cliente, agencia)
    {
        if (limite <= 0)
        {
            throw new ArgumentException("O limite deve ser superior a R$0,00");
        }

        Limite = limite;
    }

    public decimal Limite { get; private set; }

    public override decimal Sacar(decimal valor)
    {
        VerificarValorMaiorQueZero(valor, "O valor do saque deve ser superior a R$0,00");
        if (valor > Saldo + Limite) throw new OperacaoInvalidaException("Valor do saque ultrapassa o limite da conta.");
        Saldo -= valor;
        return Saldo;
    }

    public override void Transferir(decimal valor, Conta contaAlvo)
    {
        VerificarValorMaiorQueZero(valor, "O valor da transferência deve ser superior a R$0,00");
        VerificarContasIguais(this, contaAlvo);

        Sacar(valor);
        contaAlvo.Depositar(valor);
    }
}