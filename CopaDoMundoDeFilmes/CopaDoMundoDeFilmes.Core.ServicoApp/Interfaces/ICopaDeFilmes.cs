using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.ServicoApp.Interfaces
{
    public interface ICopaDeFilmes
    {
        List<Filme> ObterFilmes();
    }
}
