using Admin_Jardim.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin_Jardim
{
    public class Equipa
    {
        private string id = Guid.NewGuid().ToString();
        private string nomeEquipa;
        private List<Funcionario> integrantes;

        public Equipa(string nomeEquipa, List<Funcionario> integrantesSelecionados)
        {
            NomeEquipa = nomeEquipa;
            Integrantes = integrantesSelecionados ?? new List<Funcionario>();

            if (Integrantes.Count == 0)
            {
                throw new ArgumentException("A equipe deve ter pelo menos um integrante.");
            }
        }

        public static object PessoasPredefinidas { get; internal set; }

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

        public List<Funcionario> Integrantes
        {
            get { return integrantes; }
            private set { integrantes = value; }
        }

        public void AdicionarIntegrante(Funcionario funcionario)
        {
            if (funcionario == null)
                throw new ArgumentException("O funcionário não pode ser nulo.");
            if (Integrantes.Any(f => f.Id == funcionario.Id))
                throw new ArgumentException("Já existe uma pessoa com esse ID na equipe.");

            Integrantes.Add(funcionario);
        }

        public void RemoverIntegrante(string id)
        {
            var funcionario = Integrantes.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
                throw new ArgumentException("Não existe uma pessoa com esse ID na equipe.");

            Integrantes.Remove(funcionario);
        }

        public override string ToString()
        {
            string integrantesInfo = string.Join(", ", Integrantes.Select(i => $"ID: {i.Id}, Nome: {i.Nome}"));
            return $"Equipe: {NomeEquipa}\nIdentificador: {Id}\nIntegrantes: {integrantesInfo}";
        }
    }
}
