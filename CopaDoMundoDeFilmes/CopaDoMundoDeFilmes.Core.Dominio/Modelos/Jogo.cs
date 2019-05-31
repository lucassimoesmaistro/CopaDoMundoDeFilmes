using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDoMundoDeFilmes.Core.Dominio.Modelos
{
    public class Jogo
    {
        public int Numero { get; set; }
        public Filme Filme1 { get; set; }
        public Filme Filme2 { get; set; }
    }
}
