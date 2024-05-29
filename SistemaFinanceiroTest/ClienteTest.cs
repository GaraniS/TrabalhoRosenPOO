using SistemaFinanceiro.Models;

namespace SistemaFinanceiroTest;

[TestClass]
public class ClienteTest
{
    [TestMethod]
    public void NaoDeveConstruirClienteComCPFInvalido()
    {
        Assert.ThrowsException<ArgumentException>(() => new Cliente("Paulo", "1234567890", 2003),
            "O CPF deve ter 11 dígitos.");
    }
    
    [TestMethod]
    public void NaoDeveConstruirClienteMenorDeIdade()
    {
        var currentYear = DateTime.Now.Year;
        var anoNascimento = currentYear - 17;
        Assert.ThrowsException<ArgumentException>(() => new Cliente("Paulo", "1234567890", anoNascimento),
            "O cliente deve ter mais de 18 anos.");
    }
    
    [TestMethod]
    public void DeveConstruirCliente()
    {
        var cliente = new Cliente("Paulo", "12345678901", 2003);
        
        Assert.IsNotNull(cliente);
    }
    
    [TestMethod]
    public void DeveCalcularIdadeEmNumerosRomanos()
    {
        var currentYear = DateTime.Now.Year;
        var anoNascimento = currentYear - 20;
        var cliente = new Cliente("Paulo", "12345678901", anoNascimento);
        
        var idadeEmNumerosRomanos = cliente.CalcularIdadeEmNumerosRomanos();
        
        Assert.AreEqual("XX", idadeEmNumerosRomanos);
    }
    
    [TestMethod]
    public void NaoDeveCalcularIdadeEmNumerosRomanos()
    {
        var currentYear = DateTime.Now.Year;
        var anoNascimento = currentYear - 4000;
        var cliente = new Cliente("Paulo", "12345678901", anoNascimento);
        
        var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => cliente.CalcularIdadeEmNumerosRomanos());
        
        Assert.AreEqual("A idade deve estar entre 1 e 3999 (Parameter 'idade')", ex.Message);
    }
}