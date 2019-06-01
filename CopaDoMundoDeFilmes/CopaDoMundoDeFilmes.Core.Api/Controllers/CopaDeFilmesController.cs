using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using CopaDoMundoDeFilmes.Core.Dominio.ObjetosDeValor;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundoDeFilmes.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopaDeFilmesController : ControllerBase
    {
        private readonly ICampeonato _campeonato;
        public CopaDeFilmesController(ICampeonato campeonato)
        {
            _campeonato = campeonato;
        }

        [HttpGet("obterFilmes")]
        public IEnumerable<Filme> Get(int id)
        {
            return _campeonato.ObterFilmes();
        }

        [HttpPost("gerar")]
        public ResultadoFinal Post([FromBody] IEnumerable<Filme> filmesSelecionados)
        {
            return _campeonato.GerarCampeonato(filmesSelecionados.ToList());
        }

    }
}
