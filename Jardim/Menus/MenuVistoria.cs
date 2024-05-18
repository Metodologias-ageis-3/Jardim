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
                Console.WriteLine("2. Listar vistorias");
                Console.WriteLine("3. Voltar\n");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        RealizarVistoria();
                        break;
                    case 2:
                        ListarVistorias();
                        break;
                    case 3:
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

                Console.Write("Deseja adicionar sintomas? (s/n) ");
                string resposta = Console.ReadLine();

                MenuSintomas menuSintomas = new MenuSintomas();

                if (resposta == "s")
                {
                    menuSintomas.Main();
                }

                Vistoria vistoria = new Vistoria {
                    DataVistoria = dataVistoria,
                    AlturaEstimada = alturaEstimada,
                    DiametroTronco = diametroTronco,
                    DiametroCopa = diametroCopa,
                    Sintomas = menuSintomas.Sintomas,
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

        private void ListarVistorias()
        {
            var arvoreById = context.arvores.ToDictionary(a => a.Id, a => a);
            var result = context.vistorias.GroupBy(v => v.Arvore.Id, v => v);

            foreach (IGrouping<string, Vistoria> vistoriaGroup in result)
            {
                Arvore arvore = arvoreById[vistoriaGroup.Key];
                string a = arvore.ToString();

                Console.Write(
                    "---\n"
                    + $"Árvore:\n{a}\n"
                    + "  Vistorias\n"
                );

                foreach (Vistoria vistoria in vistoriaGroup)
                {
                    string v = string.Join("\n", vistoria.ToString().Split('\n').Select(s => $"  {s}"));
                    Console.WriteLine(v);
                }
            }
        }
    }
}
