#pragma checksum "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d35b16da9588f40999174338879d4a6449c4bf6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Scadenze_Detail), @"mvc.1.0.view", @"/Views/Scadenze/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Blog\Scadenzario\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Blog\Scadenzario\Views\_ViewImports.cshtml"
using Scadenzario.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Blog\Scadenzario\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Blog\Scadenzario\Views\_ViewImports.cshtml"
using Scadenzario.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35b16da9588f40999174338879d4a6449c4bf6", @"/Views/Scadenze/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9d8f078d45512a566653dd130aaca493bb3974d", @"/Views/_ViewImports.cshtml")]
    public class Views_Scadenze_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ScadenzeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<br>\r\n<h1>");
#nullable restore
#line 3 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br>\r\n<br>\r\n<br>\r\n<div class=\"container\" style=\"align-content: center;border:1px solid;\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <b>Beneficiario</b>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 13 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
       Write(Model.Beneficiario);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            \r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <b>Data Scadenza</b>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 24 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
       Write(Model.DataScadenza);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            \r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <b>Importo</b>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 35 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
       Write(Model.Importo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            \r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <b>Giorni Ritardo</b>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 46 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
       Write(Model.GiorniRitardo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            \r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <b>Sollecito</b>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 57 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
       Write(Model.Sollecito);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            \r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <b>Data Pagamento</b>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            ");
#nullable restore
#line 68 "C:\Blog\Scadenzario\Views\Scadenze\Detail.cshtml"
       Write(Model.DataPagamento);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            \r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ScadenzeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
