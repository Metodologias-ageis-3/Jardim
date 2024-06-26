﻿using Admin_Jardim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TesteVistoria
    {
        private Context _context;
        [SetUp]
        public void SetUp()
        {
            _context = new Context(true);
        }

        [Test]
        //7.1
        public void Add_VistoriaArvore2_True() {
            //prepare
            Vistoria vistoria = new Vistoria() { Arvore = new Arvore() { Id="1"}, DiametroTronco=5, AlturaEstimada=5, DiametroCopa=5, DataVistoria=DateTime.Now, Id="1" };
            //act
            _context.AdicionarVistoria(vistoria);
            //assert
            Assert.IsTrue(vistoria.Arvore.Vistorias.Contains(vistoria));
        }

        //7.2
        [Test]
        public void Adicionar_VistoriaCamposAusentes_ExcecaoArgumentException()
        {

            var excecao = Assert.Throws<ArgumentException>(() => new Vistoria() { Id=""});
            StringAssert.Contains("O ID da árvore nao pode estar vazio.", excecao.Message);
        }

        //7.3
        [Test]
        public void Adicionar_VistoriaCamposInvalidos_ExcecaoArgumentException()
        {
            //act
            var excecao = Assert.Throws<ArgumentException>(() => new Vistoria() { Arvore = new Arvore() { Id = "1" }, DiametroTronco = -5, AlturaEstimada = 5, DiametroCopa = 5, DataVistoria = DateTime.Now, Id = "1" });
            StringAssert.Contains("O diâmetro do tronco deve estar entre 0 e 30 metros.", excecao.Message);
        }

        //7.4
        [Test]
        public void Editar_VistoriaCamposValidos_Sucesso()
        {
            Vistoria vistoria = _context.vistorias[1];
            vistoria.DiametroTronco = 10;
            _context.EditarVistoria(vistoria);
            Assert.AreEqual(vistoria.DiametroTronco, _context.vistorias.Where(t => t.Id == vistoria.Id).First().DiametroTronco);
        }

        //7.5
        [Test]
        public void Editar_VistoriaCamposInvalidos_ExcecaoArgumentException()
        {
            Vistoria vistoria = _context.vistorias[1];
            var excecao = Assert.Throws<ArgumentException>(() => vistoria.DiametroTronco = -19);
            StringAssert.Contains("O diâmetro do tronco deve estar entre 0 e 30 metros.", excecao.Message);
        }

        //7.6
        [Test]
        public void Editar_VistoriaCamposAusente_ExcecaoArgumentException()
        {
            Vistoria vistoria = _context.vistorias[1];
            var excecao = Assert.Throws<ArgumentException>(() => vistoria.Id = "");
            StringAssert.Contains("O ID da árvore nao pode estar vazio.", excecao.Message);
        }


        //7.7
        [Test]
        public void Excluir_VistoriaExistente_RemoverVistoria()
        {
            Vistoria vistoria = _context.vistorias[1];
            _context.DeleteVistoria(vistoria);
            Assert.IsFalse(_context.vistorias.Contains(vistoria));
        }

        //7.8
        [Test]
        public void Excluir_VistoriaInexistente_ExcecaoArgumentException()
        {
            Vistoria vistoria = new Vistoria() { Id="5"};
            var excecao = Assert.Throws<ArgumentException>(() => _context.DeleteVistoria(vistoria));
            StringAssert.Contains("Essa opcao nao existe, escolha novamente.", excecao.Message);
        }

        //7.11
        [Test]
        public void Listar_VistoriaVazia_ExcecaoArgumentExceptio()
        {
            _context.vistorias = new List<Vistoria>();
            Assert.IsTrue(_context.vistorias.Count == 0);
        }

        //7.9 e 7.10
        [Test]
        public void Listar_VistoriasExistentes_ListaVistoria()
        {
            // Arrange
            Vistoria vistoria1 = new Vistoria() { Arvore = new Arvore() { Id = "1" }, DiametroTronco = 10, AlturaEstimada = 10, DiametroCopa = 10, DataVistoria = Convert.ToDateTime("12/05/2023"), Id = "0" };
            Vistoria vistoria2 = new Vistoria() { Arvore = new Arvore() { Id = "1" }, DiametroTronco = 10, AlturaEstimada = 10, DiametroCopa = 10, DataVistoria = Convert.ToDateTime("12/05/2023"), Id = "0" };
            _context.vistorias = new List<Vistoria>();
            _context.AdicionarVistoria(vistoria1);
            _context.AdicionarVistoria(vistoria2);

            // Act
            List<Vistoria> vistorias = _context.ListaVistoria();

            // Assert
            List<Vistoria> expectedList = new List<Vistoria> { vistoria1,vistoria2 };
            CollectionAssert.AreEqual(expectedList, vistorias);
        }
    }
}
