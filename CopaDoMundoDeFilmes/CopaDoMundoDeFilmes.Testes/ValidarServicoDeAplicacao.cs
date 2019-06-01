using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Servicos;
using System;
using Xunit;

namespace CopaDoMundoDeFilmes.Testes
{
    public partial class TestesDaCopaDeFilmes
    {
        public class ValidarServicoDeAplicacao
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
}
