using System;
using System.Web;
using System.Web.Mvc;
using Orion.API.Extensions;

namespace Orion.Mvc.Extensions
{
	/// <summary></summary>
	public static class ControllerExtensions
	{
		/// <summary></summary>
		public static ContentResult Error(this Controller controller, int httpCode, string message) 
		{
			controller.Response.TrySkipIisCustomErrors = true;
			controller.Response.StatusCode = httpCode;
			return new ContentResult
			{
				Content = message,
				ContentType = null,
				ContentEncoding = null
			};
		}

		/// <summary></summary>
		public static void SetStatusSuccess(this Controller controller, string message)
		{
			controller.TempData["StatusSuccess"] = message;
		}

		/// <summary></summary>
		public static void SetStatusError(this Controller controller, string message)
		{
			controller.TempData["StatusError"] = message;
		}


 



		/// <summary></summary>
		public static ViewResult ExcelView(this Controller controller, string downloadName, object model = null)
		{
			return ExcelView(controller, downloadName, null, null, model);
		}

		/// <summary></summary>
		public static ViewResult ExcelView(this Controller controller, string downloadName, string viewName, object model = null)
		{
			return ExcelView(controller, downloadName, viewName, null, model);
		}

		/// <summary></summary>
		public static ViewResult ExcelView(this Controller controller, string downloadName, string viewName, string masterName, object model = null)
		{
			if (model != null) { controller.ViewData.Model = model; }

			string disposition = "attachment; filename*=UTF-8''" + HttpUtility.UrlEncode(downloadName);
			controller.Response.ContentType = "application/octet-stream";
			controller.Response.AddHeader("Content-Disposition", disposition);
			
			return new ViewResult
			{
				ViewName = viewName,
				MasterName = masterName,
				ViewData = controller.ViewData,
				TempData = controller.TempData,
				ViewEngineCollection = controller.ViewEngineCollection
			};
		}

		/// <summary></summary>
		public static ViewResult ExcelView(this Controller controller, string downloadName, IView view, object model = null)
		{
			if (model != null) { controller.ViewData.Model = model; }

			string disposition = "attachment; filename*=UTF-8''" + HttpUtility.UrlEncode(downloadName);
			controller.Response.ContentType = "application/octet-stream";
			controller.Response.AddHeader("Content-Disposition", disposition);

			return new ViewResult
			{
				View = view,
				ViewData = controller.ViewData,
				TempData = controller.TempData
			};
		}

	}
}