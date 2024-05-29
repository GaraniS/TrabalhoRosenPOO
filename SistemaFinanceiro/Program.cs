using SistemaFinanceiro.Models;

try
{
    var cliente = new Cliente("Pablo", "12345678901", 2003);
    var agencia = new Agencia(123, "Agencia1", "12345678", "12345678");
    var banco = new Banco(123, "Banco1", agencia);

    const decimal saldoInicialConta1 = 1235.42m;
    const decimal saldoInicialConta2 = 2341.42m;

    var conta1 = new Conta(123456, saldoInicialConta1, cliente, agencia);
    Console.WriteLine($"Conta: {conta1.Numero}");

    var conta2 = new Conta(654321, saldoInicialConta2, cliente, agencia);
    Console.WriteLine($"Conta: {conta2.Numero}");

//Saldo inicial total das contas
    Console.WriteLine($"Saldo inicial total geral: {(saldoInicialConta1 + saldoInicialConta2):C}");

//Número da conta que apresenta maior saldo
    var contaMaiorSaldo = conta1.Saldo >= conta2.Saldo ? conta1 : conta2;
    Console.WriteLine($"O número da conta com maior saldo é: {contaMaiorSaldo.Numero}");

//Deposito e saque das contas
    conta1.Sacar(1000);
    conta2.Depositar(1500);

//Saldo total após saque e deposito das contas
    Console.WriteLine($"Saldo total após o saque e deposito é de: {(conta1.Saldo + conta2.Saldo):C}");

//Transferência entre contas
    conta2.Transferir(1000, conta1);
    Console.WriteLine($"Saldo da conta 1 é de: {(conta1.Saldo):C}");
    Console.WriteLine($"Saldo da conta 2 é de: {(conta2.Saldo):C}");

//Idade em números romanos do cliente
    Console.WriteLine(
        $"A idade do cliente {cliente.Nome} em números romanos é {cliente.CalcularIdadeEmNumerosRomanos()}");

//Informações do Banco
    Console.WriteLine(
        $"Banco: {banco.Nome}, Agência: {banco.Agencia.Nome} | Número da Agência: {banco.Agencia.Numero}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}