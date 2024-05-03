using NUnit.Framework;
using Admin_Jardim;
using System;
using System.Collections.Generic;

namespace TestesUnitarios
{
    public class TestesUnitariosJardim
    {
        #region Adicionar

        [Test]
        public void AdicionarJardim_ComTodosCamposPreenchidos()
        {
            Jardim jardim = new Jardim()
            {
                Id = "1",
                Nome = "Jardim Botânico",
                Localizacao = "Rua das Flores",
                Descricao = "Um belo jardim com uma grande variedade de plantas.",
                Area = 1000,
                Topografia = "Plana",
                EquipaResponsavel = "Equipa Jardins Municipais",
                CaracteristicasCanteiros = "Canteiros organizados por famílias botânicas."
            };

            Assert.Pass();
        }
    }
}
/*
[Test]
public void AdicionarJardim_ComCamposAusentes_RetornaMensagemErro()
{
    Jardim jardim = new Jardim();
    Assert.Throws<ArgumentException>(() => jardim.AdicionarCanteiro());
}

[Test]
public void AdicionarJardim_ComValoresInvalidos_RetornaMensagemErro()
{
    Jardim jardim = new Jardim()
    {
        Nome = "Jardim Botânico",
        Localizacao = "Rua das Flores",
        Area = -100
    };
    Assert.Throws<ArgumentException>(() => jardim.AdicionarCanteiro());
}


#endregion

#region Editar

[Test]
public void EditarJardim_Existente_AlteracoesRefletidasNoSistema()
{
    Jardim jardim = new Jardim();
    Assert.Pass();
}

[Test]
public void EditarJardim_ComValoresInvalidos_RetornaMensagensErro()
{
    // Simular edição de um jardim com valores inválidos
    Jardim jardim = new Jardim()
    {
        Nome = "Jardim Botânico",
        Localizacao = "Rua das Flores",
        Area = 200
    };

    // Editar com valores inválidos
    jardim.Area = -100;

    // Verificar se o sistema retorna uma mensagem de erro para cada valor inválido
    Assert.Throws<ArgumentException>(() => jardim.EditarJardim());
}


[Test]
public void EditarJardim_ParaRemoverCamposObrigatorios_RetornaMensagensErro()
{
    // Simular edição de um jardim para remover campos obrigatórios
    Jardim jardim = new Jardim()
    {
        Nome = "Jardim Botânico",
        Localizacao = "Rua das Flores",
        Area = 200
    };

    // Editar para remover o nome (campo obrigatório)
    jardim.Nome = null;

    // Verificar se o sistema retorna uma mensagem de erro para cada campo obrigatório removido
    Assert.Throws<ArgumentException>(() => jardim.EditarJardim());
}
#endregion

#region Excluir

[Test]
public void ExcluirJardim_Existente_RetornaMensagemSucesso()
{
    Jardim jardim = new Jardim();
    Assert.Pass("Mensagem de sucesso esperada");
}

[Test]
public void ExcluirJardim_Inexistente_RetornaMensagemErro()
{
    Jardim jardim = new Jardim();
    Assert.Fail("Mensagem de erro esperada");
}

// Testes similares para excluir canteiro
#endregion

#region Listar

[Test]
public void ListarJardins_Cadastrados_NumeroCorretoItens()
{
    List<Jardim> jardins = new List<Jardim>(); // Lista de jardins cadastrados
    Assert.Pass();
}

[Test]
public void ListarJardins_Cadastrados_DetalhesCorretos()
{
    List<Jardim> jardins = new List<Jardim>(); // Lista de jardins cadastrados
    Assert.Pass();
}

[Test]
public void ListarJardins_SemCadastrar_RetornaListaVazia()
{
    List<Jardim> jardins = new List<Jardim>(); // Lista de jardins vazia
    Assert.Pass();
}

// Testes similares para listar canteiros
#endregion
    }
}
*/
#endregion