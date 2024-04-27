using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuJardim
    {
        private List<Jardim> jardins;
        private Context context;

        public MenuJardim(List<Jardim> jardins, Context context = null) 
        { 
            this.jardins = jardins;
            this.context = context;
        }

        public bool Main()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar");
                Console.WriteLine("2. Adicionar");
                Console.WriteLine("5. Retornar\n");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Adicionar();
                        break;
                    case 5:
                        return true;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void Listar()
        {
            foreach (Jardim jardim in jardins)
            {
                Console.WriteLine(jardim);
            }
        }

        private void Adicionar() 
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Localização: ");
            string localizacao = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Área: ");
            double area = double.Parse(Console.ReadLine());

            Console.Write("Topografia: ");
            string topografia = Console.ReadLine();

            Console.Write("Equipa Responsável: ");
            string equipaResponsavel = Console.ReadLine();

            Console.Write("Características Canteiros: ");
            string caracteristicaCanteiros = Console.ReadLine();

            Jardim jardim = new Jardim
            {
                Nome = nome,
                Localizacao = localizacao,
                Descricao = descricao,
                Area = area,
                Topografia = topografia,
                EquipaResponsavel = equipaResponsavel,
                CaracteristicasCanteiros = caracteristicaCanteiros,
            };

            jardins.Add(jardim);
            Console.WriteLine("Jardim adicionado com sucesso!");
        }
    }
}
