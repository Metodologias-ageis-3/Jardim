using Admin_Jardim.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim.Menus
{
    internal class MenuEquipa
    {
        private List<Equipa> equipas;

        public MenuEquipa(List<Equipa> equipas)
        {
            this.equipas = equipas;
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
            foreach (Equipa equipe in equipas)
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

                Equipa novaEquipe = new Equipa(nome);
                equipas.Add(novaEquipe);

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
                for (int i = 0; i < equipas.Count; i++)
                {
                    Console.WriteLine($"{i}. {equipas[i]}");
                }

                int escolha = int.Parse(Console.ReadLine());
                equipas.RemoveAt(escolha);

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
                for (int i = 0; i < equipas.Count; i++)
                {
                    Console.WriteLine($"{i}. {equipas[i]}");
                }

                int escolha = int.Parse(Console.ReadLine());
                Equipa equipe = equipas[escolha];

                Console.Write("Novo Nome: ");
                equipe.Nome = Console.ReadLine();

                Console.WriteLine("Equipe editada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
