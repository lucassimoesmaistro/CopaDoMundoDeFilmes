using CopaDoMundoDeFilmes.Core.ServicoApp.Servicos;
using System;
using Xunit;

namespace CopaDoMundoDeFilmes.Testes
{
    public class UnitTestServicoDeAplicacao
    {
        [Fact]
        public void DeveObterListaDeFilmes()
        {
            CopaDeFilmes servico = new CopaDeFilmes();
            var lista = servico.ObterFilmes();
            Assert.NotEmpty(lista);
        }
    }
}
