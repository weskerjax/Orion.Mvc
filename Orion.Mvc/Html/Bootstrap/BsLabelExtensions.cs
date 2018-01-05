using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Orion.API.Extensions;

namespace Orion.Mvc.Html.Bootstrap
{

	/// <summary></summary>
	public static class BsLabelExtensions
    {


		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, string expression, string labelText = null)
        {
            return BsLabel(htmlHelper, expression, labelText, null);
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, string expression, object htmlAttributes)
        {
            return BsLabel(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, string expression, IDictionary<string, object> htmlAttributes)
        {
            return BsLabel(htmlHelper, expression, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, string expression, string labelText, object htmlAttributes)
        {
            return BsLabel(htmlHelper, expression, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, string expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

            HelperUtils.AddCssClass(htmlAttributes, "control-label");
            return htmlHelper.Label(expression, labelText, htmlAttributes);
        }



		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, Enum expression)
		{
			return BsLabel(htmlHelper, expression, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, Enum expression, object htmlAttributes)
		{
			return BsLabel(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsLabel(this HtmlHelper htmlHelper, Enum expression, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			HelperUtils.AddCssClass(htmlAttributes, "control-label");
			string labelText = expression.GetDisplayName();
			return htmlHelper.Label(expression.ToString(), labelText, htmlAttributes);
		}




		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText = null)
        {
            return BsLabelFor(htmlHelper, expression, labelText, null);
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return BsLabelFor(htmlHelper, expression, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            return BsLabelFor(htmlHelper, expression, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
        {
            return BsLabelFor(htmlHelper, expression, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

            HelperUtils.AddCssClass(htmlAttributes, "control-label");
            return htmlHelper.LabelFor(expression, labelText, htmlAttributes);
        }



        /*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsLabelForModel(this HtmlHelper htmlHelper, string labelText = null)
        {
            return BsLabelForModel(htmlHelper, labelText, null);
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelForModel(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            return BsLabelForModel(htmlHelper, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelForModel(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes)
        {
            return BsLabelForModel(htmlHelper, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelForModel(this HtmlHelper htmlHelper, string labelText, object htmlAttributes)
        {
            return BsLabelForModel(htmlHelper, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsLabelForModel(this HtmlHelper htmlHelper, string labelText, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

            HelperUtils.AddCssClass(htmlAttributes, "control-label");
            return htmlHelper.LabelForModel(labelText, htmlAttributes);
        }

    }

}
