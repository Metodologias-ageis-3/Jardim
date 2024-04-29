﻿using System;
using System.Linq;

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
                        //Editar();
                        break;
                    case 4:
                        //Deletar();
                        break;

                    case 5:
                        return true;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
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
            Console.Write("Especie: ");
            string especie = Console.ReadLine();

            Console.Write("Altura: ");
            float altura = float.Parse(Console.ReadLine());


            Jardim jardim = null;
            do
            {
                Console.Write("Nome do Jardim: ");
                string jardimNome = Console.ReadLine();
                jardim = context.jardins.Where(j => j.Nome == jardimNome).ToList().FirstOrDefault();
                if (jardim == null)
                {
                    Console.Write("\nJardim nao existe, digite novamente.\n");
                }
            } while (jardim == null);

            Console.Write("Diamentro do tronco: ");
            float diametroTronco = float.Parse(Console.ReadLine());

            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());


            Console.Write("Historico de tratamento: ");
            string historicoTratamentos = Console.ReadLine();

            Console.Write("Condicao de saude: ");
            string condicaoSaude = Console.ReadLine();

            Canteiro canteiro = null;
            do
            {
                Console.Write("Localizacao do canteiro: ");
                string CanteiroLocalizacao = Console.ReadLine();
                canteiro = context.canteiros.Where(j => j.Localizacao == CanteiroLocalizacao).ToList().FirstOrDefault();
                if (jardim == null)
                {
                    Console.Write("\nCanteiro nao existe, digite novamente.\n");
                }
            } while (canteiro == null);

            Console.Write("Notas adicionais: ");
            string notasAdicionais = Console.ReadLine();

            Console.Write("Data de início (DD/MM/YYYY): ");
            string dataPlantio = Console.ReadLine();

            Console.Write("Equipa de Plantio: ");
            string equipePlantio = Console.ReadLine();

            Console.Write("Data de fim (DD/MM/YYYY): ");
            string dataRemocao = Console.ReadLine();

            Console.Write("Quantidade de agua consumida: ");
            float quantidadeAguaConsumida = float.Parse(Console.ReadLine());

            Console.Write("Equipa de remocao: ");
            string equipeRemocao = Console.ReadLine();

            Arvore arvore = new Arvore
            {
                Id = Guid.NewGuid().ToString(),
                Especie = especie,
                Altura = altura,
                DiametroTronco = diametroTronco,
                Idade = idade,
                Canteiro = canteiro,
                CondicaoSaude = condicaoSaude,
                NotasAdicionais = notasAdicionais,
                QuantidadeAguaConsumida = quantidadeAguaConsumida,
                EquipePlantio = equipePlantio,
                EquipeRemocao = equipeRemocao,
                DataPlantio = Convert.ToDateTime(dataPlantio)
            };

            if (dataRemocao != "")
            {
                arvore.DataRemocao = Convert.ToDateTime(dataRemocao);
            }

            arvore.HistoricoTratamentos.Add(historicoTratamentos);

            context.arvores.Add(arvore);
            Console.WriteLine("Canteiro adicionado com sucesso!");
        }
    }
}
