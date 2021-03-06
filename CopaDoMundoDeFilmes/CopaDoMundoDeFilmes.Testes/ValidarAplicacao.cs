using CopaDoMundoDeFilmes.Core.Dominio.Servicos;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Servicos;
using System;
using System.Linq;
using Xunit;

namespace CopaDoMundoDeFilmes.Testes
{
    public partial class TestesDaCopaDeFilmes
    {
        public class ValidarAplicacao
        {
            [Fact]
            public void DefineVencedor()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var lista = servico.ObterFilmes();
                var filme1 = lista[0];
                var filme2 = lista[1];
                Campeonato campeonato = new Campeonato();
                var vencedor = campeonato.DefinirVencedor(filme1, filme2);
                Assert.Equal(vencedor.Id, filme1.Nota > filme2.Nota ? filme1.Id : filme2.Id);
            }

            [Fact]
            public void EstruturaQuartasDeFinal()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 8);
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

            [Fact]
            public void EstruturaSemiFinal()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 4);
                Campeonato campeonato = new Campeonato();
                var jogos = campeonato.MontarJogos(2, listaDeOitoFilmes);
                var listaOrdenada = listaDeOitoFilmes.OrderBy(o => o.Titulo).ToList();
                Assert.Equal(listaOrdenada[0].Id, jogos[0].Filme1.Id);
                Assert.Equal(listaOrdenada[3].Id, jogos[0].Filme2.Id);
                Assert.Equal(listaOrdenada[1].Id, jogos[1].Filme1.Id);
                Assert.Equal(listaOrdenada[2].Id, jogos[1].Filme2.Id);
            }

            [Fact]
            public void EstruturaFinal()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 2);
                Campeonato campeonato = new Campeonato();
                var jogos = campeonato.MontarJogos(1, listaDeOitoFilmes);
                var listaOrdenada = listaDeOitoFilmes.OrderBy(o => o.Titulo).ToList();
                Assert.Equal(listaOrdenada[0].Id, jogos[0].Filme1.Id);
                Assert.Equal(listaOrdenada[1].Id, jogos[0].Filme2.Id);
            }

            [Fact]
            public void DefineVencedoresQuartasDeFinal()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 8);
                Campeonato campeonato = new Campeonato();
                var jogos = campeonato.MontarJogos(4, listaDeOitoFilmes);
                var vencedores = campeonato.RealizarFaseDejogos(jogos);
                Assert.Equal(4, vencedores.Count);
                Assert.Equal(campeonato.DefinirVencedor(jogos[0].Filme1, jogos[0].Filme2).Id, vencedores[0].Id);
                Assert.Equal(campeonato.DefinirVencedor(jogos[1].Filme1, jogos[1].Filme2).Id, vencedores[1].Id);
                Assert.Equal(campeonato.DefinirVencedor(jogos[2].Filme1, jogos[2].Filme2).Id, vencedores[2].Id);
                Assert.Equal(campeonato.DefinirVencedor(jogos[3].Filme1, jogos[3].Filme2).Id, vencedores[3].Id);
            }

            [Fact]
            public void DefineVencedoresSemiFinal()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 8);
                Campeonato campeonato = new Campeonato();
                var jogos = campeonato.MontarJogos(4, listaDeOitoFilmes);
                var vencedores = campeonato.RealizarFaseDejogos(jogos);

                var jogosSemiFinal = campeonato.MontarJogos(2, vencedores);

                var vencedoresSemiFinal = campeonato.RealizarFaseDejogos(jogosSemiFinal);

                Assert.Equal(2, vencedoresSemiFinal.Count);
                Assert.Equal(campeonato.DefinirVencedor(jogosSemiFinal[0].Filme1, jogosSemiFinal[0].Filme2).Id, vencedoresSemiFinal[0].Id);
                Assert.Equal(campeonato.DefinirVencedor(jogosSemiFinal[1].Filme1, jogosSemiFinal[1].Filme2).Id, vencedoresSemiFinal[1].Id);
            }


            [Fact]
            public void ObterResultadoDaCompeticao()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 8);
                Campeonato campeonato = new Campeonato();
                var jogos = campeonato.MontarJogos(4, listaDeOitoFilmes);
                var vencedores = campeonato.RealizarFaseDejogos(jogos);

                var jogosSemiFinal = campeonato.MontarJogos(2, vencedores);

                var vencedoresSemiFinal = campeonato.RealizarFaseDejogos(jogosSemiFinal);

                var resultadoDaCompeticao = campeonato.ObterResultadoDaCompeticao(vencedoresSemiFinal);

                Assert.Equal(campeonato.DefinirVencedor(vencedoresSemiFinal[0], vencedoresSemiFinal[1]).Id, resultadoDaCompeticao.Campeao.Id);
            }

            [Fact]
            public void GerarCompeticao()
            {
                CopaDeFilmes servico = new CopaDeFilmes();
                var listaDeOitoFilmes = servico.ObterFilmes().GetRange(0, 8);
                Campeonato campeonato = new Campeonato();

                var resultadoDaCompeticao = campeonato.GerarCampeonato(listaDeOitoFilmes);

                var jogos = campeonato.MontarJogos(4, listaDeOitoFilmes);

                var vencedores = campeonato.RealizarFaseDejogos(jogos);

                var jogosSemiFinal = campeonato.MontarJogos(2, vencedores);

                var vencedoresSemiFinal = campeonato.RealizarFaseDejogos(jogosSemiFinal);

                var resultadoDaCompeticaoSimulado = campeonato.ObterResultadoDaCompeticao(vencedoresSemiFinal);

                Assert.Equal(resultadoDaCompeticaoSimulado.Campeao.Id, resultadoDaCompeticao.Campeao.Id);
                Assert.Equal(resultadoDaCompeticaoSimulado.ViceCampeao.Id, resultadoDaCompeticao.ViceCampeao.Id);
            }

        }
    }
}
