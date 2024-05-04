using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;

namespace Admin_Jardim
{
    internal class MenuArvore
    {
        private Context context;

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
                int escolha = -1;
                while (escolha == -1)
                {
                    int selecionado = new MenuSelecionar<Jardim>(context.jardins, a => a.Nome, "jardim").Main();
                    if (selecionado < context.jardins.Count)
                    {
                        escolha = selecionado;
                    }
                    else { Console.WriteLine("Essa opcao nao existe, escolha novamente"); }
                }

                Arvore arvore = new Arvore();
                arvore.Jardim = context.jardins[escolha];

                Console.Write("Especie: ");
                arvore.Especie = Console.ReadLine();

                Console.Write("Altura: ");
                arvore.Altura = float.Parse(Console.ReadLine());

                Console.Write("Diamentro do tronco: ");
                arvore.DiametroTronco = float.Parse(Console.ReadLine());

                Console.Write("Idade: ");
                arvore.Idade = int.Parse(Console.ReadLine());


                Console.Write("Historico de tratamento: ");
                arvore.HistoricoTratamentos.Add(Console.ReadLine());

                Console.Write("Condicao de saude: ");
                arvore.CondicaoSaude = Console.ReadLine();


                Canteiro canteiro = null;
                while (true)
                {
                    Console.Write("Nome do canteiro (deixe em branco se nao houver canteiro): ");
                    string canteiroLocalizacao = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(canteiroLocalizacao))
                    {
                        break;
                    }

                    canteiro = context.canteiros.Where(j => j.Localizacao == canteiroLocalizacao).ToList().FirstOrDefault();


                    if (canteiro == null)
                    {
                        Console.Write("\nCanteiro nao existe, digite novamente ou deixe em branco se nao houver canteiro.\n");
                    }
                    else
                    {
                        break;
                    }
                }
                arvore.Canteiro = canteiro;


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

                if (canteiro != null) { context.AdicionarArvoreCanteiro(arvore); }
                else { context.AdicionarArvoreJardim(arvore); }

                Console.WriteLine("Arvore adicionado com sucesso!");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void Deletar()
        {
            int escolha = -1;
            while (escolha == -1)
            {
                int selecionado = new MenuSelecionar<Arvore>(context.arvores, a => a.Especie + " - " + a.Jardim.Localizacao, "arvore").Main();
                if (selecionado < context.arvores.Count)
                {
                    escolha = selecionado;
                }
                else { Console.WriteLine("Essa opcao nao existe, escolha novamente"); }
                
            }
            context.arvores.RemoveAt(escolha);
            Console.WriteLine("Arvore removido com sucesso!");
        }

        private void Editar()
        {
            try
            {
                int escolha = -1;
                while (escolha == -1)
                {
                    int selecionado = new MenuSelecionar<Arvore>(context.arvores, a => a.Especie + " - " + a.Canteiro.Localizacao, "arvore").Main();
                    if (selecionado < context.arvores.Count)
                    {
                        escolha = selecionado;
                    }
                    else { Console.WriteLine("Essa opcao nao existe, escolha novamente"); }

                }
                Arvore arvore = new Arvore();


                Console.Write("Especie: ");
                arvore.Especie = Console.ReadLine();

                Console.Write("Altura: ");
                arvore.Altura = float.Parse(Console.ReadLine());

                Console.Write("Diamentro do tronco: ");
                arvore.DiametroTronco = float.Parse(Console.ReadLine());

                Console.Write("Idade: ");
                arvore.Idade = int.Parse(Console.ReadLine());


                Console.Write("Historico de tratamento: ");
                arvore.HistoricoTratamentos.Add(Console.ReadLine());

                Console.Write("Condicao de saude: ");
                arvore.CondicaoSaude = Console.ReadLine();

                int escolhaCanteiro = -1;
                while (escolhaCanteiro == -1)
                {
                    int selecionado = new MenuSelecionar<Canteiro>(context.canteiros, a => a.Localizacao, "canteiro").Main();
                    if (selecionado < context.canteiros.Count)
                    {
                        escolhaCanteiro = selecionado;
                    }
                    else { Console.WriteLine("Essa opcao nao existe, escolha novamente"); }
                }
                arvore.Canteiro = context.canteiros[escolhaCanteiro];
                if (arvore.Canteiro == null)
                {
                    int escolhaJardim = -1;
                    while (escolhaJardim == -1)
                    {
                        int selecionado = new MenuSelecionar<Jardim>(context.jardins, a => a.Nome, "jardim").Main();
                        if (selecionado < context.jardins.Count)
                        {
                            escolhaJardim = selecionado;
                        }
                        else { Console.WriteLine("Essa opcao nao existe, escolha novamente"); }
                    }
                    arvore.Jardim = context.jardins[escolhaJardim];
                }
                else
                {
                    arvore.Jardim = arvore.Canteiro.Jardim;
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
                if (Console.ReadLine() != "")
                {
                    arvore.DataRemocao = Convert.ToDateTime(Console.ReadLine());
                }

                Console.Write("Equipa de remocao: ");
                arvore.EquipeRemocao = Console.ReadLine();

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
