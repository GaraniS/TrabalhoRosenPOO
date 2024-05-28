using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;

        private Agencia _agencia;
        private Cliente _cliente;

        public Conta(long numero, decimal saldo, Cliente cliente, Agencia agencia)
        {
            if (saldo <= 10)
            {
                throw new ArgumentException("O saldo inicial deve ser superior a R$10,00");
            }
            if (cliente == null)
            {
                throw new ArgumentNullException("O cliente não foi fornecido.");
            }

            _numero = numero;
            _saldo = saldo;
            _cliente = cliente;
        }

        public long Numero
        {
            get => _numero;
            private set
            {
                _numero = value;
            }
        }

        public decimal Saldo { get => _saldo; }

        // crie o código de teste para testar o método de depósito e saque da conta

        public void Depositar(decimal valor)
        {
            _saldo += valor;
        }

        public decimal Sacar(decimal valor)
        {
            if (_saldo - valor - 0.10m >= 0)
            {
                _saldo -= valor - 0.10m;
                return _saldo;
            }
            else
            {
                throw new ArgumentException("Valor do saque ultrapassa o saldo.");
            }
        }

        public void Transferir(decimal valor, Conta contaAlvo)
        {
            if (Saldo - valor >= 0) 
            {
                _saldo -= valor;
                contaAlvo.Depositar(valor);
            }
            else
            {
                throw new ArgumentException("O Valor da transferência ultrapassa o saldo da conta.");
            }
        } 

    }
}
