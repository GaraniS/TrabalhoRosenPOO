namespace SistemaFinanceiro.Models
{
    public class Agencia(int numero, string nome, string telefone, string cep)
    {
        public int Numero { get; } = numero;

        public string Nome { get; set; } = nome;

        public string Telefone { get; set; } = telefone;

        public string Cep { get; set; } = cep;
    }
}