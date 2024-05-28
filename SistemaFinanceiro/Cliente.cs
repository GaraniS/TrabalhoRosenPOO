using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }   
}
