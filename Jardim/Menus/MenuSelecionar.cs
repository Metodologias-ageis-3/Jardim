using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuSelecionar<T>
    {
        public static int NENHUM = -1; 

        private List<T> itens;
        private string titulo;
        private Func<T, string> getField;

        public MenuSelecionar(List<T> itens, Func<T, string> getField, string titulo = "item") 
        { 
            this.itens = itens;
            this.titulo = titulo;
            this.getField = getField;
        }

        public int Main(bool loop = false, bool permiteNulo = false)
        {
            if (!loop)
            {
                return choice(permiteNulo);
            }

            int escolha = -1;
            while (escolha == -1)
            {
                int selecionado = choice(permiteNulo);
                if (selecionado < itens.Count)
                {
                    escolha = selecionado;
                }
                else
                {
                    Console.WriteLine("Essa opcao nao existe, escolha novamente");
                }
            }

            return escolha;
        }

        private int choice(bool permiteNulo = false)
        {
            for (int i = 0; i < itens.Count; ++i)
            {
                Console.WriteLine($"{i + 1} {getField(itens[i])}");
            }

            Console.Write($"Escolha um {titulo}: ");

            string raw = Console.ReadLine();

            if (raw == "" && permiteNulo)
            {
                return NENHUM;
            }

            int escolha = int.Parse(raw);

            return escolha - 1;
        }
    }
}
