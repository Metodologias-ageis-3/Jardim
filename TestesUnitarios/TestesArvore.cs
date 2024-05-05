

using Admin_Jardim;

namespace TestesUnitarios
{
    public class TestesArvore
    {
        private List<Arvore> arvores;

        [SetUp]
        public void SetUp()
        {
            arvores = new List<Arvore>();
        }

        [Test]
        public void Adicionar_ArvoreTodosCamposPreenchidos_AdicionaArvore()
        {
            Arvore arvore = new Arvore { Id = "1", Especie = "Carvalho", Altura = 10.5, DiametroTronco = 0.8, Idade = 15 };
            arvores.Add(arvore);

            Assert.AreEqual(1, arvores.Count);
            Assert.IsTrue(arvores.Contains(arvore));
        }

        [Test]
        public void Adicionar_ArvoreCamposAusentes_ExcecaoArgumentException()
        {
            Arvore arvore = new Arvore();

            var excecao = Assert.Throws<ArgumentException>(() => arvores.Add(arvore));
            StringAssert.Contains("O ID da árvore nao pode estar vazio.", excecao.Message);
        }

        [Test]
        public void Adicionar_ArvoreValoresInvalidos_ExcecaoArgumentException()
        {
            Arvore arvore = new Arvore { Id = "1", Especie = "Carvalho", Altura = -10.5, DiametroTronco = 0.8, Idade = 15 };

            var excecao = Assert.Throws<ArgumentException>(() => arvores.Add(arvore));
            StringAssert.Contains("A altura da árvore deve ser um número positivo.", excecao.Message);
        }

        [Test]
        public void Editar_ArvoreExistente_EditaArvore()
        {
            Arvore arvore = new Arvore { Id = "1", Especie = "Carvalho", Altura = 10.5, DiametroTronco = 0.8, Idade = 15 };
            arvores.Add(arvore);

            double novaAltura = 12.0;
            arvore.Altura = novaAltura;

            Assert.AreEqual(novaAltura, arvore.Altura);
        }

        [Test]
        public void Editar_ArvoreValoresInvalidos_ExcecaoArgumentException()
        {
            Arvore arvore = new Arvore { Id = "1", Especie = "Carvalho", Altura = 10.5, DiametroTronco = 0.8, Idade = 15 };
            arvores.Add(arvore);

            double novaAltura = -12.0;
            arvore.Altura = novaAltura;

            var excecao = Assert.Throws<ArgumentException>(() => arvore.Altura = novaAltura);
            StringAssert.Contains("A altura da árvore deve ser um número positivo.", excecao.Message);
        }

        [Test]
        public void Excluir_ArvoreExistente_RemoveArvore()
        {
            Arvore arvore = new Arvore { Id = "1", Especie = "Carvalho", Altura = 10.5, DiametroTronco = 0.8, Idade = 15 };
            arvores.Add(arvore);

            arvores.Remove(arvore);

            Assert.IsEmpty(arvores);
        }

        [Test]
        public void Excluir_ArvoreInexistente_ExcecaoInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => arvores.Remove(new Arvore { Id = "999" }));
        }

        [Test]
        public void Listar_ArvoresCadastradas_RetornaListaArvores()
        {
            Arvore arvore1 = new Arvore { Id = "1", Especie = "Carvalho" };
            Arvore arvore2 = new Arvore { Id = "2", Especie = "Pinheiro" };
            arvores.Add(arvore1);
            arvores.Add(arvore2);

            CollectionAssert.AreEqual(arvores, arvores);
        }

        [Test]
        public void Listar_ArvoresNaoCadastradas_RetornaListaVazia()
        {
            CollectionAssert.IsEmpty(arvores);
        }
    }
}