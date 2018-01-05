using Orion.Mvc.Attributes;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.API.Extensions;


namespace Orion.Mvc.Attributes
{
	/// <summary></summary>
	public class SearchRememberAttribute : ActionFilterAttribute
    {
        private static string _storeName = "sr"; 

        private static string[] _skipKey = { 
            "PageIndex", 
            "PageSize", 
            "OrderField", 
            "Descending" 
        };


		/// <summary></summary>
		public string StoreKeyParam { get; set; }

		/// <summary></summary>
		public string[] StoreOnly { get; set; } = new string[0];

		/// <summary></summary>
		public string[] Ignore { get; set; } = new string[0];

		/// <summary></summary>
		public SearchRememberAttribute() { }


		/// <summary></summary>
		public override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            base.OnActionExecuting(filterContext);

			/* 略過重導向 */
			if (filterContext.Controller.TempData.ContainsKey("Redirected"))
			{ filterContext.Controller.TempData.Remove("Redirected"); return; }


			var request = filterContext.HttpContext.Request;

            /* 複製 QueryString */
            var qs = HttpUtility.ParseQueryString(request.QueryString.ToString());
			string storeName = qs[StoreKeyParam] ?? _storeName;
			qs.Remove(StoreKeyParam);


			/* 移除不紀錄的參數 */
			if (StoreOnly.Length > 0)
			{
				foreach (string key in qs.AllKeys)
				{

					if (StoreOnly.Contains(key)) { continue; }
					if (_skipKey.Contains(key)) { continue; }
					qs.Remove(key);
				}
			}

			/* 移除忽略的參數 */
			foreach (string key in Ignore) { qs.Remove(key); }


			/* 有參數則記錄 */
			if (qs.Count > 0)
            {
				foreach (var key in _skipKey) { qs.Remove(key); }

                var saveCookie = new HttpCookie(storeName, qs.ToString()) { 
                    Path = request.Path,
                    Expires = DateTime.Now.AddYears(1)
                };
                filterContext.HttpContext.Response.Cookies.Add(saveCookie);
                return; 
            }

            /* 取回記錄中的參數 */
            var cookie = request.Cookies[storeName];
			if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value)) { return; }

			var store = HttpUtility.ParseQueryString(cookie.Value);
			foreach (string key in request.QueryString) { store[key] = request.QueryString[key]; }

			filterContext.Controller.TempData["Redirected"] = true;
            filterContext.Result = new RedirectResult(request.Path + "?" + store.ToString());
        }

    }
}
