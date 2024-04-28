using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class MenuJardim
    {
        private Context context;

        public MenuJardim( Context context = null) 
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
                Console.WriteLine("4. Deletar");
                Console.WriteLine("5. Retornar\n");

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

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void Listar()
        {
            foreach (Jardim jardim in context.jardins)
            {
                Console.WriteLine(jardim);
            }
        }

        private void Adicionar() 
        {
            context.jardins.Add(LerJardim());
            Console.WriteLine("Jardim adicionado com sucesso!");
        }

        private void Editar()
        {
            int escolha = new MenuSelecionar<Jardim>(context.jardins, j => j.Nome, "jardim").Main();

            context.jardins[escolha] = LerJardim(context.jardins[escolha]);
            Console.WriteLine("Jardim editado com sucesso!");
        }

        private void Deletar()
        {
            int escolha = new MenuSelecionar<Jardim>(context.jardins, j => j.Nome, "jardim").Main();

            context.jardins.RemoveAt(escolha);
            Console.WriteLine("Jardim removido com sucesso!");
        }

        private Jardim LerJardim(Jardim jardimInicial = null)
        {
            string nome = new MenuCampo<Jardim>("Nome", j => j.Nome, jardimInicial).Main();
            string localizacao = new MenuCampo<Jardim>("Localização", j => j.Localizacao, jardimInicial).Main();
            string descricao = new MenuCampo<Jardim>("Descrição", j => j.Descricao, jardimInicial).Main();
            double area = double.Parse(new MenuCampo<Jardim>("Área", j => j.Area.ToString(), jardimInicial).Main());
            string topografia = new MenuCampo<Jardim>("Topografia", j => j.Topografia, jardimInicial).Main(); ;
            string equipaResponsavel = new MenuCampo<Jardim>("Equipa Responsável", j => j.EquipaResponsavel, jardimInicial).Main(); ;
            string caracteristicaCanteiros = new MenuCampo<Jardim>("Característica Canteiros", j => j.CaracteristicasCanteiros, jardimInicial).Main(); ;

            Jardim jardim = new Jardim
            {
                Id = jardimInicial != null ? jardimInicial.Id : Guid.NewGuid().ToString(),
                Nome = nome,
                Localizacao = localizacao,
                Descricao = descricao,
                Area = area,
                Topografia = topografia,
                EquipaResponsavel = equipaResponsavel,
                CaracteristicasCanteiros = caracteristicaCanteiros,
            };

            return jardim;
        }
    }
}
