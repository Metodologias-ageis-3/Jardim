using Admin_Jardim.Classes;
using Admin_Jardim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TestesFuncionario
    {
        // 5.1
        [Test]
        public void CriarFuncionario_TodosCamposPreenchidos_CriaFuncionario()
        {
            Funcionario funcionario = new Funcionario("1", "João Silva");

            Assert.AreEqual("1", funcionario.Id);
            Assert.AreEqual("João Silva", funcionario.Nome);
        }

        // 5.2
        [Test]
        public void CriarFuncionario_IdVazio_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Funcionario("", "João Silva"));
            StringAssert.Contains("O ID do funcionário não pode estar vazio.", excecao.Message);
        }

        // 5.3
        [Test]
        public void CriarFuncionario_NomeVazio_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Funcionario("1", ""));
            StringAssert.Contains("O nome do funcionário não pode estar vazio.", excecao.Message);
        }

        // 5.4
        [Test]
        public void EditarIdFuncionario_IdValido_AtualizaId()
        {
            Funcionario funcionario = new Funcionario("1", "João Silva");
            funcionario.Id = "2";

            Assert.AreEqual("2", funcionario.Id);
        }

        // 5.5
        [Test]
        public void EditarIdFuncionario_IdVazio_ExcecaoArgumentException()
        {
            Funcionario funcionario = new Funcionario("1", "João Silva");

            var excecao = Assert.Throws<ArgumentException>(() => funcionario.Id = "");
            StringAssert.Contains("O ID do funcionário não pode estar vazio.", excecao.Message);
        }

        // 5.6
        [Test]
        public void EditarNomeFuncionario_NomeValido_AtualizaNome()
        {
            Funcionario funcionario = new Funcionario("1", "João Silva");
            funcionario.Nome = "João Pereira";

            Assert.AreEqual("João Pereira", funcionario.Nome);
        }

        // 5.7
        [Test]
        public void EditarNomeFuncionario_NomeVazio_ExcecaoArgumentException()
        {
            Funcionario funcionario = new Funcionario("1", "João Silva");

            var excecao = Assert.Throws<ArgumentException>(() => funcionario.Nome = "");
            StringAssert.Contains("O nome do funcionário não pode estar vazio.", excecao.Message);
        }

        // 5.8
        [Test]
        public void CriarFuncionario_IdComCaracteresEspeciais_CriaFuncionario()
        {
            Funcionario funcionario = new Funcionario("ID_123@!$", "Maria Oliveira");

            Assert.AreEqual("ID_123@!$", funcionario.Id);
            Assert.AreEqual("Maria Oliveira", funcionario.Nome);
        }

        // 5.9
        [Test]
        public void CriarFuncionario_NomeComCaracteresEspeciais_CriaFuncionario()
        {
            Funcionario funcionario = new Funcionario("2", "Maria @ Oliveira!");

            Assert.AreEqual("2", funcionario.Id);
            Assert.AreEqual("Maria @ Oliveira!", funcionario.Nome);
        }

        // 5.10
        [Test]
        public void CriarFuncionario_IdComEspacos_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Funcionario("  ", "João Silva"));
            StringAssert.Contains("O ID do funcionário não pode estar vazio.", excecao.Message);
        }

        // 5.11
        [Test]
        public void CriarFuncionario_NomeComEspacos_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Funcionario("1", "  "));
            StringAssert.Contains("O nome do funcionário não pode estar vazio.", excecao.Message);
        }
    }
}
