namespace SistemaFinanceiro.Models
{
    public class Banco(int numero, string nome, Agencia agencia)
    {
        public string Nome { get; } = nome;

        public int Numero { get; } = numero;

        public Agencia Agencia { get; set; } = agencia;
    }
}