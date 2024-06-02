using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiroTest
{
    [TestClass]
    public class ContaCaixinhaTest
    {
        private readonly Agencia _agencia = new(123, "Agencia Teste", "123456789", "12345678");
        private readonly Cliente _cliente = new("Cliente Teste", "12345678901", 2003);

        [TestMethod]
        public void DeveDepositar()
        {
            ContaCaixinha contaCaixinha = new(1000, 1003, _cliente, _agencia);

            contaCaixinha.Depositar(2);

            Assert.AreEqual(1006, contaCaixinha.Saldo);
        }

        [TestMethod]
        public void NaoDeveDepositar()
        {
            ContaCaixinha contaCaixinha = new(1000, 1003, _cliente, _agencia);

            Assert.ThrowsException<OperacaoInvalidaException>(() => contaCaixinha.Depositar(0.5m));
        }

        [TestMethod]
        public void DeveSacar()
        {
            ContaCaixinha contaCaixinha = new(1000, 1003, _cliente, _agencia);

            var saldo = contaCaixinha.Sacar(3);

            Assert.AreEqual(995, contaCaixinha.Saldo);
        }

        [TestMethod]
        public void NaoDeveSacarValorNegativo()
        {
            ContaCaixinha contaCaixinha = new(1000, 1003, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => contaCaixinha.Sacar(-5));
            Assert.AreEqual("O valor do saque deve ser superior a R$0,00", ex.Message);
        }

        [TestMethod]
        public void NaoDeveSacarValorMaiorQueSaldo()
        {
            ContaCaixinha contaCaixinha = new(1000, 1003, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => contaCaixinha.Sacar(1000));
            Assert.AreEqual("Saldo insuficiente para saque.", ex.Message);
        }
    }
}

