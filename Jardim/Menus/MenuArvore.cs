using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;

namespace Admin_Jardim
{
    internal class MenuArvore
    {
        private Context context;

        private Func<Arvore, string> nomeArvoreNaSelecao = (a) => {
            return $"especie                = {a.Especie}\n"
                + $"  localização            = {a.Localizacao}\n"
                + $"  localização (Jardim)   = {a.Jardim?.Localizacao}\n"
                + $"  localização (Canteiro) = {a.Canteiro?.Localizacao}\n";
        };

        public MenuArvore(Context context = null)
        {
            this.context = context;
        }

        public bool Main()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar");
                Console.WriteLine("2. Adicionar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Apagar");
                Console.WriteLine("5. Voltar\n");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Adicionar();
                        break;
                    case 3:
                        Editar();
                        break;
                    case 4:
                        Deletar();
                        break;

                    case 5:
                        return true;
                }

                Console.WriteLine("Pressione a tecla Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }


        public void Listar()
        {
            foreach (Arvore arvore in context.arvores)
            {
                Console.WriteLine(arvore);
            }
        }


        public void Adicionar() 
        {
            try {
                int escolha = new MenuSelecionar<Jardim>(context.jardins, a => a.Nome, "jardim").Main(loop: true);

                Arvore arvore = new Arvore();
                arvore.Jardim = context.jardins[escolha];

                Console.Write("Especie: ");
                arvore.Especie = Console.ReadLine();

                Console.Write("Localização: ");
                arvore.Localizacao = Console.ReadLine();

                Console.Write("Altura: ");
                arvore.Altura = float.Parse(Console.ReadLine());

                arvore.AlturaInicial = arvore.Altura;

                Console.Write("Diamentro do tronco: ");
                arvore.DiametroTronco = float.Parse(Console.ReadLine());

                arvore.DiametroTroncoInicial = arvore.DiametroTronco;

                Console.Write("Idade: ");
                arvore.Idade = int.Parse(Console.ReadLine());


                Console.Write("Historico de tratamento: ");
                arvore.HistoricoTratamentos.Add(Console.ReadLine());

                Console.Write("Condicao de saude: ");
                arvore.CondicaoSaude = Console.ReadLine();

                int canteiroEscolhido = new MenuSelecionar<Canteiro>(context.canteiros, c => c.Localizacao, "canteiro").Main(loop: true, permiteNulo: true);

                if (canteiroEscolhido != MenuSelecionar<Canteiro>.NENHUM)
                {
                    arvore.Canteiro = context.canteiros[canteiroEscolhido];
                }

                Console.Write("Notas adicionais: ");
                arvore.NotasAdicionais = Console.ReadLine();

                Console.Write("Quantidade de agua consumida: ");
                arvore.QuantidadeAguaConsumida = float.Parse(Console.ReadLine());

                Console.Write("Data de início (DD/MM/YYYY): ");
                arvore.DataPlantio = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Equipa de Plantio: ");
                arvore.EquipePlantio = Console.ReadLine();

                Console.Write("Data de fim (DD/MM/YYYY): ");
                if(Console.ReadLine() != "")
                {
                    arvore.DataRemocao = Convert.ToDateTime(Console.ReadLine());
                }

                Console.Write("Equipa de remocao: ");
                arvore.EquipeRemocao = Console.ReadLine();

                IEnumerable<Arvore> mesmaLocalizacao = context.arvores.Where(j => j.Localizacao.ToLower() == arvore.Localizacao.ToLower());

                if (mesmaLocalizacao.Count() > 0)
                    throw new ArgumentException("Já existe um jardim com esta localização.");

                if (arvore.Canteiro != null) 
                { 
                    context.AdicionarArvoreCanteiro(arvore); 
                }
                else 
                { 
                    context.AdicionarArvoreJardim(arvore); 
                }

                Console.WriteLine("Arvore adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Deletar()
        {
            int escolha = new MenuSelecionar<Arvore>(context.arvores, nomeArvoreNaSelecao, "arvore").Main(loop: true);
            context.arvores.RemoveAt(escolha);

            Console.WriteLine("Arvore removida com sucesso!");
        }

        private void Editar()
        {
            try
            {
                int escolha = new MenuSelecionar<Arvore>(context.arvores, nomeArvoreNaSelecao, "arvore").Main(loop: true);

                Arvore arvore = new Arvore();

                Console.Write("Especie: ");
                arvore.Especie = Console.ReadLine();

                Console.Write("Localização: ");
                arvore.Localizacao = Console.ReadLine();

                Console.Write("Altura: ");
                arvore.Altura = float.Parse(Console.ReadLine());

                Console.Write("Altura Inicial: ");
                arvore.AlturaInicial = float.Parse(Console.ReadLine());

                Console.Write("Diamentro do tronco: ");
                arvore.DiametroTronco = float.Parse(Console.ReadLine());

                Console.Write("Diamentro do tronco inicial: ");
                arvore.DiametroTroncoInicial = float.Parse(Console.ReadLine());

                Console.Write("Idade: ");
                arvore.Idade = int.Parse(Console.ReadLine());

                Console.Write("Historico de tratamento: ");
                arvore.HistoricoTratamentos.Add(Console.ReadLine());

                Console.Write("Condicao de saude: ");
                arvore.CondicaoSaude = Console.ReadLine();

                int escolhaCanteiro = new MenuSelecionar<Canteiro>(context.canteiros, a => a.Localizacao, "canteiro").Main(loop: true, permiteNulo: true);

                if (escolhaCanteiro != MenuSelecionar<Canteiro>.NENHUM)
                {
                    arvore.Canteiro = context.canteiros[escolhaCanteiro];
                    arvore.Jardim = arvore.Canteiro.Jardim;
                }
                else
                {
                    int escolhaJardim = new MenuSelecionar<Jardim>(context.jardins, a => a.Nome, "jardim").Main(loop: true);
                    arvore.Jardim = context.jardins[escolhaJardim];
                }


                Console.Write("Notas adicionais: ");
                arvore.NotasAdicionais = Console.ReadLine();

                Console.Write("Quantidade de agua consumida: ");
                arvore.QuantidadeAguaConsumida = float.Parse(Console.ReadLine());

                Console.Write("Data de início (DD/MM/YYYY): ");
                arvore.DataPlantio = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Equipa de Plantio: ");
                arvore.EquipePlantio = Console.ReadLine();

                Console.Write("Data de fim (DD/MM/YYYY): ");
                string dataRemocao = Console.ReadLine();
                if (dataRemocao != "")
                {
                    arvore.DataRemocao = Convert.ToDateTime(dataRemocao);
                }

                Console.Write("Equipa de remocao: ");
                arvore.EquipeRemocao = Console.ReadLine();

                IEnumerable<Arvore> mesmaLocalizacao = context.arvores.Where(j => j.Localizacao.ToLower() == arvore.Localizacao.ToLower());

                if (mesmaLocalizacao.Count() > 0)
                    throw new ArgumentException("Já existe um jardim com esta localização.");

                context.EditarArvore(context.arvores[escolha], arvore);

                Console.WriteLine("Arvore editado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
