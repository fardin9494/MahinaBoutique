#pragma checksum "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a658041d2338e2364fbe98bee593c4e8eebb172a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.LatestArrivals.Pages_Shared_Components_LatestArrivals__LatestArrivals), @"mvc.1.0.view", @"/Pages/Shared/Components/LatestArrivals/_LatestArrivals.cshtml")]
namespace ServiceHost.Pages.Shared.Components.LatestArrivals
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a658041d2338e2364fbe98bee593c4e8eebb172a", @"/Pages/Shared/Components/LatestArrivals/_LatestArrivals.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_LatestArrivals__LatestArrivals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MahinaBoutique.Query.Contract.Product.ProductQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

    <div class=""single-row-slider-area section-space mt-5"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <!--=======  section title  =======-->
                    <div class=""section-title-wrapper text-center section-space--half"">
                        <h2 class=""section-title"">آخرین محصولات</h2>
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
                    <!--=======  single row slider wrapper  =======-->
                    <div class=""single-row-slider-wrappe");
            WriteLiteral(@"r"">
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
                        {""breakpoint"":1501, ""settings"": {""slidesToShow"": 4} },
                        {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                        {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                        {""breakpoint"":767, ""settings"": {""slidesToShow"":");
            WriteLiteral(@" 2, ""arrows"": false} },
                        {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                        {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                    ]'>

                    

");
#nullable restore
#line 45 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                             foreach (var product in Model)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col"">
                                    <!--=======  single grid product  =======-->
                                    <div class=""single-grid-product"">
                                        <div class=""single-grid-product__image"">
                                            <div class=""single-grid-product__label"">
");
#nullable restore
#line 53 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                 if (product.HaveDiscount)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"sale\">");
#nullable restore
#line 55 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                  Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                                                    <span class=\"new\">جدید</span>\r\n");
#nullable restore
#line 57 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </div>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a658041d2338e2364fbe98bee593c4e8eebb172a8746", async() => {
                WriteLiteral("\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a658041d2338e2364fbe98bee593c4e8eebb172a9049", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3422, "~/ProductPictures/", 3422, 18, true);
#nullable restore
#line 60 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
AddHtmlAttributeValue("", 3440, product.Picture, 3440, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 60 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
AddHtmlAttributeValue("", 3481, product.PictureAlt, 3481, 19, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 60 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
AddHtmlAttributeValue("", 3509, product.PictureTitle, 3509, 21, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                \r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                     WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </div>
                                        <div class=""single-grid-product__content"">
                                            <div class=""single-grid-product__category-rating"">
                                                <span class=""category"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a658041d2338e2364fbe98bee593c4e8eebb172a14182", async() => {
#nullable restore
#line 67 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                                                                    Write(product.Category);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                                      WriteLiteral(product.CategorySlug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
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
                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a658041d2338e2364fbe98bee593c4e8eebb172a17581", async() => {
                WriteLiteral("\r\n                                                    ");
#nullable restore
#line 80 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                               Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                          WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </h3>\r\n                                            <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 84 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                 if (product.HaveDiscount)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"discounted-price\">");
#nullable restore
#line 86 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                              Write(product.PriceAfterDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                    <span class=\"main-price discounted\">");
#nullable restore
#line 87 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                                   Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 88 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"main-price\">");
#nullable restore
#line 91 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                                        Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 92 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </p>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 97 "C:\MahinaBoutiqueProject\Code\MahinaBoutique\ServiceHost\Pages\Shared\Components\LatestArrivals\_LatestArrivals.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MahinaBoutique.Query.Contract.Product.ProductQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
