using System.Web;
using System.Web.Mvc;
using MVCPractice.WebAPI.Attributes;

namespace MVCPractice.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ApiAuthorizeAttribute());
        }
    }
}
