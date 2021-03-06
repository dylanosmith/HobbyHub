#pragma checksum "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70cda59952dbf3f3466c7eec48c3c18909ef5543"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/_ViewImports.cshtml"
using HobbyHub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/_ViewImports.cshtml"
using HobbyHub.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70cda59952dbf3f3466c7eec48c3c18909ef5543", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73b43894b7f1b1132efb6bd8d82f780aceacb1c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Hobby>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral(@"
<div class=""row"">
    <a class=""col-12 text-right"" href=""/"">Logout</a>
    <h1 class=""col-12 text-white font-weight-bold text-center"">Select Your Favorite Hobby & Become an Enthusiast!</h1>
</div>
<div class=""row mb-2"">
    <div class=""col-12 text-right"">
        <a href=""/hobby/new"" class=""btn btn-primary"">Create a Hobby</a>
    </div>
</div>
<div class=""row col-10 mx-auto rounded p-2 mb-3"">
    <table class=""table table-hover bg-light col-10 mx-auto text-center"">
        <thead>
            <tr>
                <th scope=""col"">Name</th>
                <th scope=""col"">Description</th>
                <th scope=""col"">Enthusiasts</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 23 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml"
              
                foreach(Hobby hobby in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td><a");
            BeginWriteAttribute("href", " href =\"", 841, "\"", 870, 2);
            WriteAttributeValue("", 849, "/hobby/", 849, 7, true);
#nullable restore
#line 27 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 856, hobby.HobbyId, 856, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml"
                                                    Write(hobby.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\n                    <td>");
#nullable restore
#line 28 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml"
                   Write(hobby.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 29 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml"
                   Write(hobby.Users.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 31 "/Users/dylan/Dojo/Tracks/c#/Belt/HobbyHub/Views/Home/Dashboard.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Hobby>> Html { get; private set; }
    }
}
#pragma warning restore 1591
