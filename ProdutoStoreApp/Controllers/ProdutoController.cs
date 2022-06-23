using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProdutoStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private IConfiguration configuration;
        private string urlApi;


        public ProdutoController(IConfiguration iConfiguration)
        {
            configuration = iConfiguration;
            urlApi = configuration.GetSection("Configs").GetValue("UrlApi", "");
    }

        public IActionResult Index()
        {
            var catProduto = new CategoriaProduto();
            var produto = new Produto();
            TempData["Categorias"] = catProduto.GetAll(urlApi);
            TempData["Produtos"] = produto.GetAll(urlApi);
            TempData["UrlApi"] = urlApi;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Set(Produto produto)
        {
            try
            {
                var retorno = produto.Set(produto, urlApi);
                JsonConvert.DeserializeObject<Produto>(retorno.Result);
                return this.Ok(JsonConvert.DeserializeObject<Produto>(retorno.Result));
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível gravar os dados");
            }

        }

        [HttpPost]
        public IActionResult Delete([FromBody] Produto produto)
        {
            try
            {
                var retorno = produto.Delete(produto, urlApi);
                JsonConvert.DeserializeObject<Object>(retorno.Result);
                return this.Ok(JsonConvert.DeserializeObject<Produto>(retorno.Result));
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível gravar os dados");
            }

        }
    }
}
