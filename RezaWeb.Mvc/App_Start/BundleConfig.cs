using System.Web.Optimization;

namespace RezaWeb.Mvc
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                     .Include("~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                            //.Include("~/Scripts/bootstrap.min.js")
                            .Include("~/Scripts/bootstrap.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Admin/Content/css").Include("~/Content/Site-Admin.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                            //.Include("~/Content/bootstrap.css")
                            .Include("~/Content/bootstrap.min.css")
                            //.Include("~/Content/bootstrap-theme.css")
                            .Include("~/Content/bootstrap-theme.min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        //"~/Content/themes/base/jquery.ui.resizable.css",
                        //"~/Content/themes/base/jquery.ui.selectable.css",
                        //"~/Content/themes/base/jquery.ui.accordion.css",
                        //"~/Content/themes/base/jquery.ui.autocomplete.css",
                        //"~/Content/themes/base/jquery.ui.button.css",
                        //"~/Content/themes/base/jquery.ui.dialog.css",
                        //"~/Content/themes/base/jquery.ui.slider.css",
                        //"~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        //"~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // Clear all items from the default ignore list to allow minified CSS and JavaScript files to be included in debug mode
            bundles.IgnoreList.Clear();

            // Do not include intellisense files
            bundles.IgnoreList.Ignore("*.intellisense.js");
        }
    }
}