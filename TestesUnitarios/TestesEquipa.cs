using Admin_Jardim;
using Admin_Jardim.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TestesEquipa
    {
        private List<Funcionario> funcionariosPredefinidos;

        [SetUp]
        public void SetUp()
        {
            funcionariosPredefinidos = new List<Funcionario>
            {
                new Funcionario("1", "João Silva"),
                new Funcionario("2", "Maria Souza"),
                new Funcionario("3", "Pedro Santos"),
                new Funcionario("4", "Ana Oliveira"),
                new Funcionario("5", "José Pereira"),
                new Funcionario("6", "Carla Almeida"),
                new Funcionario("7", "Antônio Lima"),
                new Funcionario("8", "Mariana Ferreira"),
                new Funcionario("9", "Carlos Rocha")
            };
        }

        // 4.1
        [Test]
        public void CriarEquipa_TodosCamposPreenchidos_CriaEquipa()
        {
            Equipa equipa = new Equipa("Equipe A", funcionariosPredefinidos);

            Assert.AreEqual("Equipe A", equipa.NomeEquipa);
            Assert.AreEqual(9, equipa.Integrantes.Count);
        }

        // 4.2
        [Test]
        public void CriarEquipa_SemIntegrantes_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("Equipe B", new List<Funcionario>()));
            StringAssert.Contains("A equipe deve ter pelo menos um integrante.", excecao.Message);
        }

        // 4.3
        [Test]
        public void AdicionarIntegrante_IntegranteValido_AdicionaIntegrante()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });
            var novoFuncionario = new Funcionario("10", "Paulo Nogueira");

            equipa.AdicionarIntegrante(novoFuncionario);

            Assert.AreEqual(2, equipa.Integrantes.Count);
            Assert.Contains(novoFuncionario, equipa.Integrantes);
        }

        // 4.4
        [Test]
        public void AdicionarIntegrante_IntegranteDuplicado_ExcecaoArgumentException()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });
            var funcionarioDuplicado = new Funcionario("1", "João Silva");

            var excecao = Assert.Throws<ArgumentException>(() => equipa.AdicionarIntegrante(funcionarioDuplicado));
            StringAssert.Contains("Já existe uma pessoa com esse ID na equipe.", excecao.Message);
        }

        // 4.5
        [Test]
        public void RemoverIntegrante_IntegranteExistente_RemoveIntegrante()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });

            equipa.RemoverIntegrante("1");

            Assert.AreEqual(0, equipa.Integrantes.Count);
        }

        // 4.6
        [Test]
        public void RemoverIntegrante_IntegranteInexistente_ExcecaoArgumentException()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });

            var excecao = Assert.Throws<ArgumentException>(() => equipa.RemoverIntegrante("999"));
            StringAssert.Contains("Não existe uma pessoa com esse ID na equipe.", excecao.Message);
        }

        // 4.7
        [Test]
        public void EditarIntegrante_NomeValido_EditaNomeIntegrante()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });

            var funcionario = equipa.Integrantes.First(f => f.Id == "1");
            funcionario.Nome = "João Pereira";

            Assert.AreEqual("João Pereira", funcionario.Nome);
        }

        // 4.8
        [Test]
        public void EditarIntegrante_NomeInvalido_ExcecaoArgumentException()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });

            var funcionario = equipa.Integrantes.First(f => f.Id == "1");

            var excecao = Assert.Throws<ArgumentException>(() => funcionario.Nome = "");
            StringAssert.Contains("O nome do funcionário não pode estar vazio.", excecao.Message);
        }

        // 4.9
        [Test]
        public void EditarNomeEquipa_NomeComMaisDe128Caracteres_ExcecaoArgumentException()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });

            var nomeLongo = new string('A', 129);
            var excecao = Assert.Throws<ArgumentException>(() => equipa.NomeEquipa = nomeLongo);
            StringAssert.Contains("O nome da equipe não pode ter mais de 128 caracteres.", excecao.Message);
        }

        // 4.10
        [Test]
        public void EditarNomeEquipa_NomeComNumeroInteiro_ExcecaoArgumentException()
        {
            Equipa equipa = new Equipa("Equipe A", new List<Funcionario> { funcionariosPredefinidos[0] });

            var excecao = Assert.Throws<ArgumentException>(() => equipa.NomeEquipa = "12345");
            StringAssert.Contains("O nome da equipe não pode ser um número inteiro.", excecao.Message);
        }
    }
}
