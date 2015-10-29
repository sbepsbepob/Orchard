using Orchard.UI.Resources;

namespace Skywalker.Webshop
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {

            // Create and add a new manifest
            var manifest = builder.Add();

            // Define a "common" style sheet
            manifest.DefineStyle("Skywalker.Webshop.Common").SetUrl("common.css");

            // Define the "shoppingcart" style sheet
            manifest.DefineStyle("Skywalker.Webshop.ShoppingCart").SetUrl("shoppingcart.css").SetDependencies("Skywalker.Webshop.Common");

            // Define the "shoppingcartwidget" style sheet
            manifest.DefineStyle("Skywalker.Webshop.ShoppingCartWidget").SetUrl("shoppingcartwidget.css").SetDependencies("Webshop.Common");

            // Define Globalization resources
            manifest.DefineScript("Globalize").SetUrl("globalize.js").SetDependencies("jQuery");
            manifest.DefineScript("Globalize.Cultures").SetBasePath(manifest.BasePath + "scripts/cultures/").SetUrl("globalize.culture.js").SetCultures("en-US", "nl-NL").SetDependencies("Globalize", "jQuery");
            manifest.DefineScript("Globalize.SetCulture").SetUrl("~/Skywalker.Webshop/Resource/SetCultureScript").SetDependencies("Globalize.Cultures");

            // Define the "shoppingcart" script and set a dependencies
            manifest.DefineScript("Skywalker.Webshop.ShoppingCart").SetUrl("shoppingcart.js").SetDependencies("jQuery", "jQuery_LinqJs", "ko", "Globalize.SetCulture");

            // Define the Checkout Summary style sheet
            manifest.DefineStyle("Skywalker.Webshop.Checkout.Summary").SetUrl("checkout-summary.css").SetDependencies("Skywalker.Webshop.Common");
        }
    }
}