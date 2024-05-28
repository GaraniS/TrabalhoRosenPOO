using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaFinanceiro
{
    public class Cliente
    {
        private string _nome, _cpf;
        private int _anoNascimento;

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (value.Length == 11 && long.TryParse(value, out _))
                {
                    _cpf = value;
                }
                else
                {
                    throw new ArgumentException("O CPF deve ter 11 dígitos.");
                }
            }
        }
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }
        public int AnoNascimento
        {
            get => _anoNascimento;
            set
            {
                int currentYear = DateTime.Now.Year;
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
        public Cliente(string _nome, string _cpf, int _anoNascimento)
        {
            Nome = _nome;
            Cpf = _cpf;
            AnoNascimento = _anoNascimento;
        }

        public string CalcularIdadeEmNumerosRomanos()
        {
            int currentYear = DateTime.Now.Year;
            var idade = currentYear - AnoNascimento;

            if (idade < 1 || idade > 3999)
                throw new ArgumentOutOfRangeException("idade", "A idade deve estar entre 1 e 3999");

            var mapa = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

            var resultado = string.Empty;
            foreach (var item in mapa)
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
