using System.Web.Optimization;

namespace CinemaCounter
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/mui.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/functions.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/mui.css",
                "~/Content/css/main.css"));
        }
    }
}