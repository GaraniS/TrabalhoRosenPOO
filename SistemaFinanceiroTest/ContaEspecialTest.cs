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
    public class ContaEspecialTest
    {
        private readonly Agencia _agencia = new(123, "Agencia Teste", "123456789", "12345678");
        private readonly Cliente _cliente = new("Cliente Teste", "12345678901", 2003);

        [TestMethod]
        public void NaoDeveCriarContaEspecial()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new ContaEspecial(1000, 20, -10, _cliente, _agencia));

            Assert.AreEqual("O limite deve ser superior a R$0,00", ex.Message);
        }

        [TestMethod]
        public void DeveSacar()
        {
            var contaEspecial = new ContaEspecial(1000, 20, 150, _cliente, _agencia);

            var saldo = contaEspecial.Sacar(40);

            Assert.AreEqual(-20, saldo);

        }

        [TestMethod]
        public void NaoDeveSacarValorNegativo()
        {
            var contaEspecial = new ContaEspecial(1000, 20, 150, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => contaEspecial.Sacar(-40));

            Assert.AreEqual("O valor do saque deve ser superior a R$0,00", ex.Message);
        }

        [TestMethod]
        public void NaoDeveSacarValorMaiorQueLimite()
        {
            var contaEspecial = new ContaEspecial(1000, 20, 150, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => contaEspecial.Sacar(180));

            Assert.AreEqual("Valor do saque ultrapassa o limite da conta.", ex.Message);
        }

        [TestMethod]
        public void DeveTransferir()
        {
            var contaEspecial = new ContaEspecial(1000, 20, 150, _cliente, _agencia);
            var conta = new Conta(1000, 20, _cliente, _agencia);

            contaEspecial.Transferir(40, conta);

            Assert.AreEqual(-20, contaEspecial.Saldo);
            Assert.AreEqual(60, conta.Saldo); 
        }
    }
}
