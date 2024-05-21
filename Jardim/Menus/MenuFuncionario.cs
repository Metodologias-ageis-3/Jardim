using Admin_Jardim.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim.Menus
{
    internal class MenuFuncionario
    {
        private List<Pessoa> pessoas;

        public MenuFuncionario(List<Pessoa> pessoas)
        {
            this.pessoas = pessoas;
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

                int escolha = int.Parse(Console.ReadLine());

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
                }

                Console.WriteLine("Pressione a tecla Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Listar()
        {
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine(pessoa);
            }
        }

        public void Adicionar()
        {
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Função: ");
                string funcao = Console.ReadLine();

                Pessoa novaPessoa = new Pessoa(nome, funcao);
                pessoas.Add(novaPessoa);

                Console.WriteLine("Pessoa adicionada com sucesso!");
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
                Console.WriteLine("Escolha a pessoa para deletar:");
                for (int i = 0; i < pessoas.Count; i++)
                {
                    Console.WriteLine($"{i}. {pessoas[i]}");
                }

                int escolha = int.Parse(Console.ReadLine());
                pessoas.RemoveAt(escolha);

                Console.WriteLine("Pessoa removida com sucesso!");
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
                Console.WriteLine("Escolha a pessoa para editar:");
                for (int i = 0; i < pessoas.Count; i++)
                {
                    Console.WriteLine($"{i}. {pessoas[i]}");
                }

                int escolha = int.Parse(Console.ReadLine());
                Pessoa pessoa = pessoas[escolha];

                Console.Write("Novo Nome: ");
                pessoa.Nome = Console.ReadLine();

                Console.Write("Nova Função: ");
                pessoa.Funcao = Console.ReadLine();

                Console.WriteLine("Pessoa editada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
