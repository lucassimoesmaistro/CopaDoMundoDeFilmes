using CopaDoMundoDeFilmes.Core.Dominio.Modelos;
using CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CopaDoMundoDeFilmes.Core.ServicoDeAplicacao.Servicos
{
    public class CopaDeFilmes : ICopaDeFilmes
    {
        public List<Filme> ObterFilmes()
        {
            string BaseUrl = @"https://copadosfilmes.azurewebsites.net";
            using (HttpClient cliente = new HttpClient())
            {
                List<Filme> filmes = new List<Filme>();

                cliente.BaseAddress = new Uri(BaseUrl);

                //definindo o formato dos dados no request
                MediaTypeWithQualityHeaderValue contentType = new
                    MediaTypeWithQualityHeaderValue("application/json");

                cliente.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = cliente.GetAsync("/api/filmes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var retorno = response.Content.ReadAsStringAsync().Result;
                    filmes = JsonConvert.DeserializeObject<List<Filme>>(retorno);
                }

                return filmes;
            }
        }
    }
}
