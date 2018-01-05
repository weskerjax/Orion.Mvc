using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace Orion.Mvc.Html
{

	/// <summary></summary>
	public static class SelectDictionaryExtensions
	{

		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownList(htmlHelper, name, selectList, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownList(htmlHelper, name, selectList, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownList(htmlHelper, name, selectList, null, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, string optionLabel, object htmlAttributes = null)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, string optionLabel, object htmlAttributes = null)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, string optionLabel, object htmlAttributes = null)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString DropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}








		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
		}

		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, string optionLabel, object htmlAttributes = null)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, string optionLabel, object htmlAttributes = null)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, string optionLabel, object htmlAttributes = null)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString DropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
		}





		/// <summary></summary>
		public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return ListBox(htmlHelper, name, selectList, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return ListBox(htmlHelper, name, selectList, htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBox<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return ListBox(htmlHelper, name, selectList, htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return htmlHelper.ListBox(name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBox(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return htmlHelper.ListBox(name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBox<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return htmlHelper.ListBox(name, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
		{
			return htmlHelper.ListBoxFor(expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
		{
			return htmlHelper.ListBoxFor(expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBoxFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
		{
			return htmlHelper.ListBoxFor(expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}


		/// <summary></summary>
		public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}
		/// <summary></summary>
		public static MvcHtmlString ListBoxFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), htmlAttributes);
		}

	}
}