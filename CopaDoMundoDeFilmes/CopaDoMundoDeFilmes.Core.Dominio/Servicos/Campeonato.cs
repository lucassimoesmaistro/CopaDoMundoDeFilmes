using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.Dominio.Servicos
{
    public class Campeonato : ICampeonato
    {
        public List<Filme> GerarCampeonato(List<Filme> filmesSelecionados)
        {
            throw new NotImplementedException();
        }

        public List<Filme> ObterFilmes()
        {
            throw new NotImplementedException();
        }

        public Filme DefineVencedor(Filme filme1, Filme filme2)
        {
            return filme1.Nota > filme2.Nota ? filme1 : filme2;
        }

        public List<Jogo> MontarJogos(int quantidadeDeJogos, List<Filme> listaDeFilmes)
        {
            List<Jogo> jogos = new List<Jogo>();
            var listaOrdenada = listaDeFilmes.OrderBy(o => o.Titulo);
            for (int jogo=0; jogo <= quantidadeDeJogos-1; jogo++)
            {
                jogos.Add(new Jogo { Numero = jogo, Filme1 = listaOrdenada.ElementAt(jogo), Filme2 = listaOrdenada.ElementAt(listaOrdenada.Count() - 1 - jogo) });
            }
            return jogos;
        }
    }
}
