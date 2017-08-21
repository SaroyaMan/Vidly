using System.Web;
using System.Web.Mvc;

namespace Vidly_New {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new AuthorizeAttribute());  //add authrization globally
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
