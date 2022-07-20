using System.Web;
using System.Web.Optimization;

namespace RekonAntasena
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", 
                         "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/datatables/dataTables.responsive.min.js",
                        "~/Scripts/datatables/dataTables.buttons.min.js",
                        "~/Scripts/datatables/dataTables.checkboxes.min.js",
                        "~/Scripts/dataTables.plugin.js",
                        "~/Scripts/datatables/buttons.html5.js",
                        "~/Scripts/datatables/buttons.html5.min.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery-3.6.0.min.js",
                        "~/Scripts/jszip.js",
                        "~/Scripts/jszip.min.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Scripts/datatables/buttons.colVis.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sweetalert.css", 
                       "~/Content/datatables/jquery.dataTables.min.css",
                       "~/Content/datatables/css/datatables.bootstrap.css",
                       "~/Content/datatables/buttons.dataTables.min.css  ",
                      "~/Content/datatables/css/dataTables.checkboxes.css",
                      "~/Content/site.css"));
        }
    }
}
