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
            try
            {
                TempData["Categorias"] = catProduto.GetAll(urlApi);
                TempData["Produtos"] = produto.GetAll(urlApi);
                TempData["Erros"] = string.Empty;
            }catch(Exception ex)
            {
                TempData["Erros"] = ex.Message;
                TempData["Categorias"] = new List<CategoriaProduto>();
                TempData["Produtos"] =   new List<Produto>();

            }
            TempData["UrlApi"] = urlApi;

            return View();
        }

        public ActionResult _List()
        {
            var produto = new Produto();
            TempData["Produtos"] = produto.GetAll(urlApi);

            return PartialView("_List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Set(Produto produto)
        {
            try
            {
                var status = new System.Net.HttpStatusCode();
                var retorno = produto.Set(produto, urlApi, ref status);
                if (status == System.Net.HttpStatusCode.OK)
                {
                    JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    return this.Ok(JsonConvert.DeserializeObject<Produto>(retorno.Result));

                }
                return BadRequest("Não foi possível gravar os dados. Retorno: " + retorno.Result);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível gravar os dados. Erro: "+ ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Delete([FromBody] Produto produto)
        {
            try
            {
                var status = new System.Net.HttpStatusCode();
                var retorno = produto.Delete(produto, urlApi, ref status);
                if (status == System.Net.HttpStatusCode.OK)
                {
                    JsonConvert.DeserializeObject<Object>(retorno.Result);
                    return this.Ok(JsonConvert.DeserializeObject<Produto>(retorno.Result));
                }
                return BadRequest("Registro não foi deletado, retorno: " + retorno.Result);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi deletar os dados. Erro: "+ ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            var produto = new Produto();
            var lProduto = produto.GetAll(urlApi, Id.ToString());
            if (lProduto.Count > 0)
            {
                return this.Ok( JsonConvert.SerializeObject(lProduto.First(), Formatting.Indented));
            }
            
            return BadRequest("Não foi possível encontrar o registro");
            
        }

    }
}
