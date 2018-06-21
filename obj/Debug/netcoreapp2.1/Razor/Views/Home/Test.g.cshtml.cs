#pragma checksum "C:\Users\Thomas\Desktop\Stuff\Products\product-viewer\Views\Home\Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99809c61676349438111c84339312327f1687503"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99809c61676349438111c84339312327f1687503", @"/Views/Home/Test.cshtml")]
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
            BeginContext(52, 61, true);
            WriteLiteral("\r\n<div id=\"app\">\r\n    <router-view></router-view>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(131, 8058, true);
                WriteLiteral(@"
    <script>
        const List = {
            data : function() {
                return { products: null, loading: true }
            },
            template:
            `
            <div class=""container""> 
                <div class=""row"">
                    <h1>Product Listing</h1>
                </div>
                <div class=""loading row"" v-if=""!products"">
                    Loading
                </div>
                <div v-else class=""product-list"">
                    <div v-for=""i in Math.ceil(products.length / 3)"" class=""row product-row"">
                        <div v-for=""product in products.slice((i - 1) * 3, i * 3)"" class=""col-sm-4"">
                            <router-link :to=""'/product/' + product.id"" class=""non-hover-link"">
                                <div class=""card w-100 product-card"">
                                    <img class=""card-img-top"" src=""https://picsum.photos/200/100/?random"" alt=""Card image cap"">
                                    <d");
                WriteLiteral(@"iv class=""card-body"">
                                        <h5 class=""card-title"">{{product.name}}</h5>
                                        <p class=""card-text"">{{product.description}}</p>
                                    </div>
                                </div>
                            </router-link>
                        </div>
                    </div>
                </div>
            </div>
            `,
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
    const Product = { 
        props: ['id'],
        data : 
        function() 
        {
            return { product: null, loading: true, addingFeature: false, newName: null, newDescription: null }
        },
     ");
                WriteLiteral(@"   template: 
        `<div>
            <div class=""loading"" v-if=""loading"">
                Loading...
            </div>
            <div v-if=""product"">
                <h1>{{product.name}}</h1>
                <p>{{product.description}}</p>
                <div v-if=""product.productFeatures.length > 0"">
                    <div v-for=""i in Math.ceil((product.productFeatures.length + 1) / 3)"" class=""row product-row"">
                        <div v-for=""feature in product.productFeatures.slice((i - 1) * 3, i * 3)"" class=""col-sm-4"">
                            <div class=""card w-100 product-card"">
                                <img class=""card-img-top"" src=""https://picsum.photos/200/100/?random"" alt=""Card image cap"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">{{feature.name}}</h5>
                                    <p class=""card-text"">{{feature.description}}</p>
                                    <button class=""btn ");
                WriteLiteral(@"btn-danger"" v-on:click=""deleteFeature(feature.id)"">Delete</button>
                                </div>
                            </div>
                        </div>
                        <div v-if=""i == Math.ceil((product.productFeatures.length + 1) / 3)"" class=""col-sm-4"">
                            <div class=""card w-100 product-card"" v-if=""!addingFeature"">
                                <img class=""card-img-top"" src=""https://picsum.photos/200/100/?random"" alt=""Card image cap"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Add A New Feature</h5>
                                    <button class=""btn btn-primary"" v-on:click=""addFeature()"">Click Here</button>
                                </div>
                            </div>
                            <div class=""card w-100 product-card"" v-else>
                                <img class=""card-img-top"" src=""https://picsum.photos/200/100/?random"" alt=""Card image");
                WriteLiteral(@" cap"">
                                <div class=""card-body"">
                                    <h5 class=""card-text"">Name: <input v-model=""newName"" placeholder=""Name""""></h5>
                                    <p class=""card-text"" click=""addFeature()"">Description: <input v-model=""newDescription"" placeholder=""Description""></p>
                                    <button class=""btn btn-success"" v-on:click=""submitFeature()"">Submit</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row product-row"" v-else>
                    <div class=""col-sm-4"">
                        <div class=""card w-100 product-card"" v-if=""!addingFeature"">
                            <img class=""card-img-top"" src=""https://picsum.photos/200/100/?random"" alt=""Card image cap"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">Ad");
                WriteLiteral(@"d A New Feature</h5>
                                <button class=""btn btn-primary"" v-on:click=""addFeature()"">Click Here</button>
                            </div>
                        </div>
                        <div class=""card w-100 product-card"" v-else>
                            <img class=""card-img-top"" src=""https://picsum.photos/200/100/?random"" alt=""Card image cap"">
                            <div class=""card-body"">
                                <h5 class=""card-text"">Name: <input v-model=""newName"" placeholder=""Name""></h5>
                                <p class=""card-text"" click=""addFeature()"">Description: <input v-model=""newDescription"" placeholder=""Description""></p>
                                <button class=""btn btn-success"" v-on:click=""submitFeature()"">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <router-link to=""/"">Back to product list</router-link>");
                WriteLiteral(@"
        </div>`,
        mounted() {
            var self = this
            axios
                .get('/api/products/' + self.id + '?includeFeatures=true')
                .then(response => {
                    self.product = response.data
                    self.loading = false
                })
        },
        methods: {
            deleteFeature: function(feature_id) {
                var self = this;
                axios.delete('/api/products/' + this.id + '/productFeatures/' + feature_id).then(response => {
                    _.remove(self.product.productFeatures, function(pf) {
                        return pf.id == feature_id;
                    });
                    self.product.productFeatures.splice(1,1);
                    console.log(self.product.productFeatures);
                })
            },
            addFeature: function() {
                this.newName = null;
                this.newDescription = null;
                this.addingFeature = true;
 ");
                WriteLiteral(@"           },
            submitFeature: function() {
                var self = this;
                axios.post('/api/products/' + this.id + '/productFeatures', {
                    ""name"":self.newName,
                    ""description"":self.newDescription
                }).then(response => {
                    self.addingFeature = false;
                    self.product.productFeatures.push(response.data);
                });
            }
        }
    }

    const routes = [
        { path: '/', component: List},
        { path: '/product/:id', component: Product, props: true }
    ]

    const router = new VueRouter({
        routes // short for `routes: routes`
    })

    var app = new Vue({
        router,
        el: '#app',
        data: function() {
            return  {}
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
