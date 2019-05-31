using CopaDoMundoDeFilmes.Core.Dominio.Servicos;
using CopaDoMundoDeFilmes.Core.ServicoApp.Servicos;
using System;
using System.Linq;
using Xunit;

namespace CopaDoMundoDeFilmes.Testes
{
    public class UnitTestAplicacao
    {
        [Fact]
        public void DefineVencedor()
        {
            CopaDeFilmes servico = new CopaDeFilmes();
            var lista = servico.ObterFilmes();
            var filme1 = lista[0];
            var filme2 = lista[1];
            Campeonato campeonato = new Campeonato();
            var vencedor = campeonato.DefineVencedor(filme1, filme2);
            Assert.Equal(vencedor.Id, filme1.Nota > filme2.Nota ? filme1.Id : filme2.Id);
        }

        [Fact]
        public void EstruturaQuartasDeFinal()
        {
            CopaDeFilmes servico = new CopaDeFilmes();
            var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0,8);
            Campeonato campeonato = new Campeonato();
            var jogos = campeonato.MontarJogos(4, listaDeOitoFilmes);
            var listaOrdenada = listaDeOitoFilmes.OrderBy(o => o.Titulo).ToList();
            Assert.Equal(listaOrdenada[0].Id, jogos[0].Filme1.Id);
            Assert.Equal(listaOrdenada[7].Id, jogos[0].Filme2.Id);
            Assert.Equal(listaOrdenada[1].Id, jogos[1].Filme1.Id);
            Assert.Equal(listaOrdenada[6].Id, jogos[1].Filme2.Id);
            Assert.Equal(listaOrdenada[2].Id, jogos[2].Filme1.Id);
            Assert.Equal(listaOrdenada[5].Id, jogos[2].Filme2.Id);
            Assert.Equal(listaOrdenada[3].Id, jogos[3].Filme1.Id);
            Assert.Equal(listaOrdenada[4].Id, jogos[3].Filme2.Id);
        }
    }
}
