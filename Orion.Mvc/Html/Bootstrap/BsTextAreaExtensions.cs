using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Orion.Mvc.Html.Bootstrap
{

	/// <summary></summary>
	public static class BsTextAreaExtensions
	{


		/// <summary></summary>
		public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, object htmlAttributes = null)
		{
			return BsTextArea(htmlHelper, name, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return BsTextArea(htmlHelper, name, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes = null)
		{
			return BsTextArea(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
		{
			return BsTextArea(htmlHelper, name, value, 2, 20, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes)
		{
			return BsTextArea(htmlHelper, name, value, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				return staticControlHelper(htmlHelper, null, name, htmlAttributes);
			}

			HelperUtils.AddCssClass(htmlAttributes, "form-control");
			return htmlHelper.TextArea(name, value, rows, columns, htmlAttributes);
		}


		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
		{
			return BsTextAreaFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return BsTextAreaFor(htmlHelper, expression, 2, 20, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes)
		{
			return BsTextAreaFor(htmlHelper, expression, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
				return staticControlHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), htmlAttributes);
			}

			HelperUtils.AddCssClass(htmlAttributes, "form-control");
			return htmlHelper.TextAreaFor(expression, rows, columns, htmlAttributes);
		}


		/*==================================================== */

		private static MvcHtmlString staticControlHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IDictionary<string, object> htmlAttributes)
		{
			string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			if (String.IsNullOrEmpty(fullName))
			{
				throw new ArgumentException("必須給這些 Input List 一個 Name", "name");
			}

			string valueStr = (string)HelperUtils.GetModelStateValue(htmlHelper, fullName, typeof(string));
			if (valueStr == null)
			{
				object value = htmlHelper.ViewData.Eval(name);
				valueStr = (value != null ? value.ToString() : null);
			}

			var input = new TagBuilder("input");
			input.GenerateId(fullName);
			input.Attributes["type"] = "hidden";
			input.Attributes["name"] = fullName;
			input.MergeAttribute("value", valueStr, true);

			var pre = new TagBuilder("pre");
			pre.InnerHtml = HttpUtility.HtmlEncode(valueStr);
			pre.MergeAttributes(htmlAttributes);

			return new MvcHtmlString(input.ToString(TagRenderMode.SelfClosing) + pre.ToString(TagRenderMode.Normal));
		}


	}
}

