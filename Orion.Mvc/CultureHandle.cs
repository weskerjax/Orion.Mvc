using System.Globalization;
using System.Threading;
using System.Web;

namespace Orion.Mvc
{
	//TODO 重構成 CookieCultureHandle
	/// <summary>多國語言處理</summary>
	public class CultureHandle
    {
		// TODO 重構成 Apply
		/// <summary>從 Cookie 中的值置換當前 Thread 的 Culture </summary>
		public static void Handle(HttpRequest request, string cookieKey = "SystemUICulture")
        {
            var langCookie = request.Cookies[cookieKey];
            if (langCookie == null) { return; }

            if (langCookie.Value == Thread.CurrentThread.CurrentUICulture.Name) { return; }

            Thread.CurrentThread.CurrentCulture =
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(langCookie.Value);
        }
        

    }
}