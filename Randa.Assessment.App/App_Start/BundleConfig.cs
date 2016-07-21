using System.Web.Optimization;

namespace Randa.Assessment.App
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;


            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/ui-bootstrap-csp.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js",
                         "~/Scripts/angular-route.js",
                         "~/Scripts/angular-ui/ui-bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/odata")
                .Include("~/Scripts/odataresources.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app.js")
                .IncludeDirectory("~/Hubs", "*.js")
                .IncludeDirectory("~/Controllers", "*.js")
                .IncludeDirectory("~/Modules", "*.js")
                .IncludeDirectory("~/Services", "*.js")
                .IncludeDirectory("~/Factories", "*.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}