#pragma checksum "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d219f8b7945164fdde5ca14746fe6e008938fbba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reddit_Index), @"mvc.1.0.view", @"/Views/Reddit/Index.cshtml")]
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
#line 1 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\_ViewImports.cshtml"
using Assignment2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\_ViewImports.cshtml"
using Assignment2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d219f8b7945164fdde5ca14746fe6e008938fbba", @"/Views/Reddit/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de2f008bb030c689fdd92cf0ac6c09ff2675aa17", @"/Views/_ViewImports.cshtml")]
    public class Views_Reddit_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RedditImplementation.RedditPost>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Truncate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetMyPosts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
  
    ViewData["Title"] = "Reddit";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n<h3>Reddit Posts</h3>\r\n\r\n<p>\r\n");
            WriteLiteral("    <table cellspacing=\"10\" , cellpadding=\"10\">\r\n        <tr>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d219f8b7945164fdde5ca14746fe6e008938fbba4224", async() => {
                WriteLiteral("Truncate Data");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d219f8b7945164fdde5ca14746fe6e008938fbba5449", async() => {
                WriteLiteral("Get MyPosts");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 20 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
                 using (Html.BeginForm("GetTaggedPost", "Reddit", FormMethod.Post))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <input type=\"text\" value=\"Jalpa96164182\" name=\"hashTag\" /> <button type=\"submit\">Get SubReddit</button><br />\r\n");
#nullable restore
#line 23 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </td>
            <td>
                <button type=""button"" class=""btn-block"" data-toggle=""modal"" id=""ClickMe"" data-target=""#myModal"" style=""background-color: tomato; font-family:Verdana; color: white;"" name=""ClickMe"">Create Post</button>
            </td>
    </table>
</p>
<div class=""modal fade"" id=""myModal"" role=""dialog"" data-url='");
#nullable restore
#line 30 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
                                                        Write(Url.Action("OpenModelPopup","Reddit"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'></div>

<script type=""text/javascript"">
    $(document).ready(function () {
        $('.btn-block').click(function () {
            var url = $('#myModal').data('url');
            $.get(url, function (data) {
                $(""#myModal"").html(data);
                $(""#myModal"").modal('show');
            });
        });
    });
</script>


<table class=""table"">
    <thead>
        <tr>
            <th>
                Subreddit
            </th>
            <th>
                ");
#nullable restore
#line 52 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Up Votes\r\n            </th>\r\n            <th>\r\n                Upvote Ratio\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 61 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Created Time\r\n            </th>\r\n            <th>\r\n                Down Votes\r\n            </th>\r\n            <th>\r\n                Edited Time\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 73 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Fullname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 76 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Permalink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 79 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SelfText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 82 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SelfTextHTML));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 87 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 91 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Subreddit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 94 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 97 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UpVotes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 100 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UpvoteRatio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 103 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 106 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 109 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DownVotes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 112 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Edited));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 115 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Fullname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 118 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Permalink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 121 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SelfText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 124 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SelfTextHTML));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 127 "D:\1 practicals\c# Dot Net Core\Assignment2\Assignment2\Views\Reddit\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RedditImplementation.RedditPost>> Html { get; private set; }
    }
}
#pragma warning restore 1591
