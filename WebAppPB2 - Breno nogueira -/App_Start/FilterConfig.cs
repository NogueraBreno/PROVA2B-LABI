using System.Web;
using System.Web.Mvc;

namespace WebAppPB2___Breno_nogueira__
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
