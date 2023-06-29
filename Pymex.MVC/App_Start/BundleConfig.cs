using System.Web;
using System.Web.Optimization;

namespace Pymex.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-3.5.1.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js")); // Bootstrap 4.6


            bundles.Add(new ScriptBundle("~/bundles/complements").Include(
                    "~/Scripts/sb-admin-2.min.js",
                    "~/Scripts/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                    "~/Scripts/datatables/jquery.dataTables.min.js",
                    "~/Scripts/datatables/dataTables.bootstrap4.min.js",
                    "~/Scripts/datatables/datatables-demo.js"));
            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/all.min.css", // Font Awesome
                    "~/Content/sb-admin-2.min.css")); // Custom Bootstrap

            bundles.Add(new StyleBundle("~/Content/table").Include(
                    "~/Content/datatables/dataTables.bootstrap4.min.css"));
        }
    }
}


