#pragma checksum "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "932bae75eca6f6eaac6742ea8cffa356bf871b39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carrinho_Carrinho), @"mvc.1.0.view", @"/Views/Carrinho/Carrinho.cshtml")]
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
#line 1 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\_ViewImports.cshtml"
using PIE4_VanessaCampos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\_ViewImports.cshtml"
using PIE4_VanessaCampos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"932bae75eca6f6eaac6742ea8cffa356bf871b39", @"/Views/Carrinho/Carrinho.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"050a58da2664d88abf9309ec19ea2d74ed61ace5", @"/Views/_ViewImports.cshtml")]
    public class Views_Carrinho_Carrinho : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Carrinho>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml"
  
    ViewData["Title"] = "Carrinho";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h3>Carrinho de Orçamento</h3>\r\n<br>\r\n    <table class=\"table\">\r\n        <tr>            \r\n            <td>Nome do Produto</td>\r\n            <td>Quantidade</td>\r\n            <td>Operação</td>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 16 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml"
         foreach (Carrinho car in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 19 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml"
               Write(car.Produto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml"
               Write(car.Quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 486, "\"", 521, 2);
            WriteAttributeValue("", 493, "/Carrinho/Excluir?Id=", 493, 21, true);
#nullable restore
#line 22 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml"
WriteAttributeValue("", 514, car.Id, 514, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Deseja remover o item do carrinho?\');\">Remover</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 25 "D:\Vanessa Campos\Documentos\EAD_TII\MA.UC08 - Projeto Integrador Desenvolvedor Web\Etapa 04\PIE4_VanessaCampos\Views\Carrinho\Carrinho.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <br>\r\n    <p><button>Concluir Orçamento</button></p>\r\n    <p><button><a href=\"/Carrinho/Produtos\">Continuar Comprando</a></button></p>    \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Carrinho>> Html { get; private set; }
    }
}
#pragma warning restore 1591
