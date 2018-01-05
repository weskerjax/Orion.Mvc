using Orion.API;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Orion.Mvc.Html.Bootstrap
{

	/// <summary></summary>
	public static class BsCheckboxRadioExtensions  
	{


		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioList(this HtmlHelper htmlHelper, string name, object htmlAttributes = null)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioList(this HtmlHelper htmlHelper, string name, string trueLabel, string falseLabel, object htmlAttributes = null)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsRadioList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return BsRadioList(htmlHelper, name, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}


		
		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioList(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioList(this HtmlHelper htmlHelper, string name, string trueLabel, string falseLabel, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsRadioList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				return staticControlHelper(htmlHelper, null, name, selectList, "radio", htmlAttributes);
			}

			return htmlHelper.RadioList(name, selectList, htmlAttributes);
		}








		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, object htmlAttributes = null)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, string trueLabel, string falseLabel, object htmlAttributes = null)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsEnumRadioListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes = null)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return BsRadioListFor(htmlHelper, expression, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}




		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsBoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, string trueLabel, string falseLabel, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsEnumRadioListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsRadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsRadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				if (expression == null) { throw new ArgumentNullException("expression"); }
				ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
				return staticControlHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, "radio", htmlAttributes);
			}

			return htmlHelper.RadioListFor(expression, selectList, htmlAttributes);			
		}









		/*==================================================== */




		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return BsCheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return BsCheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return BsCheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return BsCheckboxList(htmlHelper, name, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}


		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsCheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsCheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsCheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				return staticControlHelper(htmlHelper, null, name, selectList, "checkbox", htmlAttributes);
			}

			return htmlHelper.CheckboxList(name, selectList, htmlAttributes);
		}







		/*==================================================== */

		/// <summary></summary>
		public static MvcHtmlString BsEnumCheckboxListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TEnum>>> expression, object htmlAttributes = null)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return BsCheckboxListFor(htmlHelper, expression, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}


		/// <summary></summary>
		public static MvcHtmlString BsEnumCheckboxListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TEnum>>> expression, IDictionary<string, object> htmlAttributes)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return BsCheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BsCheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			if (htmlAttributes == null) { htmlAttributes = new Dictionary<string, object>(); }

			bool isEdit = HelperUtils.IsEditable(htmlAttributes);
			HelperUtils.ClearBoolAttribute(htmlAttributes);
			HelperUtils.StandardAttribute(htmlAttributes);

			if (!isEdit)
			{
				if (expression == null) { throw new ArgumentNullException("expression"); }
				ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
				return staticControlHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, "checkbox", htmlAttributes);
			}

			return htmlHelper.CheckboxListFor<TModel, TProperty>(expression, selectList, htmlAttributes);
		}



		/*==================================================== */


		private static string generateHtml(string name, string value, string text, IDictionary<string, object> htmlAttributes)
		{
			var input = new TagBuilder("input");
			input.Attributes["type"] = "hidden";
			input.Attributes["name"] = name;
			input.Attributes["value"] = value;

			var label = new TagBuilder("label");
			label.InnerHtml = input.ToString(TagRenderMode.SelfClosing) + HttpUtility.HtmlEncode(text);
			label.MergeAttributes(htmlAttributes);
			label.AddCssClass("editable-fix");

			return label.ToString(TagRenderMode.Normal);
		}



		private static MvcHtmlString staticControlHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, string type, IDictionary<string, object> htmlAttributes)
		{
			string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			var list = HelperUtils.MarkSelectList(htmlHelper, metadata, name, selectList, type == "checkbox");

			var sb = new StringBuilder();
			foreach (SelectListItem item in list)
			{
				if (!item.Selected) { continue; }
				sb.AppendLine(generateHtml(fullName, item.Value, item.Text, htmlAttributes));
			}

			return new MvcHtmlString(sb.ToString());
		}
		
	}

}