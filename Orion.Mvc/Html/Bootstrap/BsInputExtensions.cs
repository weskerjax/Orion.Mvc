using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Orion.Mvc.Html.Bootstrap
{
	/// <summary></summary>
	public static class BsInputExtensions
    {


		/// <summary></summary>
		public static MvcHtmlString BsStaticControl(this HtmlHelper htmlHelper, string name, string value, string text, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("必須給這些 Input 一個 Name", "name");
            }

            var input = new TagBuilder("input");
			input.GenerateId(fullName);
            input.Attributes["type"] = "hidden";
            input.Attributes["name"] = name;
            input.Attributes["value"] = value;

            var span = new TagBuilder("span");
            span.InnerHtml = HttpUtility.HtmlEncode(text);
            span.Attributes["class"] = "value-text";

            var div = new TagBuilder("div");
            div.InnerHtml = input.ToString(TagRenderMode.SelfClosing) + span.ToString(TagRenderMode.Normal);
            div.MergeAttributes(htmlAttributes);
            div.AddCssClass("form-control-static");

            return new MvcHtmlString(div.ToString(TagRenderMode.Normal));
        }




		/// <summary></summary>
		public static MvcHtmlString BsTextBox(this HtmlHelper htmlHelper, string name, object value = null)
        {
            return BsTextBox(htmlHelper, name, value, null);
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBox(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes)
        {
            return BsTextBox(htmlHelper, name, value, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBox(this HtmlHelper htmlHelper, string name, object value, string format, object htmlAttributes = null)
        {
            return BsTextBox(htmlHelper, name, value, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBox(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            return BsTextBox(htmlHelper, name, value, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBox(this HtmlHelper htmlHelper, string name, object value, string format, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

            bool isEdit = HelperUtils.IsEditable(htmlAttributes);
            HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

            if (!isEdit)
            {
                return staticControlHelper(htmlHelper, null, name, value, format, htmlAttributes);
            }

            HelperUtils.AddCssClass(htmlAttributes, "form-control");
            return htmlHelper.TextBox(name, value, format, htmlAttributes);
        }


        /*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return BsTextBoxFor(htmlHelper, expression, null);
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return BsTextBoxFor(htmlHelper, expression, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes = null)
        {
            return BsTextBoxFor(htmlHelper, expression, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return BsTextBoxFor(htmlHelper, expression, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

            bool isEdit = HelperUtils.IsEditable(htmlAttributes);
            HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

            if (!isEdit)
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
                return staticControlHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), metadata.Model, format, htmlAttributes);
            }

            HelperUtils.AddCssClass(htmlAttributes, "form-control");
            return htmlHelper.TextBoxFor(expression, format, htmlAttributes);
        }


        /*==================================================== */

        private static MvcHtmlString staticControlHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, object value, string format, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("必須給這些 Input 一個 Name", "name");
            }


            string valueStr = (string)HelperUtils.GetModelStateValue(htmlHelper, fullName, typeof(string));
            if (valueStr == null) { valueStr = htmlHelper.FormatValue(value, format); }

            return BsStaticControl(htmlHelper, name, valueStr, valueStr, htmlAttributes); 
        }



    }
}
