using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Orion.Mvc.Html.Bootstrap
{
	/// <summary></summary>
	public static class BsCnDatetimeExtensions
    {


		/// <summary>民國日期</summary>
        public static MvcHtmlString BsCnDateBox(this HtmlHelper htmlHelper, string name, object value = null)
        {
            return htmlHelper.BsCnDateBox(name, value, null);
        }
        /// <summary>民國日期</summary>
        public static MvcHtmlString BsCnDateBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes = null)
        {
            return htmlHelper.BsCnDateBox(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        /// <summary>民國日期</summary>
        public static MvcHtmlString BsCnDateBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
            htmlAttributes["ext-picker"] = "cn-date";

            if (value is DateTime?)
            {
                value = htmlHelper.ShowCnDate((DateTime?)value);
            }

            return htmlHelper.BsTextBox(name, value, htmlAttributes);
        }



        /// <summary>民國日期</summary>
        public static MvcHtmlString BsCnDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.BsCnDateBoxFor(expression, null);
        }
        /// <summary>民國日期</summary>
        public static MvcHtmlString BsCnDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return htmlHelper.BsCnDateBoxFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        /// <summary>民國日期</summary>
        public static MvcHtmlString BsCnDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
            htmlAttributes["ext-picker"] = "cn-date";

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string value = htmlHelper.ShowCnDate((DateTime?)metadata.Model);

            return htmlHelper.BsTextBox(ExpressionHelper.GetExpressionText(expression), value, htmlAttributes);
        }




		/*==================================================================*/

		/// <summary>民國日期時間</summary>
		public static MvcHtmlString BsCnDateTimeBox(this HtmlHelper htmlHelper, string name, object value = null)
		{
			return htmlHelper.BsCnDateTimeBox(name, value, null);
		}
		/// <summary>民國日期時間</summary>
		public static MvcHtmlString BsCnDateTimeBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes = null)
		{
			return htmlHelper.BsCnDateTimeBox(name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary>民國日期時間</summary>
		public static MvcHtmlString BsCnDateTimeBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "cn-datetime";

			if (value is DateTime?)
			{
				value = htmlHelper.ShowCnDateTime((DateTime?)value);
			}

			return htmlHelper.BsTextBox(name, value, htmlAttributes);
		}



		/// <summary>民國日期時間</summary>
		public static MvcHtmlString BsCnDateTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return htmlHelper.BsCnDateTimeBoxFor(expression, null);
		}
		/// <summary>民國日期時間</summary>
		public static MvcHtmlString BsCnDateTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
		{
			return htmlHelper.BsCnDateBoxFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary>民國日期時間</summary>
		public static MvcHtmlString BsCnDateTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }
			htmlAttributes["ext-picker"] = "cn-datetime";

			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
			string value = htmlHelper.ShowCnDateTime((DateTime?)metadata.Model);

			return htmlHelper.BsTextBox(ExpressionHelper.GetExpressionText(expression), value, htmlAttributes);
		}


	}
}
