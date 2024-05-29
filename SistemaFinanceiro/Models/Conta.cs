using SistemaFinanceiro.Exceptions;

namespace SistemaFinanceiro.Models
{
    public class Conta
    {
        private const decimal TaxaSaque = 0.10m;

        public Conta(long numero, decimal saldo, Cliente cliente, Agencia agencia)
        {
            if (saldo <= 10)
            {
                throw new ArgumentException("O saldo inicial deve ser superior a R$10,00");
            }

            Cliente = cliente ?? throw new ArgumentException("O cliente não foi fornecido.");
            Agencia = agencia ?? throw new ArgumentException("A agência não foi fornecida.");
            Numero = numero;
            Saldo = saldo;
        }

        public long Numero { get; private set; }

        public decimal Saldo { get; private set; }

        public Cliente Cliente { get; private set; }

        public Agencia Agencia { get; set; }

        public void Depositar(decimal valor)
        {
            VerificarValorMaiorQueZero(valor, "O valor do depósito deve ser superior a R$0,00");

            Saldo += valor;
        }

        public decimal Sacar(decimal valor)
        {
            VerificarValorMaiorQueZero(valor, "O valor do saque deve ser superior a R$0,00");

            var saldoFinal = Saldo - valor - TaxaSaque;
            if (saldoFinal < 0) throw new OperacaoInvalidaException("Valor do saque ultrapassa o saldo.");
            Saldo = saldoFinal;
            return Saldo;
        }

        public void Transferir(decimal valor, Conta contaAlvo)
        {
            VerificarValorMaiorQueZero(valor, "O valor da transferência deve ser superior a R$0,00");
            VerificarContasIguais(this, contaAlvo);

            if (Saldo - valor >= 0)
            {
                Saldo -= valor;
                contaAlvo.Depositar(valor);
            }
            else
            {
                throw new OperacaoInvalidaException("O Valor da transferência ultrapassa o saldo da conta.");
            }
        }

        private static void VerificarValorMaiorQueZero(decimal valor, string mensagem)
        {
            if (valor <= 0) throw new OperacaoInvalidaException(mensagem);
        }
        
        private static void VerificarContasIguais(Conta contaOrigem, Conta contaAlvo)
        {
            if (contaOrigem == contaAlvo) throw new OperacaoInvalidaException("Não é possível transferir para a mesma conta.");
        }
    }
}