using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim.Classes
{
    internal class Pessoa
    {
        private string id = Guid.NewGuid().ToString();
        private string nome;
        private string funcao;

        public Pessoa(string nome, string funcao)
        {
            Nome = nome;
            Funcao = funcao;
        }

        public string Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome não pode estar vazio.");
                nome = value;
            }
        }

        public string Funcao
        {
            get { return funcao; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A função não pode estar vazia.");
                funcao = value;
            }
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Função: {Funcao}, ID: {Id}";
        }
    }
}
