#pragma checksum "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b39d67f7f133c2aa8e29c5ba10b01094ee5a8233"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 2 "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\_ViewImports.cshtml"
using WebTicketBooking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b39d67f7f133c2aa8e29c5ba10b01094ee5a8233", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87026cf158341e6c16b9417a4771f473728747ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\Home\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">
        <h2 class=""display-4"">Welcome to Aviasales</h2>
        <h3>Stuff for users:</h3>
        <ul type=""circle"">
            <li>Change your information like username or password</li>
            <li>Approve yourself to admin</li>
            <li>Book tickets</li>
            <li>Cancel tickets but only if the departure is not in a day</li>
            <li>Rerview list of your tickets</li>
            <li>Review list of all active tickets</li>
        </ul>
        <h3>Stuff for admins:</h3>
        <ul>
            <li>All stuff for users</li>
            <li>Review list of users</li>
            <li>Add, delete and update tickets</li>
            <li>Review list of all tickets</li>
        </ul>
    </div>
");
#nullable restore
#line 25 "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\Home\Index.cshtml"
 if (!User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">
        <h2 class=""display-4"">Introducing the Aviasales web site</h2>
        <h2>for doing stuff with aviatickets</h2>
        <p>After authorization you can see tickets from our database and book some of its. 
        If you will have admin rights you can also manage tickets. You can approve yourself to admin anytime.</p>
    </div>
");
#nullable restore
#line 34 "C:\hneu\Курсовая\TicketBooking\WebTicketBooking\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
