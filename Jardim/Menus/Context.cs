using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Admin_Jardim
{
    internal class Context
    {
        public List<Jardim> jardins;
        public List<Canteiro> canteiros;
        public List<Arvore> arvores;
        public List<Vistoria> vistorias;

        public Context(bool populate = false)
        {
            if (populate)
            {
                Populate();
                return;
            }

            jardins = new List<Jardim>();
            canteiros = new List<Canteiro>();
            arvores = new List<Arvore>();
            vistorias = new List<Vistoria>();
        }

        private void Populate()
        {
            jardins = new List<Jardim>
            {
                new Jardim {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Jardim da cordoaria",
                    Localizacao = "Porto",
                },
                new Jardim {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Jardins do palácio de cristal",
                    Localizacao = "Porto",
                },
                new Jardim {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Jardins de Majorelle",
                    Localizacao = "Marrakesh",
                },
            };
            canteiros = new List<Canteiro>
            {
                new Canteiro{
                    Id = Guid.NewGuid().ToString(),
                    Localizacao = "Entrada",
                    Jardim = jardins[0],
                    ComposicaoCanteiro = "",
                    Area = 4,
                    AreaSemeada = 3
                },
                new Canteiro{
                    Id = Guid.NewGuid().ToString(),
                    Localizacao = "Estacionamento",
                    Jardim = jardins[1],
                    ComposicaoCanteiro = "",
                    Area = 10,
                    AreaSemeada = 3
                },
                new Canteiro{
                    Id = Guid.NewGuid().ToString(),
                    Localizacao = "Central",
                    Jardim = jardins[2],
                    ComposicaoCanteiro = "",
                    Area = 20,
                    AreaSemeada = 15
                }
            };
            arvores = new List<Arvore>
            {
                new Arvore {
                    Id = Guid.NewGuid().ToString(),
                    Especie = "teste",
                    Altura = 4,
                    DiametroTronco = 4,
                    Idade = 4,
                    Canteiro = canteiros[1],
                    CondicaoSaude = "teste",
                    NotasAdicionais = "",
                    QuantidadeAguaConsumida = 5,
                    EquipePlantio = "vermelha",
                    EquipeRemocao = "",
                    DataPlantio = Convert.ToDateTime("12/05/2023"),
                    Localizacao = "123"
                }
            };
            vistorias = new List<Vistoria>();

            canteiros[1].AdicionarArvore(arvores[0]);
            jardins[0].AdicionarCanteiro(canteiros[0]);
            jardins[1].AdicionarCanteiro(canteiros[1]);
            jardins[2].AdicionarCanteiro(canteiros[2]);
        }

        public void AdicionarArvoreCanteiro(Arvore arvore)
        {
            arvores.Add(arvore);
            arvore.Canteiro.AdicionarArvore(arvore);
        }

        public void AdicionarCanteiroJardim(Canteiro canteiro)
        {
            canteiros.Add(canteiro);
            canteiro.Jardim.AdicionarCanteiro(canteiro);
        }
        public void AdicionarArvoreJardim(Arvore arvore)
        {
            arvores.Add(arvore);
            arvore.Jardim.AdicionarArvore(arvore);
        }

        public void AdicionarVistoria(Vistoria vistoria)
        {
            vistorias.Add(vistoria);
        }

        public void EditarArvore(Arvore arvore, Arvore arvoreNova) { 
            if(arvore.Canteiro != null)
            {
                var canteiro = arvore.Canteiro;
                canteiro.DeleteArvore(arvore);
                canteiro.AdicionarArvore(arvoreNova);
            }
            else
            {
                var jardim = arvore.Jardim;
                jardim.DeleteArvore(arvore);
                jardim.AdicionarArvore(arvoreNova);
            }
            arvores.Remove(arvore);
            arvores.Add(arvoreNova);
        }
    }
}
