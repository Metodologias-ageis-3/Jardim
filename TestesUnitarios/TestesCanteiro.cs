using Admin_Jardim;

namespace TestesUnitarios
{
    internal class TestesCanteiro
    {
        [Test]
        public void AdicionarArvore_AdicionaArvore()
        {
            Canteiro canteiro = new Canteiro();
            Arvore arvore = new Arvore();
            canteiro.AdicionarArvore(arvore);
            Assert.Contains(arvore, canteiro.ListarArvoresExistentes());
        }

        [Test]
        public void Editar_Localizacao_Valida_AlteraLocalizacao()
        {
            Canteiro canteiro = new Canteiro();
            string novaLocalizacao = "Área de teste";
            canteiro.Localizacao = novaLocalizacao;
            Assert.AreEqual(novaLocalizacao, canteiro.Localizacao);
        }

        [Test]
        public void Editar_AreaSemeada_MaiorQueAreaTotal_ExcecaoArgumentException()
        {
            Canteiro canteiro = new Canteiro();
            float areaTotal = 20.0f;
            canteiro.Area = areaTotal;
            Assert.Throws<ArgumentException>(() => canteiro.AreaSemeada = 25.0f);
        }

        [Test]
        public void Editar_ComposicaoCanteiro_Valida_AlteraComposicaoCanteiro()
        {
            Canteiro canteiro = new Canteiro();
            string novaComposicao = "Solo fértil";
            canteiro.ComposicaoCanteiro = novaComposicao;
            Assert.AreEqual(novaComposicao, canteiro.ComposicaoCanteiro);
        }

        [Test]
        public void Eliminar_RemoverArvore_AlteraDataRemocaoEEquipeRemocao()
        {
            Canteiro canteiro = new Canteiro();
            Arvore arvore = new Arvore();
            string equipe = "Equipe A";
            bool removido = canteiro.RemoverArvore(arvore, equipe);
            Assert.IsTrue(removido);
            Assert.IsNotNull(arvore.DataRemocao);
            Assert.AreEqual(equipe, arvore.EquipeRemocao);
        }

        [Test]
        public void Mostrar_RetornaStringFormatada()
        {
            Canteiro canteiro = new Canteiro
            {
                Localizacao = "Área de Teste",
                Jardim = new Jardim { Nome = "Jardim Principal" },
                Area = 25.3f,
                AreaSemeada = 15.5f
            };
            string resultado = canteiro.ToString();
            StringAssert.Contains("Localização: Área de Teste", resultado);
            StringAssert.Contains("Jardim: Jardim Principal", resultado);
            StringAssert.Contains("Area: 25.3", resultado);
            StringAssert.Contains("Area semeada: 15.5", resultado);
        }
    }
}
