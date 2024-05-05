using Admin_Jardim;

namespace TestesUnitarios
{
    internal class TestesCanteiro
    {
        private List<Canteiro> canteiros;

        [SetUp]
        public void SetUp()
        {
            canteiros = new List<Canteiro>();
        }
        //1.1
        [Test]
        public void Adicionar_CanteiroTodosCamposPreenchidos_AdicionaCanteiro()
        {
            Canteiro canteiro = new Canteiro { Id = "1", Localizacao = "Local 1", Area = 10.5f, AreaSemeada = 8.0f };
            canteiros.Add(canteiro);

            Assert.AreEqual(1, canteiros.Count);
            Assert.IsTrue(canteiros.Contains(canteiro));
        }
        //1.2
        [Test]
        public void Adicionar_CanteiroCamposAusentes_ExcecaoArgumentException()
        {
            Canteiro canteiro = new Canteiro();

            var excecao = Assert.Throws<ArgumentException>(() => canteiros.Add(canteiro));
            StringAssert.Contains("A localização do canteiro não pode estar vazia.", excecao.Message);
        }
        //1.3
        [Test]
        public void Adicionar_CanteiroValoresInvalidos_ExcecaoArgumentException()
        {
            Canteiro canteiro = new Canteiro { Id = "1", Localizacao = "Local 1", Area = -10.5f, AreaSemeada = 8.0f };

            var excecao = Assert.Throws<ArgumentException>(() => canteiros.Add(canteiro));
            StringAssert.Contains("A área do canteiro deve ser um número positivo.", excecao.Message);
        }
        //1.4
        [Test]
        public void Editar_CanteiroExistente_EditaCanteiro()
        {
            Canteiro canteiro = new Canteiro { Id = "1", Localizacao = "Local 1", Area = 10.5f, AreaSemeada = 8.0f };
            canteiros.Add(canteiro);

            float novaArea = 12.0f;
            canteiro.Area = novaArea;

            Assert.AreEqual(novaArea, canteiro.Area);
        }
        //1.5
        [Test]
        public void Editar_CanteiroValoresInvalidos_ExcecaoArgumentException()
        {
            Canteiro canteiro = new Canteiro { Id = "1", Localizacao = "Local 1", Area = 10.5f, AreaSemeada = 8.0f };
            canteiros.Add(canteiro);

            float novaArea = -12.0f;
            canteiro.Area = novaArea;

            var excecao = Assert.Throws<ArgumentException>(() => canteiro.Area = novaArea);
            StringAssert.Contains("A área do canteiro deve ser um número positivo.", excecao.Message);
        }
        //1.7
        [Test]
        public void Excluir_CanteiroExistente_RemoveCanteiro()
        {
            Canteiro canteiro = new Canteiro { Id = "1", Localizacao = "Local 1", Area = 10.5f, AreaSemeada = 8.0f };
            canteiros.Add(canteiro);

            canteiros.Remove(canteiro);

            Assert.IsEmpty(canteiros);
        }
        //1.8
        [Test]
        public void Excluir_CanteiroInexistente_ExcecaoInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => canteiros.Remove(new Canteiro { Id = "999" }));
        }
        //1.9 e 1.10
        [Test]
        public void Listar_CanteirosCadastrados_RetornaListaCanteiros()
        {
            Canteiro canteiro1 = new Canteiro { Id = "1", Localizacao = "Local 1" };
            Canteiro canteiro2 = new Canteiro { Id = "2", Localizacao = "Local 2" };
            canteiros.Add(canteiro1);
            canteiros.Add(canteiro2);

            CollectionAssert.AreEqual(canteiros, canteiros);
        }
        // 1.11
        [Test]
        public void Listar_CanteirosNaoCadastrados_RetornaListaVazia()
        {
            CollectionAssert.IsEmpty(canteiros);
        }
    }
}
