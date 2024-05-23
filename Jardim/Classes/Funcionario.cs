using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim.Classes
{
    public class Funcionario
    {
        private string id;
        private string nome;

        public Funcionario(string id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O ID do funcionário não pode estar vazio.");
                id = value;
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome do funcionário não pode estar vazio.");
                nome = value;
            }
        }
    }
}
