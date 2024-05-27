using SistemaFinanceiro.Model;

namespace SistemaFinanceiroTest
{
    [TestClass]
    public class ContaTest
    {
        [TestMethod]
        public void DepositoTest()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorDeposito = 1000;
            decimal saldoFinal = 2000;
            Conta conta1 = new Conta(123, saldoInicial);

            //ação
            conta1.Deposito(valorDeposito);

            //verificação
            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }

        [TestMethod]
        public void SaqueTest()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 500;
            decimal saldoFinal = 500;
            Conta conta1 = new Conta(123, saldoInicial);

            //ação
            conta1.Saque(valorSaque);

            //verificação
            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }

        [TestMethod]
        public void ValorSaqueMaiorSaldo()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 1500;
            Conta conta1 = new Conta(123, saldoInicial);

            //verificação
            Assert.ThrowsException<ArgumentException>(() => conta1.Saque(valorSaque));
        }
    }
}