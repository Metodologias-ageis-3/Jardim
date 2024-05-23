using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuSintomas
    {
    
        private Dictionary<string, int> sintomas;

        public MenuSintomas(Dictionary<string, int> sintomas = null)
        {
            this.sintomas = sintomas == null ? new Dictionary<string, int>() : sintomas;
        }

        public bool Main()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Adicinoar sintoma");
                Console.WriteLine("2. Editar sintoma");
                Console.WriteLine("3. Remover sintoma");
                Console.WriteLine("4. Listar sintomas informados");
                Console.WriteLine("5. Voltar\n");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        AdicionarOuEditarSintoma();
                        break;
                    case 2:
                        AdicionarOuEditarSintoma(editar: true);
                        break;
                    case 3:
                        RemoverSintoma();
                        break;
                    case 4:
                        ListarSintomasInformados();
                        break;
                    case 5:
                        return true;
                }

                Console.WriteLine("Pressione a tecla Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public Dictionary<string, int> Sintomas
        {
            get { return sintomas; }
        }

        private void AdicionarOuEditarSintoma(bool editar = false)
        {
            List<string> listaSintomas = editar 
                ? sintomas.Keys.ToList()
                : Vistoria.SINTOMAS;

            int escolha = new MenuSelecionar<string>(listaSintomas, s => s, "Sintoma").Main();
            string sintoma = listaSintomas[escolha];

            Console.Write($"Classificação para o sintoma '{sintoma}' (número de 0 a 3): ");
            if (int.TryParse(Console.ReadLine(), out int classificacao) && classificacao >= 0 && classificacao <= 3)
            {
                sintomas[sintoma] = classificacao;
            }
            else
            {
                Console.WriteLine("Classificação inválida. Deve ser um número entre 0 e 3.");
            }
        }

        private void ListarSintomasInformados()
        {
            foreach (KeyValuePair<string, int> s in sintomas)
            {
                Console.WriteLine($"{s.Key}: {s.Value}");
            }
        }

        private void RemoverSintoma()
        {
            int escolha = new MenuSelecionar<string>(sintomas.Keys.ToList(), s => s, "Sintoma").Main();
            sintomas.Remove(sintomas.Keys.ToList()[escolha]);
        }
    }
}
