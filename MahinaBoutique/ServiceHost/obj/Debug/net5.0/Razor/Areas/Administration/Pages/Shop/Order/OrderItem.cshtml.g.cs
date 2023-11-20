#pragma checksum "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecced6e35f3dfd3f0bdba1bcab573d9d92fa8754"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shop.Order.Areas_Administration_Pages_Shop_Order_OrderItem), @"mvc.1.0.view", @"/Areas/Administration/Pages/Shop/Order/OrderItem.cshtml")]
namespace ServiceHost.Pages.Shop.Order
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
#line 1 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
using _0_SelfBuildFramwork.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecced6e35f3dfd3f0bdba1bcab573d9d92fa8754", @"/Areas/Administration/Pages/Shop/Order/OrderItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c591d92e4ac0f58b513853bb181f88e7aa70505", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Shop_Order_OrderItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.Order.OrderItemViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">گردش محصول</h4>
</div>
<div class=""modal-body"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>#</th>
                <th>شماره سفارش</th>
                <th>محصول</th>
                <th>تعداد</th>
                <th>قیمت واحد</th>
                <th>تخفیف</th>
               
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 23 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 26 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
                   Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
                   Write(item.Product);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
                   Write(item.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
                   Write(item.DiscocuntRate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Shop\Order\OrderItem.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.Order.OrderItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
