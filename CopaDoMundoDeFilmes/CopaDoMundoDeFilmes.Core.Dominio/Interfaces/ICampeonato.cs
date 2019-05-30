using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.Dominio.Interfaces
{
    public interface ICampeonato
    {
        List<Filme> ObterFilmes();

        List<Filme> GerarCampeonato(List<Filme> filmesSelecionados);
    }
}
