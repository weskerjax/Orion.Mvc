using Orion.API.Extensions;
using Orion.Mvc.Attributes;
using System.Linq;
using System.Web.Mvc;

namespace Orion.Mvc.Filters
{
	/// <summary></summary>
	public class UseViewPageActionFilter : ActionFilterAttribute
	{
		/// <summary></summary>
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			var result = filterContext.Result as ViewResult;
			if (result == null) { return; }

			var findAttrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(UseViewPageAttribute), false);
			var attr = findAttrs.FirstOrDefault() as UseViewPageAttribute;
			if (attr == null) { return; }

			if (attr.Title.HasText()) { result.ViewBag.Title = attr.Title; }
			result.ViewName = attr.ViewName;
		}

	}
}