#pragma checksum "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8009ba61eed9db51176c032863496a905ea83a89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct.Pages_Shared_Components_ProductCategoryWithProduct__CategoryWithProducts), @"mvc.1.0.view", @"/Pages/Shared/Components/ProductCategoryWithProduct/_CategoryWithProducts.cshtml")]
namespace ServiceHost.Pages.Shared.Components.ProductCategoryWithProduct
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
#line 1 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8009ba61eed9db51176c032863496a905ea83a89", @"/Pages/Shared/Components/ProductCategoryWithProduct/_CategoryWithProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ProductCategoryWithProduct__CategoryWithProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MahinaBoutique.Query.Contract.ProductCategory.ProductCategoryQueryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

    <div class=""single-row-slider-tab-area section-space"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <!--=======  section title  =======-->
                    <div class=""section-title-wrapper text-center section-space--half"">
                        <h2 class=""section-title"">محصولات ما</h2>
                        <p class=""section-subtitle"">
                            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ
                            و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است
                        </p>
                    </div>
                    <!--=======  End of section title  =======-->
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-12"">
                    <!--=======  tab slider wrapper  =======-->

                    <div class=""tab-slider-wrapper"">
      ");
            WriteLiteral(@"                  <!--=======  tab product navigation  =======-->

                        <div class=""tab-product-navigation"">
                            <div class=""nav nav-tabs justify-content-center"" id=""nav-tab2"" role=""tablist"">
                                
");
#nullable restore
#line 29 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                foreach(var category in Model)
                                  {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("class", " class=\"", 1522, "\"", 1592, 3);
            WriteAttributeValue("", 1530, "nav-item", 1530, 8, true);
            WriteAttributeValue(" ", 1538, "nav-link", 1539, 9, true);
#nullable restore
#line 31 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue(" ", 1547, Model.First() == category ? "active" : "", 1548, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1593, "\"", 1622, 2);
            WriteAttributeValue("", 1598, "product-tab-", 1598, 12, true);
#nullable restore
#line 31 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 1610, category.Id, 1610, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"tab\"");
            BeginWriteAttribute("href", "\r\n                                    href=\"", 1641, "\"", 1713, 2);
            WriteAttributeValue("", 1685, "#product-series-", 1685, 16, true);
#nullable restore
#line 32 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 1701, category.Id, 1701, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tab\" aria-selected=\"true\">");
#nullable restore
#line 32 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                                                                   Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 33 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                
                            </div>
                        </div>

                        <!--=======  End of tab product navigation  =======-->
                        <!--=======  tab product content  =======-->
                        <div class=""tab-content"">
");
#nullable restore
#line 41 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                             foreach (var category in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div");
            BeginWriteAttribute("class", " class=\"", 2238, "\"", 2309, 4);
            WriteAttributeValue("", 2246, "tab-pane", 2246, 8, true);
            WriteAttributeValue(" ", 2254, "fade", 2255, 5, true);
            WriteAttributeValue(" ", 2259, "show", 2260, 5, true);
#nullable restore
#line 43 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue(" ", 2264, Model.First() == category ? "active" : "", 2265, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2310, "\"", 2342, 2);
            WriteAttributeValue("", 2315, "product-series-", 2315, 15, true);
#nullable restore
#line 43 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 2330, category.Id, 2330, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"tabpanel\"");
            BeginWriteAttribute("aria-labelledby", "\r\n                                     aria-labelledby=\"", 2359, "\"", 2439, 2);
            WriteAttributeValue("", 2415, "product-tab-", 2415, 12, true);
#nullable restore
#line 44 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 2427, category.Id, 2427, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                    <!--=======  single row slider wrapper  =======-->
                                    <div class=""single-row-slider-wrapper"">
                                        <div class=""ht-slick-slider"" data-slick-setting='{
                                    ""slidesToShow"": 4,
                                    ""slidesToScroll"": 1,
                                    ""arrows"": true,
                                    ""autoplay"": false,
                                    ""autoplaySpeed"": 5000,
                                    ""speed"": 1000,
                                    ""infinite"": true,
                                    ""rtl"": true,
                                    ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                                    ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                                }' data-slick-responsive='[
                                 ");
            WriteLiteral(@"   {""breakpoint"":1501, ""settings"": {""slidesToShow"": 4} },
                                    {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                                    {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                                    {""breakpoint"":767, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                    {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                                    {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                                ]'>
                                            
                                            
");
#nullable restore
#line 68 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                     foreach(var product in category.Products)
                                          {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col"">
                                                <!--=======  single grid product  =======-->
                                                <div class=""single-grid-product"">
                                                    
                                                    <div class=""single-grid-product__image"">
");
#nullable restore
#line 75 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                         if (product.HaveDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"single-grid-product__label\">\r\n                                                                <span class=\"sale\">");
#nullable restore
#line 78 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                                              Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                            </div>\r\n");
#nullable restore
#line 80 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <a href=\"single-product.html\">\r\n                                                            <img");
            BeginWriteAttribute("src", " src=\"", 5342, "\"", 5364, 1);
#nullable restore
#line 82 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 5348, product.Picture, 5348, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("title", " title=\"", 5383, "\"", 5412, 1);
#nullable restore
#line 82 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 5391, product.PictureTitle, 5391, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 5413, "\"", 5504, 1);
#nullable restore
#line 83 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
WriteAttributeValue("", 5485, product.PictureAlt, 5485, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                        </a>

                                                    </div>
                                                    <div class=""single-grid-product__content"">
                                                        <div class=""single-grid-product__category-rating"">
                                                            <span class=""category"">
                                                                <a href=""shop-left-sidebar.html"">");
#nullable restore
#line 90 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                                                            Write(product.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                            </span>
                                                            <span class=""rating"">
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star-outline""></i>
                                                            </span>
                                                        </div>

                                                        <h3 class=""single-grid-product__title"">
                                                            <a href=""single-product.html"">
                ");
            WriteLiteral("                                                ");
#nullable restore
#line 103 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                            </a>\r\n                                                        </h3>\r\n");
#nullable restore
#line 106 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                         if (product.HaveDiscount)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <p class=\"single-grid-product__price\">\r\n                                                                <span class=\"discounted-price\">");
#nullable restore
#line 109 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                                                          Write(product.PriceAfterDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                                <span class=\"main-price discounted\">");
#nullable restore
#line 110 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                                                               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                            </p>\r\n");
#nullable restore
#line 112 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <p class=\"single-grid-product__price\">\r\n                                                                <span class=\"main-price\">");
#nullable restore
#line 116 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                                                    Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                            </p>\r\n");
#nullable restore
#line 118 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    </div>
                                                </div>
                                                <!--=======  End of single grid product  =======-->
                                            </div>
");
#nullable restore
#line 123 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                          


                                        </div>
                                    </div>
                                    <!--=======  End of single row slider wrapper  =======-->
                                </div>
");
#nullable restore
#line 131 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\ProductCategoryWithProduct\_CategoryWithProducts.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            <!--=======  End of tab product content  =======-->
                        </div>

                    <!--=======  End of tab slider wrapper  =======-->
                </div>
            </div>
        </div>
    </div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MahinaBoutique.Query.Contract.ProductCategory.ProductCategoryQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591