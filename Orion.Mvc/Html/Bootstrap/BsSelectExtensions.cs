using Orion.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Orion.Mvc.Html.Bootstrap
{
	/// <summary></summary>
	public static class BsSelectExtensions
	{


		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, string optionLabel = null)
		{
			return BsDropDownList(htmlHelper, name, null, optionLabel, null);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return BsDropDownList(htmlHelper, name, selectList, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsDropDownList(htmlHelper, name, selectList, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes = null)
		{
			return BsDropDownList(htmlHelper, name, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				return staticControlHelper(htmlHelper, null, name, selectList, htmlAttributes);
			}

			HelperUtils.AddCssClass(htmlAttributes, "form-control");
			return htmlHelper.DropDownList(name, selectList, optionLabel, htmlAttributes);
		}


		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return BsDropDownListFor(htmlHelper, expression, selectList, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsDropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes = null)
		{
			return BsDropDownListFor(htmlHelper, expression, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				if (expression == null) { throw new ArgumentNullException("expression"); }
				ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
				return staticControlHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
			}

			HelperUtils.AddCssClass(htmlAttributes, "form-control");
			return htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes);
		}



		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsEnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes = null)
		{
			return BsEnumDropDownListFor(htmlHelper, expression, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsEnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
		{
			return BsEnumDropDownListFor(htmlHelper, expression, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsEnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string optionLabel, object htmlAttributes = null)
		{
			return BsEnumDropDownListFor(htmlHelper, expression, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary></summary>
		public static MvcHtmlString BsEnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			if (expression == null) { throw new ArgumentNullException("expression"); }

			ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
			if (modelMetadata == null) { throw new ArgumentNullException("無效的 expression 參數，沒有描述資訊"); }
			if (modelMetadata.ModelType == null) { throw new ArgumentNullException("無效的 expression 參數，沒有描述資訊"); }

			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary(modelMetadata.ModelType);
			return htmlHelper.BsDropDownListFor(expression, selectList, optionLabel, htmlAttributes);
		}



		/*==================================================== */


		private static MvcHtmlString staticControlHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			var list = HelperUtils.MarkSelectList(htmlHelper, metadata, name, selectList, false);

			foreach (SelectListItem item in list)
			{
				if (!item.Selected) { continue; }
				return htmlHelper.BsStaticControl(name, item.Value, item.Text, htmlAttributes);
			}

			htmlAttributes["editable"] = false;
			return htmlHelper.BsTextBox(name, null, htmlAttributes); 
		}
		


	}
}
