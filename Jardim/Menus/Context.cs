using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Admin_Jardim
{
    public class Context
    {
        public List<Jardim> jardins;
        public List<Canteiro> canteiros;
        public List<Arvore> arvores;
        public List<Vistoria> vistorias;
        public List<Equipa> equipas;

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
            equipas = new List<Equipa>();
        }

        private void Populate()
        {
            equipas = new List<Equipa>
            {
                new Equipa("Equipa 1", Equipa.PessoasPredefinidas.Take(3).ToList()),
                new Equipa("Equipa 2", Equipa.PessoasPredefinidas.Skip(3).Take(3).ToList())
            };

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
                },

                new Arvore {
                    Id = Guid.NewGuid().ToString(),
                    Especie = "teste2",
                    Altura = 5,
                    DiametroTronco = 5,
                    Idade = 5,
                    Canteiro = canteiros[1],
                    CondicaoSaude = "teste2",
                    NotasAdicionais = "",
                    QuantidadeAguaConsumida = 5,
                    EquipePlantio = "azul",
                    EquipeRemocao = "",
                    DataPlantio = Convert.ToDateTime("12/05/1982"),
                    Localizacao = "111"
                }
            };
            vistorias = new List<Vistoria> { 
                new Vistoria
                {
                    Id = Guid.NewGuid().ToString(),
                    DataVistoria = Convert.ToDateTime("12/05/2023"),
                    AlturaEstimada = 10,
                    DiametroCopa = 10,
                    DiametroTronco = 10,
                    Sintomas = new Dictionary<string, int> { 
                        { Vistoria.SINTOMAS[0], 2 },
                        { Vistoria.SINTOMAS[1], 3 },
                    },
                    Arvore = arvores[0]
                },

                new Vistoria
                {
                    Id = Guid.NewGuid().ToString(),
                    DataVistoria = Convert.ToDateTime("12/05/2025"),
                    AlturaEstimada = 11,
                    DiametroCopa = 12,
                    DiametroTronco = 12,
                    Sintomas = new Dictionary<string, int> {
                        { Vistoria.SINTOMAS[0], 3 },
                        { Vistoria.SINTOMAS[1], 1 },
                    },
                    Arvore = arvores[0]
                },

                new Vistoria
                {
                    Id = Guid.NewGuid().ToString(),
                    DataVistoria = Convert.ToDateTime("12/05/2025"),
                    AlturaEstimada = 11,
                    DiametroCopa = 12,
                    DiametroTronco = 12,
                    Sintomas = new Dictionary<string, int> {
                        { Vistoria.SINTOMAS[0], 3 },
                    },
                    Arvore = arvores[1]
                }
            };

            canteiros[1].AdicionarArvore(arvores[0]);
            jardins[0].AdicionarCanteiro(canteiros[0]);
            jardins[1].AdicionarCanteiro(canteiros[1]);
            jardins[2].AdicionarCanteiro(canteiros[2]);
            arvores[0].AdicionarVistoria(vistorias[0]);
            arvores[0].AdicionarVistoria(vistorias[1]);
            arvores[1].AdicionarVistoria(vistorias[2]);
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
            vistoria.Arvore.AdicionarVistoria(vistoria);
            AtualizaDadosArvoreComBaseNaVistoriaMaisRecente(vistoria.Arvore);
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

        public void AtualizaDadosArvoreComBaseNaVistoriaMaisRecente(Arvore arvore)
        {
            Vistoria vistoriaRecente = arvore.Vistorias.OrderBy(x => x.DataVistoria).FirstOrDefault();
            vistoriaRecente.Arvore.Altura= vistoriaRecente.AlturaEstimada;
            vistoriaRecente.Arvore.DiametroTronco = vistoriaRecente.DiametroTronco;
        }

        public void EditarVistoria(Vistoria vistoriaNova)
        {
            Vistoria vistoriaOriginal = vistorias.Where(t => t.Id == vistoriaNova.Id).First();
            DeleteVistoria(vistoriaOriginal);
            AdicionarVistoria(vistoriaNova);
            AtualizaDadosArvoreComBaseNaVistoriaMaisRecente(vistoriaNova.Arvore);
        }

        public void DeleteVistoria(Vistoria vistoria)
        {
            vistoria.Arvore.Vistorias.Remove(vistoria);
            vistorias.Remove(vistoria);
            AtualizaDadosArvoreComBaseNaVistoriaMaisRecente(vistoria.Arvore);
        }
    }
}
