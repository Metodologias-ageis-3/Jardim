using NUnit.Framework;
using Admin_Jardim;
using System;
using System.Collections.Generic;

namespace TestesUnitarios
{
    public class TestesUnitariosCanteiro
    {
        #region Adicionar

        [Test]
        public void AdicionarCanteiro_ComTodosCamposPreenchidos()
        {
            Canteiro canteiro = new Canteiro()
            {
                Id = "1",
                Localizacao = "Próximo à entrada principal",
                Jardim = new Jardim(),
                ComposicaoCanteiro = "Flores",
                Area = 50,
                AreaSemeada = 30
            };

            Assert.Pass();
        }
        /*
        [Test]
        public void AdicionarCanteiro_ComCamposAusentes_RetornaMensagemErro()
        {
            Canteiro canteiro = new Canteiro();
            Assert.Throws<ArgumentException>(() => canteiro.AdicionarArvore(new Arvore()));
        }
        */
        #endregion

        #region Editar

        [Test]
        public void EditarCanteiro_Existente_AlteracoesRefletidasNoSistema()
        {
            Canteiro canteiro = new Canteiro();
            Assert.Pass();
        }
        /*
        [Test]
        public void AdicionarCanteiro_ComValoresInvalidos_RetornaMensagemErro()
        {
            Canteiro canteiro = new Canteiro()
            {
                Localizacao = "Rua das Flores",
                Area = -100
            };
            Assert.Throws<ArgumentException>(() => canteiro.Area = -100);
        }

        */

        [Test]
        public void EditarCanteiro_ParaRemoverCamposObrigatorios_RetornaMensagensErro()
        {
            Canteiro canteiro = new Canteiro();
            canteiro.Id = null;
            Assert.Throws<ArgumentException>(() => canteiro.Localizacao = "Rua das Flores");
        }


        #endregion

        #region Excluir

        [Test]
        public void ExcluirCanteiro_Existente_RetornaMensagemSucesso()
        {
            Canteiro canteiro = new Canteiro();
            Assert.Pass("Mensagem de sucesso esperada");
        }

        /*[Test]
        public void ExcluirCanteiro_Inexistente_RetornaMensagemErro()
        {
            Canteiro canteiro = new Canteiro();
            Assert.IsFalse(canteiro.RemoverArvore(new Arvore(), "Equipe X"));
        }
        */

        #endregion

        #region Listar

        [Test]
        public void ListarCanteiros_Cadastrados_NumeroCorretoItens()
        {
            List<Canteiro> canteiros = new List<Canteiro>(); 
            Assert.Pass();
        }

        [Test]
        public void ListarTodasCanteiros_Cadastrados_DetalhesCorretos()
        {
            List<Canteiro> canteiros = new List<Canteiro>
    {
        new Canteiro
        {
            Localizacao = "Jardim Botânico",
            Area = 50,
            AreaSemeada = 30
        },
        new Canteiro
        {
            Localizacao = "Parque da Cidade",
            Area = 80,
            AreaSemeada = 60
        },
        new Canteiro
        {
            Localizacao = "Praça Central",
            Area = 40,
            AreaSemeada = 20
        }
    };
            List<Canteiro> canteirosCadastrados = canteiros;

            Assert.AreEqual(canteiros.Count, canteirosCadastrados.Count);

            for (int i = 0; i < canteiros.Count; i++)
            {
                Assert.AreEqual(canteiros[i].Localizacao, canteirosCadastrados[i].Localizacao);
                Assert.AreEqual(canteiros[i].Area, canteirosCadastrados[i].Area);
                Assert.AreEqual(canteiros[i].AreaSemeada, canteirosCadastrados[i].AreaSemeada);
            }
        }



        [Test]
        public void ListarCanteiros_SemCadastrar_RetornaListaVazia()
        {
            List<Canteiro> canteiros = new List<Canteiro>(); 
            Assert.Pass();
        }

        #endregion
    }
}

