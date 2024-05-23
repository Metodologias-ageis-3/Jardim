using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Admin_Jardim
{
    public class Program
    {
        private static Context context = new Context(populate: true);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Administrar jardins");
                Console.WriteLine("2. Administrar canteiros");
                Console.WriteLine("3. Administrar árvores");
                Console.WriteLine("4. Administrar vistorias");
                Console.WriteLine("5. Administrar Equipas");
                Console.WriteLine("6. Sair");

                string entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":
                        new MenuJardim(context).Main();
                        break;
                    case "2":
                        new MenuCanteiro(context).Main();
                        break;
                    case "3":
                        new MenuArvore(context).Main();
                        break;
                    case "4":
                        new MenuVistoria(context).Main();
                        break;
                    case "5":
                        new MenuEquipa(context).Main();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
