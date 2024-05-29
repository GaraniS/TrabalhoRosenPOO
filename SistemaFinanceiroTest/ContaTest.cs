using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Models;

namespace SistemaFinanceiroTest
{
    [TestClass]
    public class ContaTest
    {
        private readonly Agencia _agencia = new(123, "Agencia Teste", "123456789", "12345678");
        private readonly Cliente _cliente = new("Cliente Teste", "12345678901", 2003);
        
        [TestMethod]
        public void NaoDeveConstruirContaComSaldoInsuficiente()
        {
            const decimal saldoInicialInvalido = 10;

            Assert.ThrowsException<ArgumentException>(() => new Conta(123, saldoInicialInvalido, null, null),
                "O saldo inicial deve ser superior a R$10,00");
        }
        
        [TestMethod]
        public void NaoDeveConstruirContaComClienteNulo()
        {
            Assert.ThrowsException<ArgumentException>(() => new Conta(123, 11, null, null),
                "O cliente não foi fornecido.");
        }
        
        [TestMethod]
        public void NaoDeveConstruirContaComAgenciaNula()
        {
            Assert.ThrowsException<ArgumentException>(() => new Conta(123, 11, _cliente, null),
                "A agência não foi fornecida.");
        }

        [TestMethod]
        public void DeveDepositar()
        {
            const decimal saldoInicial = 1000;
            const decimal valorDeposito = 1000;
            const decimal saldoFinal = 2000;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);

            conta1.Depositar(valorDeposito);

            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }
        
        [TestMethod]
        public void NaoDeveDepositarValorNegativo()
        {
            const decimal saldoInicial = 1000;
            const decimal valorDeposito = -1000;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Depositar(valorDeposito));
            
            Assert.AreEqual("O valor do depósito deve ser superior a R$0,00", ex.Message);
        }

        [TestMethod]
        public void DeveSacar()
        {
            const decimal saldoInicial = 1000;
            const decimal valorSaque = 500;
            const decimal saldoFinal = 499.9m;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);

            conta1.Sacar(valorSaque);

            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }
        
        [TestMethod]
        public void NaoDeveSacarValorNegativo()
        {
            const decimal saldoInicial = 1000;
            const decimal valorSaque = -500;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Sacar(valorSaque));
            
            Assert.AreEqual("O valor do saque deve ser superior a R$0,00", ex.Message);
        }

        [TestMethod]
        public void NaoDeveSacarValorMaiorQueSaldo()
        {
            const decimal saldoInicial = 1000;
            const decimal valorSaque = 1500;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Sacar(valorSaque));
            
            Assert.AreEqual("Valor do saque ultrapassa o saldo.", ex.Message);
        }
        
        [TestMethod]
        public void DeveTransferir()
        {
            const decimal saldoInicial = 1000;
            const decimal valorTransferencia = 500;
            const decimal saldoFinalConta1 = 500;
            const decimal saldoFinalConta2 = 1500;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);
            var conta2 = new Conta(321, saldoInicial, _cliente, _agencia);

            conta1.Transferir(valorTransferencia, conta2);

            Assert.AreEqual(saldoFinalConta1, conta1.Saldo);
            Assert.AreEqual(saldoFinalConta2, conta2.Saldo);
        }
        
        [TestMethod]
        public void NaoDeveTransferirValorNegativo()
        {
            const decimal saldoInicial = 1000;
            const decimal valorTransferencia = -500;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);
            var conta2 = new Conta(321, saldoInicial, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(valorTransferencia, conta2));
            
            Assert.AreEqual("O valor da transferência deve ser superior a R$0,00", ex.Message);
        }
        
        [TestMethod]
        public void NaoDeveTransferirValorMaiorQueSaldoConta()
        {
            const decimal saldoInicial = 1000;
            const decimal valorTransferencia = 1500;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);
            var conta2 = new Conta(321, saldoInicial, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(valorTransferencia, conta2));
            
            Assert.AreEqual("O Valor da transferência ultrapassa o saldo da conta.", ex.Message);
        }
        
        [TestMethod]
        public void NaoDeveTransferirParaMesmaConta()
        {
            const decimal saldoInicial = 1000;
            const decimal valorTransferencia = 500;
            var conta1 = new Conta(123, saldoInicial, _cliente, _agencia);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(valorTransferencia, conta1));
            
            Assert.AreEqual("Não é possível transferir para a mesma conta.", ex.Message);
        }
    }
}