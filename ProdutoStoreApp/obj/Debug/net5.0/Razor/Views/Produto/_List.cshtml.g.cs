#pragma checksum "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bc1d1442fcc7af7fa6c46bf27311d4b0f31558e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto__List), @"mvc.1.0.view", @"/Views/Produto/_List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\_ViewImports.cshtml"
using ProdutoStoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\_ViewImports.cshtml"
using ProdutoStoreApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bc1d1442fcc7af7fa6c46bf27311d4b0f31558e", @"/Views/Produto/_List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00660a29bafffcf140dc5698c920f693699dabfd", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto__List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table id=""ItemsTable"" class=""table table-striped"">
    <thead>
        <tr>
            <th scope=""col"">Id</th>
            <th scope=""col"">Nome</th>
            <th scope=""col"">Descricao</th>
            <th scope=""col"">Categoria do Produto</th>
            <th scope=""col"">Ativo</th>
            <th scope=""col"">Perecível</th>
            <th scope=""col"">Ação</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 14 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
         foreach (var produto in (List<Produto>)TempData["Produtos"])
        {
            var ativo = produto.Ativo ? "Ativo" : "Inativo";
            var perecivel = produto.Perecivel ? "Sim" : "Não";
            var idTr = "idTr" + produto.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", " id=\"", 688, "\"", 698, 1);
#nullable restore
#line 19 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
WriteAttributeValue("", 693, idTr, 693, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>");
#nullable restore
#line 20 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
               Write(produto.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
               Write(produto.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
               Write(produto.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
               Write(produto.CategoriaProduto.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
               Write(ativo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
               Write(perecivel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 993, "\"", 1025, 3);
            WriteAttributeValue("", 1003, "Atualizar(", 1003, 10, true);
#nullable restore
#line 26 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
WriteAttributeValue("", 1013, produto.Id, 1013, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1024, ")", 1024, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Atualizar</button><button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1090, "\"", 1120, 3);
            WriteAttributeValue("", 1100, "Excluir(", 1100, 8, true);
#nullable restore
#line 26 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
WriteAttributeValue("", 1108, produto.Id, 1108, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1119, ")", 1119, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Deletar</button></td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "C:\Users\mateu\source\repos\ProdutoStoreAPP\ProdutoStoreApp\Views\Produto\_List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
