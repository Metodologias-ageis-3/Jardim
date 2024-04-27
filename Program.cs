using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Admin_Jardim
{
    public class Program
    {
        private static Context context = new Context();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Administrar canteiros");
                Console.WriteLine("2. Administrar arvores");
                Console.WriteLine("3. Administrar jardins");
                Console.WriteLine("5. Sair");

                int escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        new MenuCanteiro(context.canteiros).Main();
                        break;
                    case 2:
                        Console.WriteLine("Não implementado!");
                        break;
                    case 3:
                        Console.WriteLine("Não implementado!");
                        break;
                    case 4:
                        Console.WriteLine("Não implementado!");
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
