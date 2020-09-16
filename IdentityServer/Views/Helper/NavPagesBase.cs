using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IdentityServer.Views.Helper
{
    public static class NavPagesBase
    {
        private static string ActivePageKey => "ActivePage";

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData[ActivePageKey] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}