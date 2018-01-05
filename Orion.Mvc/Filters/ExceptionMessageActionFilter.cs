using Orion.API;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Orion.Mvc.Filters
{
	/// <summary>例外訊息過濾器</summary>
	public class ExceptionMessageActionFilter : ActionFilterAttribute
	{

		private Type[] _exceptionTypes;

		/// <summary></summary>
		public ExceptionMessageActionFilter(params Type[] exceptionTypes)
		{
			_exceptionTypes = exceptionTypes;
		}


		/// <summary></summary>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var parameters = filterContext.ActionParameters.Values.Where(x => x != null);

			var model = parameters.FirstOrDefault(x => (
				x.GetType().Name.EndsWith("ViewModel") || 
				x.GetType().Namespace.EndsWith("Models") ||
				x.GetType().Name.EndsWith("Domain") || 
				x.GetType().Namespace.EndsWith("Domain")
			));

			filterContext.Controller.ViewData.Model = model;
		}


		/// <summary></summary>
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			if (filterContext.IsChildAction) { return; }
			if (filterContext.ExceptionHandled) { return; }

			var ex = filterContext.Exception;
			if (!_exceptionTypes.Any(x => x.IsInstanceOfType(ex))) { return; }


			filterContext.ExceptionHandled = true;

			if (filterContext.HttpContext.Request.IsAjaxRequest())
			{
				filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
				filterContext.HttpContext.Response.StatusCode = 400;
				filterContext.Result = new ContentResult { Content = ex.Message };
			}
			else if (ex is OrionNoDataException) 
			{
				filterContext.Controller.TempData["StatusError"] = ex.Message;
				filterContext.Result = new HttpNotFoundResult("[" + ex.Message + "]");
			}
			else
			{
				filterContext.Controller.TempData["StatusError"] = ex.Message;
				filterContext.Result = new ViewResult
				{
					ViewData = filterContext.Controller.ViewData,
					TempData = filterContext.Controller.TempData
				};
			}
		}

	}
}