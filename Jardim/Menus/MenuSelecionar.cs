using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuSelecionar<T>
    {
        private List<T> itens;
        private string titulo;
        private Func<T, string> getField;

        public MenuSelecionar(List<T> itens, Func<T, string> getField, string titulo = "item") 
        { 
            this.itens = itens;
            this.titulo = titulo;
            this.getField = getField;
        }

        public int Main()
        {
            for (int i = 0; i < itens.Count; ++i) { 
                Console.WriteLine($"{i+1} {getField(itens[i])}"); 
            }

            Console.Write($"Escolha um {titulo}: ");
            int escolha = int.Parse(Console.ReadLine());

            return escolha - 1;
        }
    }
}
