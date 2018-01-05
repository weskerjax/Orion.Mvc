using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Orion.API;

namespace Orion.Mvc.Html
{

	/// <summary></summary>
	public static class CheckboxRadioExtensions 
	{


		/// <summary></summary>
		public static MvcHtmlString BoolRadioList(this HtmlHelper htmlHelper, string name, object htmlAttributes = null)
		{
			return RadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BoolRadioList(this HtmlHelper htmlHelper, string name, string trueLabel, string falseLabel, object htmlAttributes = null)
		{
			return RadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString RadioList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return RadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return RadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return RadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return RadioList(htmlHelper, name, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}



		/// <summary></summary>
		public static MvcHtmlString BoolRadioList(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return RadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BoolRadioList(this HtmlHelper htmlHelper, string name, string trueLabel, string falseLabel, IDictionary<string, object> htmlAttributes)
		{
			return RadioList(htmlHelper, name, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString RadioList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return RadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return RadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return RadioList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return radioListHelper(htmlHelper, null, name, selectList, htmlAttributes);
		}



		/// <summary></summary>
		public static MvcHtmlString BoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, object htmlAttributes = null)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, string trueLabel, string falseLabel, object htmlAttributes = null)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString EnumRadioListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes = null)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return RadioListFor(htmlHelper, expression, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}



		/// <summary></summary>
		public static MvcHtmlString BoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, IDictionary<string, object> htmlAttributes)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString BoolRadioListFor<TModel, TBool>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TBool>> expression, string trueLabel, string falseLabel, IDictionary<string, object> htmlAttributes)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.GetBoolSelectListItem(trueLabel, falseLabel), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString EnumRadioListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return RadioListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString RadioListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			if (expression == null) { throw new ArgumentNullException("expression"); }
			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
			return radioListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
		}


		private static MvcHtmlString radioListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return itemInternal(htmlHelper, metadata, name, selectList, "radio", htmlAttributes);
		}







		/// <summary></summary>
		public static MvcHtmlString CheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return CheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return CheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return CheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return CheckboxList(htmlHelper, name, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}


		/// <summary></summary>
		public static MvcHtmlString CheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return CheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return CheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return CheckboxList(htmlHelper, name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return checkboxListHelper(htmlHelper, null, name, selectList, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString EnumCheckboxListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes = null)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			return CheckboxListFor(htmlHelper, expression, selectList, ((IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));
		}


		/// <summary></summary>
		public static MvcHtmlString EnumCheckboxListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
		{
			IDictionary<string, string> selectList = OrionUtils.EnumToDictionary<TEnum>();
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return CheckboxListFor(htmlHelper, expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			if (expression == null) { throw new ArgumentNullException("expression"); }
			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
			return checkboxListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
		}




		private static MvcHtmlString checkboxListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return itemInternal(htmlHelper, metadata, name, selectList, "checkbox", htmlAttributes);
		}


		private static MvcHtmlString itemInternal(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, string type, IDictionary<string, object> htmlAttributes)
		{

			string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			var list = HelperUtils.MarkSelectList(htmlHelper, metadata, name, selectList, type == "checkbox");

			var sb = new StringBuilder();
			foreach (SelectListItem item in list)
			{
				var input = new TagBuilder("input");
				input.Attributes["type"] = type;
				input.Attributes["name"] = fullName;
				input.Attributes["value"] = item.Value; 

				if (item.Selected) { input.Attributes["checked"] = "checked"; }
				if (item.Disabled) { input.Attributes["disabled"] = "disabled"; }

				var label = new TagBuilder("label")
				{
					InnerHtml = input.ToString(TagRenderMode.SelfClosing) + HttpUtility.HtmlEncode(item.Text)
				};
				label.MergeAttributes<string, object>(htmlAttributes);

				ModelState state;
				if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out state) && (state.Errors.Count > 0))
				{
					label.AddCssClass(HtmlHelper.ValidationInputCssClassName);
				}
				label.MergeAttributes<string, object>(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

				sb.AppendLine(label.ToString(TagRenderMode.Normal));
			}

			return new MvcHtmlString(sb.ToString());
		}
		
		
		
	}

}