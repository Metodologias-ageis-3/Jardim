using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuEquipa
    {
        private Context context;

        public MenuEquipa(Context context)
        {
            this.context = context;
        }

        public bool Main()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar");
                Console.WriteLine("2. Adicionar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Apagar");
                Console.WriteLine("5. Voltar\n");

                int escolha;
                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha um número de 1 a 5.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Adicionar();
                        break;
                    case 3:
                        Editar();
                        break;
                    case 4:
                        Deletar();
                        break;
                    case 5:
                        return true;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha um número de 1 a 5.");
                        break;
                }

                Console.WriteLine("Pressione a tecla Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Listar()
        {
            foreach (Equipa equipe in context.equipas)
            {
                Console.WriteLine(equipe);
            }
        }

        public void Adicionar()
        {
            try
            {
                Console.Write("Nome da Equipe: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Funcionários disponíveis:");

                for (int i = 0; i < Equipa.PessoasPredefinidas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Equipa.PessoasPredefinidas[i].Item2}");
                }

                Console.WriteLine("Selecione os números dos funcionários que deseja adicionar (separados por vírgula):");
                string input = Console.ReadLine();
                string[] indices = input.Split(',');

                List<(string, string)> funcionariosSelecionados = new List<(string, string)>();

                foreach (var index in indices)
                {
                    int idx;
                    if (int.TryParse(index.Trim(), out idx) && idx >= 1 && idx <= Equipa.PessoasPredefinidas.Count)
                    {
                        funcionariosSelecionados.Add(Equipa.PessoasPredefinidas[idx - 1]);
                    }
                    else
                    {
                        throw new ArgumentException("Número de funcionário inválido.");
                    }
                }

                Equipa novaEquipe = new Equipa(nome, funcionariosSelecionados);
                context.equipas.Add(novaEquipe);

                Console.WriteLine("Equipe adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Deletar()
        {
            try
            {
                Console.WriteLine("Escolha a equipe para deletar:");
                for (int i = 0; i < context.equipas.Count; i++)
                {
                    Console.WriteLine($"{i}. {context.equipas[i]}");
                }

                int escolha = int.Parse(Console.ReadLine());
                context.equipas.RemoveAt(escolha);

                Console.WriteLine("Equipe removida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Editar()
        {
            try
            {
                Console.WriteLine("Escolha a equipe para editar:");
                for (int i = 0; i < context.equipas.Count; i++)
                {
                    Console.WriteLine($"{i}. {context.equipas[i]}");
                }

                int escolha = int.Parse(Console.ReadLine());
                Equipa equipe = context.equipas[escolha];

                Console.Write("Novo Nome: ");
                equipe.NomeEquipa = Console.ReadLine();

                Console.WriteLine("Equipe editada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
