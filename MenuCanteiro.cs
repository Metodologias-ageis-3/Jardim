using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuCanteiro
    {
        private Context context = null;

        public MenuCanteiro( Context context = null) 
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
                Console.WriteLine("4. Deletar");
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
                    case 3:
                        Editar();
                        break;
                    case 4:
                        Deletar();
                        break;

                    case 5:
                        return true;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Listar()
        {
            foreach (Canteiro canteiro in context.canteiros)
            {
                Console.WriteLine(canteiro);
            }
        }

        public void Adicionar()
        {
            Console.Write("Localização: ");
            string localizacao = Console.ReadLine();
            
            
            Jardim jardim = null;
            do
            {
                Console.Write("Nome do Jardim: ");
                string jardimNome = Console.ReadLine();
                jardim = context.jardins.Where(j => j.Nome == jardimNome).ToList().FirstOrDefault();
                if (jardim == null)
                {
                    Console.Write("\nJardim nao existe, digite novamente.\n");
                }
            } while (jardim == null);

            Console.Write("Composição Canteiro: ");
            string composicaoCanteiro = Console.ReadLine();
            
            Console.Write("Área: ");
            float area = float.Parse(Console.ReadLine());
            
            Console.Write("Área Semeada: ");
            float areaSemeada = float.Parse(Console.ReadLine());

            Canteiro canteiro = new Canteiro
            {
                Id = Guid.NewGuid().ToString(),
                Localizacao = localizacao,
                Jardim = jardim,
                ComposicaoCanteiro = composicaoCanteiro,
                Area = area,
                AreaSemeada = areaSemeada,
            };

            context.canteiros.Add(canteiro);
            Console.WriteLine("Canteiro adicionado com sucesso!");
        }
        private void Deletar()
        {
            int escolha = new MenuSelecionar<Canteiro>(context.canteiros, j => j.Localizacao +" - "+ j.Jardim.Nome, "canteiro").Main();

            context.canteiros.RemoveAt(escolha);
            Console.WriteLine("Canteiros removido com sucesso!");
        }
        private void Editar()
        {
            int escolha = new MenuSelecionar<Canteiro>(context.canteiros, j => j.Localizacao + " - " + j.Jardim.Nome, "canteiro").Main();
            Console.WriteLine(escolha);

            Console.Write("Localização: ");
            string localizacao = Console.ReadLine();


            Jardim jardim = null;
            do
            {
                Console.Write("Nome do Jardim: ");
                string jardimNome = Console.ReadLine();
                jardim = context.jardins.Where(j => j.Nome == jardimNome).ToList().FirstOrDefault();
                if (jardim == null)
                {
                    Console.Write("\nJardim nao existe, digite novamente.\n");
                }
            } while (jardim == null);

            Console.Write("Composição Canteiro: ");
            string composicaoCanteiro = Console.ReadLine();

            Console.Write("Área: ");
            float area = float.Parse(Console.ReadLine());

            Console.Write("Área Semeada: ");
            float areaSemeada = float.Parse(Console.ReadLine());

            context.canteiros[escolha].Localizacao= localizacao;
            context.canteiros[escolha].ComposicaoCanteiro = composicaoCanteiro;
            context.canteiros[escolha].Area = area;
            context.canteiros[escolha].AreaSemeada = areaSemeada;
            context.canteiros[escolha].Jardim = jardim;

            Console.WriteLine("Canteiro editado com sucesso!");
        }

    }
}
