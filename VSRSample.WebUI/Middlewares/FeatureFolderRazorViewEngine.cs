using Microsoft.AspNetCore.Mvc.Razor;

namespace VSRSample.WebUI.Middlewares
{
    public class FeatureFolderRazorViewEngine : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context) { }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new string[]
            {
                "/Areas/{2}/Features/{1}/Views/{0}.cshtml",
                "/Areas/{2}/Features/Shared/{0}.cshtml"
            };
        }
    }
}
