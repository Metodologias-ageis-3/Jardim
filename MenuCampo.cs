using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuCampo<T> where T : class
    {
        private string nome;
        private T instancia;
        private Func<T, string> getValor;
        
        public MenuCampo(string nome, Func<T, string> getValor, T instancia = null) 
        {
            this.nome = nome;
            this.getValor = getValor;
            this.instancia = instancia;
        }

        public string Main()
        {
            string nomeDica = instancia == null ? "" : $"({getValor(instancia)})";
            Console.Write($"{nome}{nomeDica}: ");
            string valor = Console.ReadLine();

            return valor.Length == 0 ? getValor(instancia) : valor;
        }
    }
}
