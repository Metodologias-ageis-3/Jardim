using Admin_Jardim.Classes;
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
                for (int i = 0; i < context.funcionarios.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {context.funcionarios[i].Nome}");
                }

                Console.WriteLine("Selecione os números dos funcionários que deseja adicionar (separados por vírgula):");
                string input = Console.ReadLine();
                string[] indices = input.Split(',');

                if (indices.Length > 3)
                {
                    throw new ArgumentException("A equipe só pode ter no máximo 3 integrantes.");
                }

                List<Funcionario> funcionariosSelecionados = new List<Funcionario>();

                foreach (var index in indices)
                {
                    if (int.TryParse(index.Trim(), out int idx) && idx >= 1 && idx <= context.funcionarios.Count)
                    {
                        funcionariosSelecionados.Add(context.funcionarios[idx - 1]);
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
                    Console.WriteLine($"{i + 1}. {context.equipas[i].NomeEquipa}");
                }

                int escolha = int.Parse(Console.ReadLine());
                if (escolha < 1 || escolha > context.equipas.Count)
                {
                    throw new ArgumentException("Escolha inválida.");
                }

                context.equipas.RemoveAt(escolha - 1);

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
                    Console.WriteLine($"{i + 1}. {context.equipas[i].NomeEquipa}");
                }

                int escolha = int.Parse(Console.ReadLine());
                if (escolha < 1 || escolha > context.equipas.Count)
                {
                    throw new ArgumentException("Escolha inválida.");
                }

                Equipa equipe = context.equipas[escolha - 1];

                Console.WriteLine($"Equipe selecionada: {equipe.NomeEquipa}");

                Console.WriteLine("Integrantes atuais:");
                foreach (var integrante in equipe.Integrantes)
                {
                    Console.WriteLine($"- {integrante.Id}: {integrante.Nome}");
                }

                Console.WriteLine($"Número atual de integrantes: {equipe.Integrantes.Count}");

                Console.WriteLine("Deseja alterar o nome da equipe? (s/n)");
                string alterarNome = Console.ReadLine().Trim().ToLower();

                if (alterarNome == "s")
                {
                    Console.Write("Novo Nome: ");
                    equipe.NomeEquipa = Console.ReadLine();
                }

                Console.WriteLine("Deseja adicionar ou remover integrantes? (a - Adicionar, r - Remover, Enter - Sair)");
                string opcao = Console.ReadLine().Trim().ToLower();

                switch (opcao)
                {
                    case "a":
                        if (equipe.Integrantes.Count >= 3)
                        {
                            Console.WriteLine("A equipe já tem o máximo de integrantes permitidos (3).");
                            break;
                        }

                        Console.WriteLine("Funcionários disponíveis:");
                        for (int i = 0; i < context.funcionarios.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {context.funcionarios[i].Nome}");
                        }

                        Console.WriteLine("Selecione os números dos funcionários que deseja adicionar (separados por vírgula):");
                        string inputAdicionar = Console.ReadLine();
                        string[] indicesAdicionar = inputAdicionar.Split(',');

                        foreach (var index in indicesAdicionar)
                        {
                            if (int.TryParse(index.Trim(), out int idx) && idx >= 1 && idx <= context.funcionarios.Count)
                            {
                                var pessoaSelecionada = context.funcionarios[idx - 1];
                                if (!equipe.Integrantes.Any(f => f.Id == pessoaSelecionada.Id))
                                {
                                    equipe.AdicionarIntegrante(pessoaSelecionada);
                                }
                                else
                                {
                                    Console.WriteLine($"O integrante {pessoaSelecionada.Nome} já faz parte da equipe.");
                                }

                                if (equipe.Integrantes.Count >= 3)
                                {
                                    Console.WriteLine("A equipe atingiu o máximo de integrantes permitidos (3).");
                                    break;
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Número de funcionário inválido.");
                            }
                        }
                        break;

                    case "r":
                        if (equipe.Integrantes.Count == 0)
                        {
                            Console.WriteLine("A equipe já está vazia.");
                            break;
                        }

                        Console.WriteLine("Selecione o número do integrante que deseja remover (separados por vírgula):");
                        string inputRemover = Console.ReadLine();
                        string[] indicesRemover = inputRemover.Split(',');

                        foreach (var index in indicesRemover)
                        {
                            if (int.TryParse(index.Trim(), out int idx) && idx >= 1 && idx <= equipe.Integrantes.Count)
                            {
                                var integranteRemover = equipe.Integrantes[idx - 1];
                                equipe.RemoverIntegrante(integranteRemover.Id);
                            }
                            else
                            {
                                throw new ArgumentException("Número de integrante inválido.");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Operação cancelada.");
                        break;
                }

                Console.WriteLine("Equipe editada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
