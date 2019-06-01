using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using CopaDoMundoDeFilmes.Core.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.Dominio.Servicos
{
    public class Campeonato : ICampeonato
    {
        //private readonly ICopaDeFilmes _servicoCopaDeFilmes;
        //public Campeonato(ICopaDeFilmes servicoCopaDeFilmes)
        //{
        //    _servicoCopaDeFilmes = servicoCopaDeFilmes;
        //}
        public ResultadoFinal GerarCampeonato(List<Filme> filmesSelecionados)
        {
            return new ResultadoFinal();
        }

        public List<Filme> ObterFilmes()
        {
            throw new NotImplementedException();
        }

        public Filme DefinirVencedor(Filme filme1, Filme filme2)
        {
            return filme1.Nota < filme2.Nota ? filme2 : filme1;
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

        public List<Filme> RealizarFaseDejogos(List<Jogo> jogos)
        {
            var vencedores = new List<Filme>();
            foreach(var jogo in jogos)
            {
                vencedores.Add(this.DefinirVencedor(jogo.Filme1, jogo.Filme2));
            }
            return vencedores;
        }

        public ResultadoFinal ObterResultadoDaCompeticao(List<Filme> vencedoresSemiFinal)
        {
            var campeao = this.DefinirVencedor(vencedoresSemiFinal[0], vencedoresSemiFinal[1]);
            var viceCampeao = vencedoresSemiFinal.Where(w => w.Id != campeao.Id).FirstOrDefault();
            return new ResultadoFinal(){ Campeao = campeao, ViceCampeao = viceCampeao };
        }
    }
}
