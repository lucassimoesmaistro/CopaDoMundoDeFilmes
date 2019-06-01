using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using CopaDoMundoDeFilmes.Core.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.Dominio.Interfaces
{
    public interface ICampeonato
    {
        ResultadoFinal GerarCampeonato(List<Filme> filmesSelecionados);

        List<Filme> ObterFilmes();

        Filme DefinirVencedor(Filme filme1, Filme filme2);

        List<Jogo> MontarJogos(int quantidadeDeJogos, List<Filme> listaDeFilmes);

        List<Filme> RealizarFaseDejogos(List<Jogo> jogos);

        ResultadoFinal ObterResultadoDaCompeticao(List<Filme> vencedoresSemiFinal);
    }
}
