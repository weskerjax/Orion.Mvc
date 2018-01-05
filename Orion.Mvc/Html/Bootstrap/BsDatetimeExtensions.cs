using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Orion.Mvc.Html.Bootstrap
{
	/// <summary></summary>
	public static class BsDatetimeExtensions
	{


		/// <summary></summary>
		public static MvcHtmlString BsDateBox(this HtmlHelper htmlHelper, string name, object value = null)
		{
			return htmlHelper.BsDateBox(name, value, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes = null)
		{
			return htmlHelper.BsDateBox(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "date";
			return htmlHelper.BsTextBox(name, value, HelperUtils.DateFormat, htmlAttributes);
		}



		/// <summary></summary>
		public static MvcHtmlString BsDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return htmlHelper.BsDateBoxFor(expression, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
		{
			return htmlHelper.BsDateBoxFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "date";
			return htmlHelper.BsTextBoxFor(expression, HelperUtils.DateFormat, htmlAttributes);
		}


		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsDateTimeBox(this HtmlHelper htmlHelper, string name, object value = null)
		{
			return htmlHelper.BsDateTimeBox(name, value, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateTimeBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes = null)
		{
			return htmlHelper.BsDateTimeBox(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateTimeBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "datetime";
			return htmlHelper.BsTextBox(name, value, HelperUtils.DatetimeFormat, htmlAttributes);
		}



		/// <summary></summary>
		public static MvcHtmlString BsDateTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return htmlHelper.BsDateTimeBoxFor(expression, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
		{
			return htmlHelper.BsDateTimeBoxFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDateTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "datetime";
			return htmlHelper.BsTextBoxFor(expression, HelperUtils.DatetimeFormat, htmlAttributes);
		}



		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsTimeBox(this HtmlHelper htmlHelper, string name, object value = null)
		{
			return htmlHelper.BsTimeBox(name, value, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsTimeBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes = null)
		{
			return htmlHelper.BsTimeBox(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTimeBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "time";
			//FIXME value 寫測試案例
			return htmlHelper.BsTextBox(name, value, HelperUtils.TimeFormat, htmlAttributes);
		}



		/// <summary></summary>
		public static MvcHtmlString BsTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return htmlHelper.BsTimeBoxFor(expression, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
		{
			return htmlHelper.BsTimeBoxFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			var type = typeof(TProperty);
			var nType = Nullable.GetUnderlyingType(type);
			if (nType != null) { type = nType; }

			string format = HelperUtils.TimeFormat;
			if (type == typeof(TimeSpan)) { format = HelperUtils.TimeSpanFormat; }

			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "time";
			return htmlHelper.BsTextBoxFor(expression, format, htmlAttributes);
		}






	}
}
