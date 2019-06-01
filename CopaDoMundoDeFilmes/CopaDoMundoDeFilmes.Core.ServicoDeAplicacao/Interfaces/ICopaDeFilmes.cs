using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Interfaces
{
    public interface ICopaDeFilmes
    {
        List<Filme> ObterFilmes();
    }
}
