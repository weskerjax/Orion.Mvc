using Orion.API.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orion.Mvc.Filters
{
	/// <summary>PageParams 的預設值 ActionFilter</summary>
	public class PageParamsActionFilter : ActionFilterAttribute
	{
		private string _sizeParam;
		private int _defaultSize;

		/// <summary></summary>
		public PageParamsActionFilter(string sizeParam, int defaultSize)
		{
			_sizeParam = sizeParam;
			_defaultSize = defaultSize;
		}


		/// <summary></summary>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			IPageParams pageParams = filterContext.ActionParameters.Values.OfType<IPageParams>().FirstOrDefault();
			if (pageParams == null) { base.OnActionExecuting(filterContext); return; }


			var request = filterContext.HttpContext.Request;
			var response = filterContext.HttpContext.Response;

			if (pageParams.PageSize > 0)
			{
				response.Cookies.Add(new HttpCookie(_sizeParam)
				{
					Value = pageParams.PageSize.ToString(),
					Expires = DateTime.Now.AddYears(1),
				});
			}
			else
			{
				pageParams.PageSize = _defaultSize;
				try { pageParams.PageSize = int.Parse(request.Cookies[_sizeParam].Value); } catch { }
			}

			filterContext.Controller.ViewData[_sizeParam] = pageParams.PageSize;
			base.OnActionExecuting(filterContext);
		}

	}
}
