using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProdutoStoreApp.Models
{
    public class CategoriaProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public List<CategoriaProduto> GetAll(string urlApi) {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlApi+"/categoriaproduto");
                request.Method = HttpMethod.Get;

                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.com)");

                var response = client.SendAsync(request);

                var result = response.Result.Content.ReadAsStringAsync();
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<CategoriaProduto>>(result.Result);

                }
            }
            catch(Exception ex)
            {

            }
            return new List<CategoriaProduto>();
        }

    }
}
