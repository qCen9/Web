#pragma checksum "D:\Арсений\Отчеты\Политех\3 курс\web\lab4\lab2-3\Views\Order\Complete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98a9ba83d2b6e9f0dc90cd9083eadc4046e71d6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Complete), @"mvc.1.0.view", @"/Views/Order/Complete.cshtml")]
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
#line 1 "D:\Арсений\Отчеты\Политех\3 курс\web\lab4\lab2-3\Views\_ViewImports.cshtml"
using BookShop.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Арсений\Отчеты\Политех\3 курс\web\lab4\lab2-3\Views\_ViewImports.cshtml"
using BookShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98a9ba83d2b6e9f0dc90cd9083eadc4046e71d6f", @"/Views/Order/Complete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0125d07f3152b765250e8d14cb9cc2b31e8e6ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Complete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav id=""nav"">
    <ul>
        <li><a href=""/Home/Index"">Home</a></li>
        <li>
            <a href=""/Books/List"">Товары</a>
            <ul>
                <li><a href=""/Books/List/Fiction"">Художественная литература</a></li>
                <li><a href=""/Books/List/Technical_lit"">Техническая литература</a></li>
                <li><a href=""/Books/List/History"">История</a></li>
                <li><a href=""/Books/List/Fantastic"">Фантастика</a></li>
            </ul>
        </li>
        <li><a href=""/Cart/Index"">Корзина</a></li>
    </ul>
</nav>

<div class=""container-xxl"">
    <div class=""row m-5 p-5"">
        <div class=""container"">
            <div class=""text-center"">
                <h3>");
#nullable restore
#line 21 "D:\Арсений\Отчеты\Политех\3 курс\web\lab4\lab2-3\Views\Order\Complete.cshtml"
               Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            </div>\r\n        </div>\r\n</div>\r\n</div>");
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
