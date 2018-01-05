using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace Orion.Mvc.Html.Bootstrap
{

	/// <summary></summary>
    public static class BsSelectDictionaryExtensions
    {

		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
        {
            return BsDropDownList(htmlHelper, name, selectList, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
        {
            return BsDropDownList(htmlHelper, name, selectList, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
        {
            return BsDropDownList(htmlHelper, name, selectList, null, htmlAttributes);
        }


		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
        }


		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, string optionLabel, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, string optionLabel, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, string optionLabel, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }


		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<int> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }

		/// <summary></summary>
		public static MvcHtmlString BsDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<string> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }

		/// <summary></summary>
		public static MvcHtmlString BsDropDownList<K, V>(this HtmlHelper htmlHelper, string name, IDictionary<K, V> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BsDropDownList(name, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }






        /*==================================================== */


		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, IDictionary<string, object> htmlAttributes)
        {
            return BsDropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, IDictionary<string, object> htmlAttributes)
        {
            return BsDropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, IDictionary<string, object> htmlAttributes)
        {
            return BsDropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes);
        }

		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), null, htmlAttributes);
        }


		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, string optionLabel, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, string optionLabel, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, string optionLabel, object htmlAttributes = null)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }


		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<int> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<string> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
		/// <summary></summary>
		public static MvcHtmlString BsDropDownListFor<TModel, TProperty, K, V>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<K, V> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.BsDropDownListFor(expression, HelperUtils.ToSelectListItem(selectList), optionLabel, htmlAttributes);
        }
         

    }
}