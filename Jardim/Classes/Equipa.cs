using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Equipa
    {
        private string id = Guid.NewGuid().ToString();
        private string nomeEquipa;
        private Dictionary<string, string> integrantes;

        public static List<(string Id, string Nome)> PessoasPredefinidas = new List<(string, string)>
        {
            ("1", "João Silva"),
            ("2", "Maria Souza"),
            ("3", "Pedro Santos"),
            ("4", "Ana Oliveira"),
            ("5", "José Pereira"),
            ("6", "Carla Almeida"),
            ("7", "Antônio Lima"),
            ("8", "Mariana Ferreira"),
            ("9", "Carlos Rocha")
        };

        public Equipa(string nomeEquipa, List<(string, string)> integrantesSelecionados)
        {
            NomeEquipa = nomeEquipa;
            Integrantes = new Dictionary<string, string>();

            if (integrantesSelecionados != null)
            {
                foreach (var (id, nome) in integrantesSelecionados)
                {
                    AdicionarIntegrante(id, nome);
                }
            }

            if (Integrantes.Count == 0)
            {
                throw new ArgumentException("A equipe deve ter pelo menos um integrante.");
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (value == "")
                    throw new ArgumentException("O ID da equipa nao pode estar vazio.");

                id = value;
            }
        }

        public string NomeEquipa
        {
            get { return nomeEquipa; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome da equipe não pode estar vazio.");
                if (value.Length > 128)
                    throw new ArgumentException("O nome da equipe não pode ter mais de 128 caracteres.");
                if (int.TryParse(value, out int n))
                    throw new ArgumentException("O nome da equipe não pode ser um número inteiro.");

                nomeEquipa = value;
            }
        }

        public Dictionary<string, string> Integrantes
        {
            get { return integrantes; }
            private set { integrantes = value; }
        }

        public void AdicionarIntegrante(string id, string nomeIntegrante)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("O ID da pessoa não pode estar vazio.");
            if (string.IsNullOrEmpty(nomeIntegrante))
                throw new ArgumentException("O nome da pessoa não pode estar vazio.");

            if (integrantes.ContainsKey(id))
                throw new ArgumentException("Já existe uma pessoa com esse ID na equipe.");

            integrantes[id] = nomeIntegrante;
        }

        public void RemoverIntegrante(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("O ID da pessoa não pode estar vazio.");

            if (!integrantes.ContainsKey(id))
                throw new ArgumentException("Não existe uma pessoa com esse ID na equipe.");

            integrantes.Remove(id);
        }

        public override string ToString()
        {
            string integrantesInfo = string.Join(", ", Integrantes.Select(i => $"ID: {i.Key}, Nome: {i.Value}"));
            return $"Equipe: {NomeEquipa}\nIdentificador: {Id}\nIntegrantes: {integrantesInfo}";
        }
    }
}
