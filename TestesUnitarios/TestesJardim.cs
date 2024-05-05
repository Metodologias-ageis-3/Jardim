using Admin_Jardim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TestesJardim
    {
        private List<Jardim> jardins;

        [SetUp]
        public void SetUp()
        {
            jardins = new List<Jardim>();
        }
        //3.1
        [Test]
        public void Adicionar_JardimTodosCamposPreenchidos_AdicionaJardim()
        {
            Jardim jardim = new Jardim { Id = "1", Nome = "Jardim Botânico", Localizacao = "Local 1", Area = 10.5, Topografia = "Plano" };
            jardins.Add(jardim);

            Assert.AreEqual(1, jardins.Count);
            Assert.IsTrue(jardins.Contains(jardim));
        }
        //3.2
        [Test]
        public void Adicionar_JardimCamposAusentes_ExcecaoArgumentException()
        {
            Jardim jardim = new Jardim();

            var excecao = Assert.Throws<ArgumentException>(() => jardins.Add(jardim));
            StringAssert.Contains("O nome do jardim não pode estar vazio.", excecao.Message);
        }
        //3.3
        [Test]
        public void Adicionar_JardimValoresInvalidos_ExcecaoArgumentException()
        {
            Jardim jardim = new Jardim { Id = "1", Nome = "Jardim Botânico", Localizacao = "Local 1", Area = -10.5, Topografia = "Plano" };

            var excecao = Assert.Throws<ArgumentException>(() => jardins.Add(jardim));
            StringAssert.Contains("A área do jardim deve ser um número positivo.", excecao.Message);
        }
        //3.4
        [Test]
        public void Editar_JardimExistente_EditaJardim()
        {
            Jardim jardim = new Jardim { Id = "1", Nome = "Jardim Botânico", Localizacao = "Local 1", Area = 10.5, Topografia = "Plano" };
            jardins.Add(jardim);

            double novaArea = 12.0;
            jardim.Area = novaArea;

            Assert.AreEqual(novaArea, jardim.Area);
        }
        //3.5
        [Test]
        public void Editar_JardimValoresInvalidos_ExcecaoArgumentException()
        {
            Jardim jardim = new Jardim { Id = "1", Nome = "Jardim Botânico", Localizacao = "Local 1", Area = 10.5, Topografia = "Plano" };
            jardins.Add(jardim);

            double novaArea = -12.0;
            jardim.Area = novaArea;

            var excecao = Assert.Throws<ArgumentException>(() => jardim.Area = novaArea);
            StringAssert.Contains("A área do jardim deve ser um número positivo.", excecao.Message);
        }
        //3.7
        [Test]
        public void Excluir_JardimExistente_RemoveJardim()
        {
            Jardim jardim = new Jardim { Id = "1", Nome = "Jardim Botânico", Localizacao = "Local 1", Area = 10.5, Topografia = "Plano" };
            jardins.Add(jardim);

            jardins.Remove(jardim);

            Assert.IsEmpty(jardins);
        }
        //3.8
        [Test]
        public void Excluir_JardimInexistente_ExcecaoInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => jardins.Remove(new Jardim { Id = "999" }));
        }
        //3.9 e 3.10
        [Test]
        public void Listar_JardinsCadastrados_RetornaListaJardins()
        {
            Jardim jardim1 = new Jardim { Id = "1", Nome = "Jardim Botânico" };
            Jardim jardim2 = new Jardim { Id = "2", Nome = "Jardim das Rosas" };
            jardins.Add(jardim1);
            jardins.Add(jardim2);

            CollectionAssert.AreEqual(jardins, jardins);
        }
        //3.11
        [Test]
        public void Listar_JardinsNaoCadastrados_RetornaListaVazia()
        {
            CollectionAssert.IsEmpty(jardins);
        }
    }
}
