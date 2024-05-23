using Admin_Jardim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TestesEquipa
    {
        private Context _context;
        [SetUp]
        public void SetUp()
        {
            _context = new Context(true);
        }

        // 5.1
        [Test]
        public void CriarEquipa_TodosCamposPreenchidos_AdicionaEquipa()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            Assert.AreEqual("Equipe A", equipa.NomeEquipa);
            Assert.AreEqual(1, equipa.Integrantes.Count);
            Assert.IsTrue(equipa.Integrantes.ContainsKey("1"));
            Assert.AreEqual("João Silva", equipa.Integrantes["1"]);
        }

        //5.2
        [Test]
        public void Adicionar_NovaEquipaVistoria_Sucesso()
        {
            Equipa equipa = new Equipa("Equipa 1", new List<(string, string)> { ("1", "João Silva") });
            _context.vistorias[1].AdicionarEquipa(equipa);

            Assert.AreEqual(equipa, _context.vistorias[1].Equipa);
        }

        // 5.3
        [Test]
        public void CriarEquipa_SemNome_ExcecaoArgumentException()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };

            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("", integrantes));
            StringAssert.Contains("O nome da equipe não pode estar vazio.", excecao.Message);
        }

        //5.4
        [Test]
        public void Adicionar_EquipaCampoNulo_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("", new List<(string, string)> { ("1", "João Silva") }));
            StringAssert.Contains("O nome da equipe não pode estar vazio.", excecao.Message);
        }

        // 5.5
        [Test]
        public void CriarEquipa_SemIntegrantes_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("Equipe A", null));
            StringAssert.Contains("A equipe deve ter pelo menos um integrante.", excecao.Message);
        }

        // 5.6
        [Test]
        public void AdicionarIntegrante_IntegranteValido_AdicionaIntegrante()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            equipa.AdicionarIntegrante("2", "Maria Souza");

            Assert.AreEqual(2, equipa.Integrantes.Count);
            Assert.IsTrue(equipa.Integrantes.ContainsKey("2"));
            Assert.AreEqual("Maria Souza", equipa.Integrantes["2"]);
        }

        // 5.7
        [Test]
        public void AdicionarIntegrante_IdDuplicado_ExcecaoArgumentException()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            var excecao = Assert.Throws<ArgumentException>(() => equipa.AdicionarIntegrante("1", "Pedro Santos"));
            StringAssert.Contains("Já existe uma pessoa com esse ID na equipe.", excecao.Message);
        }

        //5.8
        [Test]
        public void Adicionar_EquipaCampoInvalido_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("1", new List<(string, string)> { ("1", "João Silva") }));
            StringAssert.Contains("O nome da equipe não pode ser um número inteiro.", excecao.Message);
        }

        // 5.9
        [Test]
        public void RemoverIntegrante_IntegranteExistente_RemoveIntegrante()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            equipa.RemoverIntegrante("1");

            Assert.AreEqual(0, equipa.Integrantes.Count);
        }

        // 5.10
        [Test]
        public void RemoverIntegrante_IntegranteNaoExistente_ExcecaoArgumentException()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            var excecao = Assert.Throws<ArgumentException>(() => equipa.RemoverIntegrante("2"));
            StringAssert.Contains("Não existe uma pessoa com esse ID na equipe.", excecao.Message);
        }

        // 5.11
        [Test]
        public void EditarNomeEquipa_NomeValido_EditaNome()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            equipa.NomeEquipa = "Equipe B";

            Assert.AreEqual("Equipe B", equipa.NomeEquipa);
        }

        // 5.12
        [Test]
        public void EditarNomeEquipa_NomeInvalido_ExcecaoArgumentException()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            var excecao = Assert.Throws<ArgumentException>(() => equipa.NomeEquipa = "");
            StringAssert.Contains("O nome da equipe não pode estar vazio.", excecao.Message);
        }

        // 5.13
        [Test]
        public void ToString_EquipeComIntegrantes_RetornaStringCorreta()
        {
            var integrantes = new List<(string, string)>
            {
                ("1", "João Silva"),
                ("2", "Maria Souza")
            };
            Equipa equipa = new Equipa("Equipe A", integrantes);

            string resultadoEsperado = "Equipe: Equipe A\nIdentificador: " + equipa.Id + "\nIntegrantes: ID: 1, Nome: João Silva, ID: 2, Nome: Maria Souza";
            Assert.AreEqual(resultadoEsperado, equipa.ToString());
        }
    }
}
