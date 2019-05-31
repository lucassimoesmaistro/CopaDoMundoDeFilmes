using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
