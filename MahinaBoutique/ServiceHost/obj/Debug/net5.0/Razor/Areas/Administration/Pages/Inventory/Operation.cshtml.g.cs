#pragma checksum "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7395654e3521d3edb3159417311482a8f159d0bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Inventory.Areas_Administration_Pages_Inventory_Operation), @"mvc.1.0.view", @"/Areas/Administration/Pages/Inventory/Operation.cshtml")]
namespace ServiceHost.Pages.Inventory
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7395654e3521d3edb3159417311482a8f159d0bd", @"/Areas/Administration/Pages/Inventory/Operation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Inventory_Operation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>>
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
                    <th>تعداد</th>
                    <th>تاریخ</th>
                    <th>عملیات</th>
                    <th>موجودی فعلی</th>
                    <th>عملگر</th>
                    <th>توضیحات</th>
                </tr>
            </thead>
            <tbody>
                
");
#nullable restore
#line 22 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                     foreach(var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                           <tr");
            BeginWriteAttribute("class", " class=\"", 830, "\"", 895, 2);
            WriteAttributeValue("", 838, "text-white", 838, 10, true);
#nullable restore
#line 24 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
WriteAttributeValue(" ", 848, item.Operation ? "bg-success" : "bg-danger", 849, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>");
#nullable restore
#line 25 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 26 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                           Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 27 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                           Write(item.OperationTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n");
#nullable restore
#line 29 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                                 if(item.Operation)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>ورودی</span>\r\n");
#nullable restore
#line 32 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                                }else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>خروجی</span>\r\n");
#nullable restore
#line 35 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>");
#nullable restore
#line 37 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                           Write(item.CurrentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                           Write(item.Operator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                           </tr>\r\n");
#nullable restore
#line 41 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Areas\Administration\Pages\Inventory\Operation.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n            </tbody>\r\n            </table>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591