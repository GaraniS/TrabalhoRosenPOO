using SistemaFinanceiro.Utils;

namespace SistemaFinanceiro.Models
{
    public class Cliente
    {
        private string? _cpf;
        private readonly int _anoNascimento;

        public Cliente(string nome, string? cpf, int anoNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            AnoNascimento = anoNascimento;
        }
        
        public string? Cpf
        {
            get => _cpf;
            set
            {
                if (value is { Length: 11 } && long.TryParse(value, out _) && long.IsPositive(long.Parse(value)))
                {
                    _cpf = value;
                }
                else
                {
                    throw new ArgumentException("O CPF deve ter 11 dígitos.");
                }
            }
        }

        public string Nome { get; set; }

        private int AnoNascimento
        {
            get => _anoNascimento;
            init
            {
                var currentYear = DateTime.Now.Year;
                
                if (currentYear - value >= 18)
                {
                    _anoNascimento = value;
                }
                else
                {
                    throw new ArgumentException("O cliente deve ter mais de 18 anos.");
                }
            }
        }
        
        public string CalcularIdadeEmNumerosRomanos()
        {
            var currentYear = DateTime.Now.Year;
            var idade = currentYear - AnoNascimento;

            if (idade is < 1 or > 3999)
                throw new ArgumentOutOfRangeException(nameof(idade), "A idade deve estar entre 1 e 3999");
            
            var resultado = string.Empty;
            
            foreach (var item in SistemaNumericoUtil.NumerosRomanos)
            {
                while (idade >= item.Key)
                {
                    resultado += item.Value;
                    idade -= item.Key;
                }
            }

            return resultado;
        }
    }
}