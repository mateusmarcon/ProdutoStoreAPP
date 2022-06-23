using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStoreApp.Models
{
    [Serializable]
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string AtivoString
        {
            get
            {
                return Ativo.ToString();
            }
            set
            {
                if (value.ToLower() == "on")
                {
                    Ativo = true;
                }
                else
                {
                    Ativo = false;
                }
            }
        }

        public bool Perecivel { get; set; }
        public string PerecivelString {
            get {
                return Perecivel.ToString();
            }
            set
            {
                if (value.ToLower() == "on")
                {
                    Perecivel = true;
                }
                else
                {
                    Perecivel = false;
                }
            }
        }
        public int CategoriaID { get; set; }
        public CategoriaProduto CategoriaProduto { get; set; }

        public Task<string> Set(Produto produto, string url, ref System.Net.HttpStatusCode status)
        {
            try
            {
                var prodJson = JsonConvert.SerializeObject(produto, Formatting.Indented);
                var request = new HttpRequestMessage();
                if (produto.Id > 0)
                {
                    request = new HttpRequestMessage(HttpMethod.Put, url + "/produto");
                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, url + "/produto");
                }
                var client = new HttpClient();
                request.Headers.Add("Accept", "*/*");
                var content = new StringContent(prodJson, Encoding.UTF8, "application/json");
                request.Content = content;

                var response = client.SendAsync(request);
                var retorno =  response.Result.Content.ReadAsStringAsync();
                status = response.Result.StatusCode;
                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public List<Produto> GetAll(string urlApi,string id="")
        {
            try
            {
                var url = urlApi + "/produto";

                if (!string.IsNullOrEmpty(id))
                    url += "?$top=1&$filter=Id eq "+ id;

                var client = new HttpClient();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Get;

                request.Headers.Add("Accept", "*/*");

                var response = client.SendAsync(request);

                var result = response.Result.Content.ReadAsStringAsync();
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<Produto>>(result.Result);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return new List<Produto>();
        }

        public Task<string> Delete(Produto produto, string url, ref System.Net.HttpStatusCode status)
        {
            try
            {

                var prodJson = JsonConvert.SerializeObject(produto, Formatting.Indented);

                var request = new HttpRequestMessage(HttpMethod.Delete, url + "/produto");

                var client = new HttpClient();
                request.Headers.Add("Accept", "*/*");
                var content = new StringContent(prodJson, Encoding.UTF8, "application/json");
                request.Content = content;

                var response = client.SendAsync(request);
                var retorno = response.Result.Content.ReadAsStringAsync();
                status = response.Result.StatusCode;
                return retorno;

            }
            catch
            {
                throw;
            }
        }
    }
}
