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
        [Test]
        public void AdicionarCanteiro_AdicionaCanteiro()
        {
            Jardim jardim = new Jardim();
            Canteiro canteiro = new Canteiro();
            jardim.AdicionarCanteiro(canteiro);
            Assert.Contains(canteiro, jardim.MostrarCanteiros());
        }

        [Test]
        public void Editar_Nome_Valido_AlteraNome()
        {
            Jardim jardim = new Jardim();
            string novoNome = "Jardim Botânico";
            jardim.Nome = novoNome;
            Assert.AreEqual(novoNome, jardim.Nome);
        }

        [Test]
        public void Editar_Area_Negativa_ExcecaoArgumentException()
        {
            Jardim jardim = new Jardim();
            Assert.Throws<ArgumentException>(() => jardim.Area = -50);
        }

        [Test]
        public void Editar_Descricao_ExcedeLimiteCaracteres_ExcecaoArgumentException()
        {
            Jardim jardim = new Jardim();
            string descricaoLonga = new string('a', 600);
            Assert.Throws<ArgumentException>(() => jardim.Descricao = descricaoLonga);
        }

        [Test]
        public void Editar_Topografia_Valida_AlteraTopografia()
        {
            Jardim jardim = new Jardim();
            string novaTopografia = "Plana";
            jardim.Topografia = novaTopografia;
            Assert.AreEqual(novaTopografia, jardim.Topografia);
        }

        [Test]
        public void Editar_EquipaResponsavel_Valida_AlteraEquipaResponsavel()
        {
            Jardim jardim = new Jardim();
            string novaEquipa = "Equipe de jardinagem";
            jardim.EquipaResponsavel = novaEquipa;
            Assert.AreEqual(novaEquipa, jardim.EquipaResponsavel);
        }

        [Test]
        public void Editar_CaracteristicasCanteiros_Valida_AlteraCaracteristicasCanteiros()
        {
            Jardim jardim = new Jardim();
            string novasCaracteristicas = "Canteiros bem drenados";
            jardim.CaracteristicasCanteiros = novasCaracteristicas;
            Assert.AreEqual(novasCaracteristicas, jardim.CaracteristicasCanteiros);
        }

        [Test]
        public void Mostrar_RetornaStringFormatada()
        {
            Jardim jardim = new Jardim
            {
                Nome = "Jardim Botânico",
                Localizacao = "Avenida Central",
                Descricao = "Um lindo jardim botânico com diversas espécies de plantas.",
                Area = 1500,
                Topografia = "Plana",
                EquipaResponsavel = "Equipe de Jardinagem ABC",
                CaracteristicasCanteiros = "Canteiros bem drenados"
            };
            string resultado = jardim.ToString();
            StringAssert.Contains("Nome: Jardim Botânico", resultado);
            StringAssert.Contains("Localização: Avenida Central", resultado);
            StringAssert.Contains("Descricao: Um lindo jardim botânico com diversas espécies de plantas.", resultado);
            StringAssert.Contains("Area: 1500", resultado);
            StringAssert.Contains("Topografia: Plana", resultado);
            StringAssert.Contains("Equipa Responsável: Equipe de Jardinagem ABC", resultado);
            StringAssert.Contains("Características canteiros: Canteiros bem drenados", resultado);
        }
    }
}
