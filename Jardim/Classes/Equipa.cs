using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim.Classes
{
    internal class Equipa
    {
        private string id = Guid.NewGuid().ToString();
        private string nome;
        private List<Pessoa> integrantes;

        public Equipa(string nome)
        {
            Nome = nome;
            Integrantes = new List<Pessoa>();
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
                    throw new ArgumentException("O nome da equipe não pode estar vazio.");
                if (value.Length > 128)
                    throw new ArgumentException("O nome da equipe não pode ter mais de 128 caracteres.");
                if (int.TryParse(value, out int n))
                    throw new ArgumentException("O nome da equipe não pode ser um número inteiro.");

                nome = value;
            }
        }

        public List<Pessoa> Integrantes
        {
            get { return integrantes; }
            private set { integrantes = value; }
        }

        public void AdicionarIntegrante(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentException("A pessoa não pode ser nula.");

            integrantes.Add(pessoa);
        }

        public void RemoverIntegrante(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentException("A pessoa não pode ser nula.");

            integrantes.Remove(pessoa);
        }

        public override string ToString()
        {
            string integrantesInfo = string.Join(", ", Integrantes.ConvertAll(p => p.ToString()));
            return $"Equipe: {Nome}\nIdentificador: {Id}\nIntegrantes: {integrantesInfo}";
        }
    }
}
