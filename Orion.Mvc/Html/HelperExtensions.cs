using Orion.API;
using Orion.API.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace Orion.Mvc.Html
{

	/// <summary></summary>
	public static class HelperExtensions
	{
		/// <summary>
		/// FilterQueryString
		/// </summary>
		public static string FilterQueryString(this HtmlHelper helper, string filterNames)
		{
			string[] filterKey = filterNames.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			string queryString = helper.ViewContext.HttpContext.Request.QueryString.ToString();
			NameValueCollection values = HttpUtility.ParseQueryString(queryString);

			foreach (string key in filterKey)
			{
				values.Remove(key);
			}

			return values.ToString();
		}



		/// <summary></summary>
		public static string DisplayName(this HtmlHelper html, Enum enumValue)
		{
			return enumValue.GetDisplayName();

		}





		/*#############################################################*/

		private static string getShowItem<TEnum>(TEnum enumValue)
		{
			if (enumValue == null) { return null; }

			string text = OrionUtils.GetEnumDisplayName(enumValue);
			return string.Format("<span class=\"item-{0}\">{1}</span>",
				HttpUtility.HtmlEncode(enumValue.ToString()), HttpUtility.HtmlEncode(text)
			);
		}

		/// <summary></summary>
		public static MvcHtmlString ShowItem<TEnum>(this HtmlHelper helper, IEnumerable<TEnum> enumValues)
		{
			if (enumValues == null) { return null; }

			var sb = new StringBuilder();
			foreach (var enumValue in enumValues)
			{
				sb.Append(getShowItem(enumValue));
				sb.Append(" ");
			}

			return new MvcHtmlString(sb.ToString());
		}

		/// <summary></summary>
		public static MvcHtmlString ShowItem<TEnum>(this HtmlHelper helper, Nullable<TEnum> enumValue) where TEnum : struct
		{
			if (!enumValue.HasValue) { return null; }
			return new MvcHtmlString(getShowItem(enumValue.Value));
		}

		/// <summary></summary>
		public static MvcHtmlString ShowItem(this HtmlHelper helper, Enum enumValue)
		{
			if (enumValue == null) { return null; }
			return new MvcHtmlString(getShowItem(enumValue));
		}





		private static string getShowItem<K, V>(K value, IDictionary<K, V> selectList)
		{
			if (value == null) { return null; }

			string text = selectList.ContainsKey(value) ? selectList[value].ToString() : value.ToString();

			return string.Format("<span class=\"item-{0}\">{1}</span>",
				HttpUtility.HtmlEncode(value), HttpUtility.HtmlEncode(text)
			);
		}

		/// <summary></summary>
		public static MvcHtmlString ShowItem<K, V>(this HtmlHelper helper, IEnumerable<K> values, IDictionary<K, V> selectList)
		{
			if (values == null) { return null; }

			var sb = new StringBuilder();
			foreach (var value in values)
			{
				sb.Append(getShowItem(value, selectList));
				sb.Append(" ");                
			}

			return new MvcHtmlString(sb.ToString());
		}

		/// <summary></summary>
		public static MvcHtmlString ShowItem<K, V>(this HtmlHelper helper, Nullable<K> value, IDictionary<K, V> selectList) where K : struct
		{
			if (!value.HasValue) { return null; }
			return new MvcHtmlString(getShowItem(value.Value, selectList));
		}

		/// <summary></summary>
		public static MvcHtmlString ShowItem<K, V>(this HtmlHelper helper, K value, IDictionary<K, V> selectList)
		{
			if (value == null) { return null; }
			return new MvcHtmlString(getShowItem(value, selectList));
		}







		/*#############################################################*/


		/// <summary>顯示日期</summary>
		public static string ShowDate(this HtmlHelper helper, DateTime? data)
		{
			if (data == null) { return null; }
			return string.Format(HelperUtils.DateFormat, data);
		}



		/// <summary>顯示民國日期</summary>
		public static string ShowCnDate(this HtmlHelper helper, DateTime? data)
		{
			if (data == null) { return null; }

			int year = data.Value.Year - 1911;
			return string.Format("{0}-{1:MM-dd}", year, data);
		}


		/// <summary>顯示時間</summary>
		public static string ShowTime(this HtmlHelper helper, DateTime? data)
		{
			if (data == null) { return null; }
			return string.Format(HelperUtils.TimeFormat, data);
		}


		/// <summary>顯示日期時間</summary>
		public static string ShowDateTime(this HtmlHelper helper, DateTime? datatime)
		{
			if (datatime == null) { return null; }
			return string.Format(HelperUtils.DatetimeFormat, datatime);
		}


		/// <summary>顯示民國日期時間</summary>
		public static string ShowCnDateTime(this HtmlHelper helper, DateTime? datatime)
		{
			if (datatime == null) { return null; }

			int year = datatime.Value.Year - 1911;
			return string.Format("{0}-{1:MM-dd HH:mm:ss}", year, datatime);
		}


		/// <summary>顯示活動時間</summary>
		public static string ShowLiveTime(this HtmlHelper helper, DateTime? datatime)
		{
			if (datatime == null) { return null; }

			var diff = DateTime.Now - datatime.Value;
			long seconds = (long)diff.TotalSeconds;
			long minutes = (long)diff.TotalMinutes;
			long hours = (long)diff.TotalHours;
			long days = (long)diff.TotalDays;

			if (seconds < 60) { return seconds + " 秒前"; }
			if (minutes < 60) { return minutes + " 分鐘前"; }
			if (hours < 24) { return hours + " 小時前"; }
			if (days < 30) { return days + " 天前"; }
			if (days < 360) { return (days / 30) + " 個月前"; }

			return (days / 360) + " 年前";
		}





		/*#############################################################*/

		/// <summary></summary>
		public static string EnumJson<TEnum>(this HtmlHelper helper)
		{
			return OrionUtils.EnumToDictionary<TEnum>().ToJson();
		}

		/// <summary></summary>
		public static string EnumJson(this HtmlHelper helper, Type type)
		{
			return OrionUtils.EnumToDictionary(type).ToJson();
		}

		/// <summary></summary>
		public static IHtmlString EnumJsonRaw<TEnum>(this HtmlHelper helper)
		{
			return OrionUtils.EnumToDictionary<TEnum>().ToJsonRaw();
		}

		/// <summary></summary>
		public static IHtmlString EnumJsonRaw(this HtmlHelper helper, Type type)
		{
			return OrionUtils.EnumToDictionary(type).ToJsonRaw();
		}






		/*#############################################################*/

		/// <summary></summary>
		public static string BackUrl(this HtmlHelper helper, string defaultUrl = "JavaScript:history.back();void(0);")
		{
			string backUrl = helper.ViewBag.OrionHelperBackUrl as string;
			if (backUrl != null) { return backUrl; }

			var request = helper.ViewContext.HttpContext.Request;
			string requestPath = request.Url.LocalPath;
			string cookieName = requestPath.Replace('/', '-').Trim('-');
			backUrl = request.UrlReferrer?.ToString();

			/* 如果當前頁面與前一頁不相同，則儲存網址*/
			if (backUrl.HasText() && !backUrl.Contains(requestPath))
			{
				var response = helper.ViewContext.HttpContext.Response;
				response.Cookies.Add(new HttpCookie(cookieName) { Path = requestPath, Value = backUrl });
			}
			else
			{
				/* 從 Cookie 取得上次的記錄 */
				backUrl = request.Cookies[cookieName]?.Value ?? defaultUrl;
			}

			/* 紀錄返回網址*/
			helper.ViewBag.OrionHelperBackUrl = backUrl;

			return backUrl;
		}




	}
}