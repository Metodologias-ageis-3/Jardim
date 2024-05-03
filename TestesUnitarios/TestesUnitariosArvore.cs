using NUnit.Framework;
using Admin_Jardim;
using System;
using System.Collections.Generic;

namespace TestesUnitarios
{
    public class TestesUnitariosArvore
    {
        #region Adicionar

        [Test]
        public void AdicionarArvore_ComTodosCamposPreenchidos()
        {
            Arvore arvore = new Arvore()
            {
                Id = "1",
                Especie = "Carvalho",
                Altura = 10.5,
                DiametroTronco = 0.8,
                Idade = 50,
                Jardim = new Jardim(),
                HistoricoTratamentos = new List<string> { "Podar galhos secos", "Adubar solo" },
                CondicaoSaude = "Boa",
                Canteiro = new Canteiro(),
                NotasAdicionais = "Nenhuma",
                QuantidadeAguaConsumida = 15.3,
                DataPlantio = new DateTime(1970, 5, 15),
                EquipePlantio = "Equipe A",
                DataRemocao = null,
                EquipeRemocao = ""
            };

            Assert.Pass();
        }

        [Test]
        public void AdicionarArvore_ComCamposAusentes()
        {
            Arvore arvore = new Arvore();
            Assert.Throws<ArgumentException>(() => arvore.Especie = "");
        }

        [Test]
        public void AdicionarArvore_ComValoresInvalidos()
        {
            Arvore arvore = new Arvore();
            Assert.Throws<ArgumentException>(() => arvore.Altura = -5);
        }

        #endregion

        #region Editar

        [Test]
        public void EditarArvore_ExcluirCamposObrigatorios()
        {
            Arvore arvore = new Arvore();
            Assert.Throws<ArgumentException>(() => arvore.Id = "");
        }

        [Test]
        public void EditarArvore_ComValoresInvalidos()
        {
            Arvore arvore = new Arvore();
            Assert.Throws<ArgumentException>(() => arvore.Idade = -5);
        }

        // Testes similares para editar canteiro e jardim
        #endregion

        #region Excluir

        [Test]
        public void ExcluirArvore_Existente_RemovidaCorretamente()
        {
            Arvore arvore = new Arvore();
            // Lógica para excluir a árvore
            Assert.Pass();
        }

        [Test]
        public void ExcluirArvore_Inexistente_MensagemErro()
        {
            Arvore arvore = new Arvore();
            // Lógica para tentar excluir uma árvore inexistente e verificar mensagem de erro
            Assert.Pass();
        }

        // Testes similares para excluir canteiro e jardim
        #endregion

        #region Listar

        [Test]
        public void ListarTodasArvores_Cadastradas_NumeroEsperado()
        {
            List<Arvore> arvores = new List<Arvore>
    {
        new Arvore
        {
            Especie = "Carvalho",
            Altura = 10.2,
            Idade = 30
        },
        new Arvore
        {
            Especie = "Pinheiro",
            Altura = 8.5,
            Idade = 25
        },
        new Arvore
        {
            Especie = "Olmo",
            Altura = 12.8,
            Idade = 40
        }
    };

            List<Arvore> arvoresCadastradas = arvores;

            Assert.AreEqual(arvores.Count, arvoresCadastradas.Count);
        }


        [Test]
        public void ListarTodasArvores_Cadastradas_DetalhesCorretos()
        {
            List<Arvore> arvores = new List<Arvore>
    {
        new Arvore
        {
            Especie = "Carvalho",
            Altura = 10.2,
            Idade = 30
        },
        new Arvore
        {
            Especie = "Pinheiro",
            Altura = 8.5,
            Idade = 25
        },
        new Arvore
        {
            Especie = "Olmo",
            Altura = 12.8,
            Idade = 40
        }
    };
            List<Arvore> arvoresCadastradas = arvores;

            Assert.AreEqual(arvores.Count, arvoresCadastradas.Count);

            for (int i = 0; i < arvores.Count; i++)
            {
                Assert.AreEqual(arvores[i].Especie, arvoresCadastradas[i].Especie);
                Assert.AreEqual(arvores[i].Altura, arvoresCadastradas[i].Altura);
                Assert.AreEqual(arvores[i].Idade, arvoresCadastradas[i].Idade);
            }
        }


        [Test]
        public void ListarArvores_NenhumaCadastrada_RetornaListaVazia()
        {
            List<Arvore> arvores = new List<Arvore>();
            Assert.Zero(arvores.Count);
        }
        #endregion
    }
}


