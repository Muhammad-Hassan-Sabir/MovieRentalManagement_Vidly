using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(

                        "~/Scripts/bootbox.js",
                         "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/scripts/datatables/jquery.dataTables.js",
                        "~/scripts/datatables/dataTables.bootstrap.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/scripts/toastr.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootbox.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/content/datatables/css/dataTables.bootstrap.css",
                      "~/Content/bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/content/toastr.css",
                      "~/content/Site.css"


                      ));
        }
    }
}
