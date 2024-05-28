using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro
{
    public class Banco
    {
        private string _nome;
        private int _numero;

        private Agencia _agencia;

        public Banco(int numero, string nome, Agencia agencia)
        {
            _numero = numero;
            _nome = nome;
            _agencia = agencia;
        }

        public string Nome { get { return _nome; } }
        public int Numero { get { return _numero; } }




    }
}
