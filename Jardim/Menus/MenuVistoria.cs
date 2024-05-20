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
                Console.WriteLine("3. Editar vistoria");
                Console.WriteLine("4. Remover vistoria");
                Console.WriteLine("5. Voltar\n");

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
                        EditarVistoria();
                        break;
                    case 4:
                        DeletarVistoria();
                        break;
                    case 5:
                        return true;
                }

                Console.WriteLine("Pressione a tecla Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void DeletarVistoria()
        {
            int escolha = -1;
            while (escolha == -1)
            {
                int selecionado = new MenuSelecionar<Vistoria>(context.vistorias, v => v.Nome, "vistoria").Main();
                if (selecionado < context.vistorias.Count)
                {
                    escolha = selecionado;
                } 
                else
                {
                    Console.WriteLine("Essa opcao nao existe, escolha novamente");
                }
            }

            context.DeleteVistoria(context.vistorias[escolha]);
            Console.WriteLine("Vistoria removida com sucesso!"); 
        }

        private void RealizarVistoria()
        {
            try
            {
                Vistoria novaVistoria = LerVistoria();
                context.AdicionarVistoria(novaVistoria);

                Console.WriteLine("Vistoria adicionada com sucesso!"); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void EditarVistoria()
        {
            int escolha = -1;

            try
            {
                while (escolha == -1)
                {
                    int selecionado = new MenuSelecionar<Vistoria>(context.vistorias, v => v.Nome, "Vistoria").Main();

                    if (selecionado < context.vistorias.Count)
                    {
                        escolha = selecionado;
                    }
                    else
                    {
                        Console.WriteLine("Essa opcao nao existe, escolha novamente");
                    }
                }

                context.EditarVistoria(LerVistoria(context.vistorias[escolha]));
                Console.WriteLine("Vistoria editada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        

        private Vistoria LerVistoria(Vistoria vistoriaInicial = null)
        {
            int escolha = -1;

            if (vistoriaInicial == null)
            {
                escolha = new MenuSelecionar<Arvore>(context.arvores, a => a.Nome, "Árvore", "uma").Main(loop: true);
            }

            DateTime dataVistoria = Convert.ToDateTime(new MenuCampo<Vistoria>("Data", v => $"{v.DataVistoria:dd/MM/yyyy}", vistoriaInicial).Main());
            
            double alturaEstimada = double.Parse(new MenuCampo<Vistoria>("Altura estimada", v => $"{v.AlturaEstimada:F2}", vistoriaInicial).Main());
            double diametroTronco = double.Parse(new MenuCampo<Vistoria>("Diâmetro do tronco", v => $"{v.DiametroTronco:F2}", vistoriaInicial).Main());
            double diametroCopa = double.Parse(new MenuCampo<Vistoria>("Diâmetro da copa", v => $"{v.DiametroCopa:F2}", vistoriaInicial).Main());

            string operacao = vistoriaInicial == null ? "adicionar" : "editar";
            Console.Write($"Deseja {operacao} sintomas? (s/n) ");
            string resposta = Console.ReadLine();

            MenuSintomas menuSintomas = new MenuSintomas(vistoriaInicial?.Sintomas);

            if (resposta == "s")
            {
                menuSintomas.Main();
            }

            Vistoria vistoria = new Vistoria
            {
                Id = vistoriaInicial != null ? vistoriaInicial.Id : Guid.NewGuid().ToString(),
                DataVistoria = dataVistoria,
                AlturaEstimada = alturaEstimada,
                DiametroTronco = diametroTronco,
                DiametroCopa = diametroCopa,
                Sintomas = menuSintomas.Sintomas,
                Arvore = escolha >= 0 ? context.arvores[escolha] : vistoriaInicial.Arvore,
            };

            return vistoria;
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
