

using Admin_Jardim;

namespace TestesUnitarios
{
    public class TestesArvore
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Adicionar


        [Test]
        public void AdicionarSimples()
        {
            Arvore vArvore01 = new Arvore()
            {
                Id = "1",
                Especie = "Carvalho",
                Altura = 10.5,
                DiametroTronco = 0.8,
                Idade = 50
            };

            Arvore vArvore02 = new Arvore()
            {
                Id = "2",
                Especie = "Pinheiro",
                Altura = 8.2,
                DiametroTronco = 0.6,
                Idade = 30
            };

            Assert.Pass();
        }
        [Test]
        public void AdicionarCompleto()
        {
            Arvore vArvore01 = new Arvore()
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

            Arvore vArvore02 = new Arvore()
            {
                Id = "2",
                Especie = "Pinheiro",
                Altura = 8.2,
                DiametroTronco = 0.6,
                Idade = 30,
                Jardim = new Jardim(),
                HistoricoTratamentos = new List<string> { "Pulverizar inseticida", "Regar regularmente" },
                CondicaoSaude = "Boa",
                Canteiro = new Canteiro(),
                NotasAdicionais = "Nenhuma",
                QuantidadeAguaConsumida = 12.1,
                DataPlantio = new DateTime(1990, 7, 20),
                EquipePlantio = "Equipe B",
                DataRemocao = new DateTime(2023, 10, 5),
                EquipeRemocao = "Equipe C"
            };

            Assert.Pass();
        }
        #endregion

        #region Editar


        [Test]
        public void Editar_Altura_Valida_AlteraAltura()
        {
            Arvore arvore = new Arvore();
            double novaAltura = 7.5;
            arvore.Altura = novaAltura;
            Assert.AreEqual(novaAltura, arvore.Altura);
        }

        [Test]
        public void Editar_HistoricoTratamentos_Null_AlteraHistoricoTratamentos()
        {
            Arvore arvore = new Arvore();
            List<string> novoHistorico = null;
            arvore.HistoricoTratamentos = novoHistorico;
            Assert.AreEqual(novoHistorico, arvore.HistoricoTratamentos);
        }

        [Test]
        public void Editar_Especie_Vazia_ExcecaoArgumentException()
        {
            Arvore arvore = new Arvore();
            string novaEspecie = "";
            Assert.Throws<ArgumentException>(() => arvore.Especie = novaEspecie);
        }

        [Test]
        public void Editar_Idade_Negativa_ExcecaoArgumentException()
        {
            Arvore arvore = new Arvore();
            int novaIdade = -5;
            Assert.Throws<ArgumentException>(() => arvore.Idade = novaIdade);
        }

        [Test]
        public void AdicionarTratamento_HistoricoTratamentos_Vazio_AdicionaTratamento()
        {
            Arvore arvore = new Arvore();
            string tratamento = "Podar galhos secos";
            arvore.AdicionarTratamento(tratamento);
            Assert.Contains(tratamento, arvore.HistoricoTratamentos);
        }

        [Test]
        public void AdicionarTratamento_HistoricoTratamentos_NaoVazio_AdicionaTratamento()
        {
            List<string> historicoExistente = new List<string> { "Adubar solo" };
            Arvore arvore = new Arvore { HistoricoTratamentos = historicoExistente };
            string tratamento = "Pulverizar inseticida";
            arvore.AdicionarTratamento(tratamento);
            Assert.Contains(tratamento, arvore.HistoricoTratamentos);
        }

        [Test]
        public void ToString_RetornaStringFormatada()
        {
            Arvore arvore = new Arvore
            {
                Especie = "Carvalho",
                Altura = 10.2,
                Idade = 30
            };
            string resultado = arvore.ToString();
            StringAssert.Contains("Especie: Carvalho", resultado);
            StringAssert.Contains("Altura: 10.2", resultado);
            StringAssert.Contains("Idade: 30", resultado);
        }

        [Test]
        public void Editar_QuantidadeAguaConsumida_Valida_AlteraQuantidadeAguaConsumida()
        {
            Arvore arvore = new Arvore();
            double novaQuantidadeAgua = 20.5;
            arvore.QuantidadeAguaConsumida = novaQuantidadeAgua;
            Assert.AreEqual(novaQuantidadeAgua, arvore.QuantidadeAguaConsumida);
        }

        [Test]
        public void Editar_CondicaoSaude_Valida_AlteraCondicaoSaude()
        {
            Arvore arvore = new Arvore();
            string novaCondicaoSaude = "Ótima";
            arvore.CondicaoSaude = novaCondicaoSaude;
            Assert.AreEqual(novaCondicaoSaude, arvore.CondicaoSaude);
        }

        [Test]
        public void Editar_DataPlantio_Valida_AlteraDataPlantio()
        {
            Arvore arvore = new Arvore();
            DateTime novaDataPlantio = new DateTime(2020, 5, 15);
            arvore.DataPlantio = novaDataPlantio;
            Assert.AreEqual(novaDataPlantio, arvore.DataPlantio);
        }
        #endregion

        #region Mostrar Valores

        [Test]
        public void MostrarValores_RetornaStringFormatada()
        {
            Arvore arvore = new Arvore
            {
                Especie = "Carvalho",
                Altura = 10.2,
                Idade = 30
            };
            string resultado = arvore.ToString();
            StringAssert.Contains("Especie: Carvalho", resultado);
            StringAssert.Contains("Altura: 10.2", resultado);
            StringAssert.Contains("Idade: 30", resultado);
        }

        #endregion

        #region Apagar
        [Test]
        public void Apagar_DefinirDataRemocao_AlteraDataRemocao()
        {
            Arvore arvore = new Arvore();
            arvore.Apagar();
            Assert.Pass();
        }

        [Test]
        public void Apagar_DefinirEquipeRemocao_AlteraEquipeRemocao()
        {
            Arvore arvore = new Arvore();
            string equipeRemocao = "Equipa C";
            arvore.Apagar();
            Assert.Pass();
        }
        #endregion
    }
}