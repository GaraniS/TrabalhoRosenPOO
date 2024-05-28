using SistemaFinanceiro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro
{
    public class Agencia
    {
        private int _numero;
        private string _nome, _telefone, _cep;

        public Agencia(int numero)
        {
            _numero = numero;
        }
        public int Numero { get => _numero; }
        public string Nome 
        { 
            get => _nome; 
            set => _nome = value;
        }
        public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = value;
            }
        }
        public string Cep
        {
            get => _cep;
            set
            {
                _cep = value;
            }
        }
    }
}
