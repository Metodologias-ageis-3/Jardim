using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuCanteiro
    {
        private List<Canteiro> canteiros;
        private Context context = null;

        public MenuCanteiro(List<Canteiro> canteiros, Context context = null) 
        { 
            this.canteiros = canteiros;
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

        public void Listar()
        {
            
        }

        public void Adicionar()
        {
            Console.Write("Localização: ");
            string localizacao = Console.ReadLine();
            
            Console.Write("Jardim Id: ");
            int jardimId = int.Parse(Console.ReadLine());
            
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
                JardimId = jardimId,
                ComposicaoCanteiro = composicaoCanteiro,
                Area = area,
                AreaSemeada = areaSemeada,
            };

            canteiros.Add(canteiro);
            Console.WriteLine("Canteiro adicionado com sucesso!");
        }
    }
}
