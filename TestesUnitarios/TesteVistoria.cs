using Admin_Jardim;
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

    }
}
