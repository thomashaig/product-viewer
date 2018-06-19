#pragma checksum "C:\Users\Thomas\Desktop\Stuff\Products\product-viewer\Views\Home\Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5062a2c453d711fce0c198d03ba947d494372c76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Test), @"mvc.1.0.view", @"/Views/Home/Test.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Test.cshtml", typeof(AspNetCore.Views_Home_Test))]
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
#line 1 "C:\Users\Thomas\Desktop\Stuff\Products\product-viewer\Views\_ViewImports.cshtml"
using product_viewer;

#line default
#line hidden
#line 2 "C:\Users\Thomas\Desktop\Stuff\Products\product-viewer\Views\_ViewImports.cshtml"
using product_viewer.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5062a2c453d711fce0c198d03ba947d494372c76", @"/Views/Home/Test.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5808fe124f8b97e5fc156038a9fb90d4430db0fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Test : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Thomas\Desktop\Stuff\Products\product-viewer\Views\Home\Test.cshtml"
  
    ViewData["Title"] = "Products Listing";

#line default
#line hidden
            BeginContext(52, 411, true);
            WriteLiteral(@"
<div id=""app"">
    <div>
    <h1>Hello App!</h1>
  <p>
    <!-- use router-link component for navigation. -->
    <!-- specify the link by passing the `to` prop. -->
    <!-- `<router-link>` will be rendered as an `<a>` tag by default -->
    <router-link to=""/foo"">Go to Foo</router-link>
    <router-link to=""/bar"">Go to Bar</router-link>
  </p>
  <router-view></router-view>
  </div>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(481, 1430, true);
                WriteLiteral(@"
    <script>
        const Foo = {
            data : function() {
                return { products: null, loading: true }
            },
            template:
            `<div>
                <div class=""loading"" v-if=""loading"">Loading
                    </div><div v-if=""products"" v-for=""product in products"">
        <span><router-link :to=""'/product/' + product.id"">Go to {{product.name}}</router-link></router-link></span>
    </div></div>`,
    mounted() {
            var self = this
            self.loading = true
                axios
                    .get('/api/products')
                    .then(response => {
                        self.products = response.data
                        self.loading = false
                    }
                    )
    }
        }
const Bar = { 
    props: ['id'],
    template: `<div>{{id}}</div>`,
     mounted() {
            var self = this
            console.log(""WHAT WAS ID"");
            console.log(self.id);
    }
}

co");
                WriteLiteral(@"nst routes = [
  { path: '/', component: Foo},
  { path: '/product/:id', component: Bar, props: true }
]

const router = new VueRouter({
  routes // short for `routes: routes`
})

        var app = new Vue({
            router,
            el: '#app',
            data: function() {
         return  {
         }
    },
            mounted() {

            }
        });
    </script>
");
                EndContext();
            }
            );
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
