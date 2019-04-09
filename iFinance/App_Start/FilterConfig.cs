using System.Web;
using System.Web.Mvc;

namespace iFinance
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Force all request to use ssl
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
