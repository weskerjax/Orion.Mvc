using Orion.API;
using Orion.Mvc.Filters;
using System.Web.Mvc;

namespace TestRunWebApp
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			/* 愈後面的愈早執行 */
			filters.Add(new JsonNetActionFilter());
			filters.Add(new UseViewPageActionFilter());
			filters.Add(new ExceptionMessageActionFilter(typeof(OrionException)));
		}
	}
}
