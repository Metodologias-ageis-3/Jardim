using Admin_Jardim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TesteEquipa
    {
        private Context _context;
        [SetUp]
        public void SetUp()
        {
            _context = new Context(true);
        }

        //5.1
        [Test]
        public void Adicionar_NovaEquipaVistoria_Sucesso() 
        {
            Equipa equipa = new Equipa("Equipa 1", new List<(string, string)> {( "1", "João Silva" )});
            _context.vistorias[1].AdicionarEquipa(equipa);

            Assert.AreEqual(equipa, _context.vistorias[1].Equipa);
        }

        [Test]
        public void Adicionar_EquipaCampoNulo_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("", new List<(string, string)> { ("1", "João Silva") }) );
            StringAssert.Contains("O nome da equipe não pode estar vazio.", excecao.Message);
        }

        [Test]
        public void Adicionar_EquipaCampoInvalido_ExcecaoArgumentException()
        {
            var excecao = Assert.Throws<ArgumentException>(() => new Equipa("1", new List<(string, string)> { ("1", "João Silva") }));
            StringAssert.Contains("O nome da equipe não pode ser um número inteiro.", excecao.Message);
        }

        
    }
}
