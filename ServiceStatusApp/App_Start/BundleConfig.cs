using System.Web;
using System.Web.Optimization;

namespace ServiceStatusApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/main.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/myDataTables.js",
                        "~/Scripts/DataTables/dataTables.boostrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapToolTip").Include(
                     "~/Scripts/tooltip.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/Content/index").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/index.css"));

            bundles.Add(new StyleBundle("~/Content/user").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/user.css"));

        }
    }
}
