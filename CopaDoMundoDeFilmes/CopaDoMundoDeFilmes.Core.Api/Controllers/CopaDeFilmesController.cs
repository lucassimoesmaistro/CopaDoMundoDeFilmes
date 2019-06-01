using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.Core.Dominio.Interfaces;
using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<Filme> Get()
        {
            return _campeonato.ObterFilmes();
        }

        // POST: api/CopaDeFilmes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CopaDeFilmes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
