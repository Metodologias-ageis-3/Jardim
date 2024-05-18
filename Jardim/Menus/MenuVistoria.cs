using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuVistoria
    {
        private Context context;

        private List<string> sintomasDisponiveis = new List<string>
        {
            "Inclinação Tronco",
            "Codominância Tronco",
            "Codominância Ramos",
            "Casca Inclusa Tronco",
            "Casca Inclusa Ramos",
            "Fendas / Fissuras Colo",
            "Fendas / Fissuras Tronco",
            "Fendas / Fissuras Ramos",
            "Torção Tronco",
            "Fendas / Cicatrizes Colo",
            "Fendas / Cicatrizes Tronco",
            "Fendas / Cicatrizes Ramos",
            "Podridão Colo",
            "Podridão Tronco",
            "Podridão Ramos",
            "Cavidades Colo",
            "Cavidades Tronco",
            "Cavidades Ramos",
            "Estruturas Fungos Colo",
            "Estruturas Fungos Tronco",
            "Estruturas Fungos Ramos",
            "Exsudações Colo",
            "Exsudações Tronco",
            "Exsudações Ramos",
            "Madeira morta Ramos",
            "Cancros Tronco",
            "Cancros Ramos",
            "Rebentos ladrões / Epicórmicos",
            "Pragas Tronco",
            "Pragas Ramos"
        };

        public MenuVistoria(Context context = null)
        {
            this.context = context;
        }

        public bool Main()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Realizar vistoria");
                Console.WriteLine("2. Voltar\n");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        RealizarVistoria();
                        break;
                    case 2:
                        return true;
                }

                Console.WriteLine("Pressione a tecla Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void RealizarVistoria()
        {
            try
            {
                int escolha = new MenuSelecionar<Arvore>(context.arvores, a => a.Nome, "Árvore", "uma").Main(loop: true);

                Console.Write("Data da vistoria (DD/MM/YYYY): ");
                DateTime dataVistoria = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Altura estimada: ");
                double alturaEstimada = double.Parse(Console.ReadLine());

                Console.Write("Diâmetro do tronco: ");
                double diametroTronco = double.Parse(Console.ReadLine());

                Console.Write("Diâmetro da copa: ");
                double diametroCopa = double.Parse(Console.ReadLine());

                Dictionary<string, int> sintomas = new Dictionary<string, int>();

                Console.WriteLine("Sintomas disponíveis:");
                foreach (string sintoma in sintomasDisponiveis)
                {
                    Console.WriteLine($"- {sintoma}");
                }

                Console.WriteLine("\nPara cada sintoma, indique se deseja interagir (s/n) e atribua uma classificação de 0 a 3 se sim:");

                //foreach (string sintoma in sintomasDisponiveis)
                //{
                //    Console.WriteLine($"Deseja interagir com o sintoma '{sintoma}'? (s/n)");
                //    string resposta = Console.ReadLine();

                //    if (resposta.ToLower() == "s")
                //    {
                //        Console.Write($"Classificação para o sintoma '{sintoma}': ");
                //        int classificacao = int.Parse(Console.ReadLine());
                //        sintomas[sintoma] = classificacao;
                //    }
                //}

                Vistoria vistoria = new Vistoria {
                    DataVistoria = dataVistoria,
                    AlturaEstimada = alturaEstimada,
                    DiametroTronco = diametroTronco,
                    DiametroCopa = diametroCopa,
                    //Sintomas = sintomas,
                    Arvore = context.arvores[escolha],
                };

                context.AdicionarVistoria(vistoria);

                Console.WriteLine("Vistoria realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao realizar vistoria: " + ex.Message);
            }
        }
    }
}
