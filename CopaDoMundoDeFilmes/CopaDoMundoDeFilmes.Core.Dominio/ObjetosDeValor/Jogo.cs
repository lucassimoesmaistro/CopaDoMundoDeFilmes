using CopaDoMundoDeFilmes.Core.Dominio.Modelos;

namespace CopaDoMundoDeFilmes.Core.Dominio.ObjetosDeValor
{
    public class Jogo
    {
        public int Numero { get; set; }
        public Filme Filme1 { get; set; }
        public Filme Filme2 { get; set; }
    }
}
