#pragma checksum "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a919a0152124bf2075c5a9d70fcc43dac30b1b30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.LatesProducts.Pages_Shared_Components_LatesProducts_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/LatesProducts/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.LatesProducts
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
#line 1 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a919a0152124bf2075c5a9d70fcc43dac30b1b30", @"/Pages/Shared/Components/LatesProducts/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bdd27e8b016acb3c031a38b8da4d14315ca499", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_LatesProducts_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_LampShadeQuery.Contracts.Product.ProductQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCatgory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
<div class=""single-row-slider-area section-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""section-title-wrapper text-center section-space--half"">
                    <h2 class=""section-title"">آخرین محصولات</h2>
                    <p class=""section-subtitle"">
                        لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است
                    </p>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""single-row-slider-wrapper"">
                    <div class=""ht-slick-slider"" data-slick-setting='{
                        ""slidesToShow"": 4,
                        ""slidesToScroll"": 1,
                        ""arrows"": true,
                        ""autoplay"": false,
                        ""autoplaySpeed"": 5000,
                        ""speed"": 1000,
                 ");
            WriteLiteral(@"       ""infinite"": true,
                        ""rtl"": true,
                        ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                        ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                    }' data-slick-responsive='[
                        {""breakpoint"":1501, ""settings"": {""slidesToShow"": 4} },
                        {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                        {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                        {""breakpoint"":767, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                        {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                        {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                    ]'>
");
#nullable restore
#line 37 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                         foreach (var product in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col"">
                                <!--=======  single grid product  =======-->
                            <div class=""single-grid-product"">
                                    <div class=""single-grid-product__image"">
");
#nullable restore
#line 43 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                         if (product.HasDiscount)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div class=\"single-grid-product__label\">\r\n                                                <span class=\"sale\">-");
#nullable restore
#line 46 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                                               Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                                                <span class=\"new\">جدید</span>\r\n                                            </div>\r\n");
#nullable restore
#line 49 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a919a0152124bf2075c5a9d70fcc43dac30b1b308447", async() => {
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a919a0152124bf2075c5a9d70fcc43dac30b1b308746", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2964, "~/ProductPictures/", 2964, 18, true);
#nullable restore
#line 51 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
AddHtmlAttributeValue("", 2982, product.Picture, 2982, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
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
#line 50 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
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
                                            <span class=""category"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a919a0152124bf2075c5a9d70fcc43dac30b1b3012766", async() => {
#nullable restore
#line 56 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                                                                                                                 Write(product.Category);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
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
            WriteLiteral(@"</span>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a919a0152124bf2075c5a9d70fcc43dac30b1b3016061", async() => {
                WriteLiteral("\r\n                                               ");
#nullable restore
#line 68 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                          Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            ");
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
#line 67 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
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
            WriteLiteral("\r\n                                        </h3>\r\n                                        <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 72 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                             if(product.HasDiscount)
                                           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                               <span class=\"discounted-price\">");
#nullable restore
#line 74 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                                                         Write(product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                <span class=\"main-price discounted\">");
#nullable restore
#line 75 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                                                               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 76 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"main-price\">");
#nullable restore
#line 79 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                                                    Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 80 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 85 "C:\Users\Lenovo\Desktop\LampShade\ServiceHost\Pages\Shared\Components\LatesProducts\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_LampShadeQuery.Contracts.Product.ProductQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
