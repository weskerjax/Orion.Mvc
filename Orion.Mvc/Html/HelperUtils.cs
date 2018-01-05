using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Orion.Mvc.Html
{

	/// <summary></summary>
	public static class HelperUtils
	{

		/// <summary>日期格式 yyyy-MM-dd</summary>
		public const string DateFormat = "{0:yyyy-MM-dd}";

		/// <summary>日期時間格式 yyyy-MM-dd HH:mm:ss</summary>
		public const string DatetimeFormat = "{0:yyyy-MM-dd HH:mm:ss}";

		/// <summary>時間格式 HH:mm:ss</summary>
		public const string TimeFormat = "{0:HH:mm:ss}";

		/// <summary>時間格式 HH:mm:ss</summary>
		public const string TimeSpanFormat = "{0:hh\\:mm\\:ss}";



		/// <summary></summary>
		public static IEnumerable<SelectListItem> ToSelectListItem(IEnumerable<int> selectList)
		{
			IEnumerable<SelectListItem> options = selectList
				.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() });
			return options;
		}

		/// <summary></summary>
		public static IEnumerable<SelectListItem> ToSelectListItem(IEnumerable<string> selectList)
		{
			IEnumerable<SelectListItem> options = selectList
				.Select(x => new SelectListItem { Text = x, Value = x });
			return options;
		}

		/// <summary></summary>
		public static IEnumerable<SelectListItem> ToSelectListItem<K, V>(IDictionary<K, V> selectList)
		{
			IEnumerable<SelectListItem> options = selectList
				.Select(x => new SelectListItem { Value = x.Key.ToString(), Text = x.Value.ToString() });
			return options;
		}

		/// <summary></summary>
		public static IEnumerable<SelectListItem> GetBoolSelectListItem()
		{
			return GetBoolSelectListItem("是", "否");
		}

		/// <summary></summary>
		public static IEnumerable<SelectListItem> GetBoolSelectListItem(string trueLabel, string falseLabel)
		{
			return new[]
			{
				new SelectListItem { Value = "True", Text = trueLabel },
				new SelectListItem { Value = "False", Text = falseLabel },
			};;
		}

		/// <summary></summary>
		public static object GetModelStateValue(HtmlHelper htmlHelper, string key, Type destinationType)
		{
			ModelState modelState;
			if (htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState) && modelState.Value != null)
			{
				return modelState.Value.ConvertTo(destinationType, null);
			}
			return null;
		}



		/// <summary></summary>
		public static ISet<string> GetCurrentValues(HtmlHelper htmlHelper, ModelMetadata metadata, string name, bool multiple)
		{
			string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			if (string.IsNullOrEmpty(fullName)) { throw new ArgumentException("Input 的 Name 不可以為空", "name"); }


			object defaultValue = null;
			if (multiple)
			{ defaultValue = GetModelStateValue(htmlHelper, fullName, typeof(string[])); }
			else
			{ defaultValue = GetModelStateValue(htmlHelper, fullName, typeof(string)); }

			if (defaultValue == null && !string.IsNullOrEmpty(name)) { defaultValue = htmlHelper.ViewData.Eval(name); }
			if (defaultValue == null && metadata != null) { defaultValue = metadata.Model; }
			if (defaultValue == null) { return null; }		


			IEnumerable enumerable = multiple ? defaultValue as IEnumerable : new object[] { defaultValue };

			IEnumerable<string> first = from object x in enumerable select Convert.ToString(x, CultureInfo.CurrentCulture);
			IEnumerable<string> second = from Enum x in enumerable.OfType<Enum>() select x.ToString("d");
			var set = new HashSet<string>(first.Concat(second), StringComparer.OrdinalIgnoreCase);

			return set;
		}



		/// <summary></summary>
		public static IEnumerable<SelectListItem> MarkSelectList(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, bool multiple)
		{
			if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Input 的 Name 不可以為空", "name"); }			
			if (selectList == null) { throw new ArgumentException("必須給 Input List 的選項", "selectList"); }

			ISet<string> values = GetCurrentValues(htmlHelper, metadata, name, multiple);
			if (values == null) { return selectList; }

			var list = selectList.ToList();
			list.ForEach(item =>
			{
				item.Selected = (item.Value != null) ? values.Contains(item.Value) : values.Contains(item.Text);
			});

			return list;
		}





		/// <summary>判斷是否為可編輯</summary>
		public static bool IsEditable(IDictionary<string, object> htmlAttributes)
		{
			string key = htmlAttributes.Keys.FirstOrDefault(x => x.Equals("editable", StringComparison.OrdinalIgnoreCase));
			if (key == null) { return true; }

			var editable = htmlAttributes[key] as bool?;
			return (!editable.HasValue || editable.Value != false);
		}


		/// <summary>清除 Bool = false 的 Html 屬性</summary>
		public static void ClearBoolAttribute(IDictionary<string, object> htmlAttributes)
		{

			foreach (var key in htmlAttributes.Keys.ToList())
			{
				var value = htmlAttributes[key] as bool?;

				if (value.HasValue && value.Value == false)
				{
					htmlAttributes.Remove(key);
				}
				else if (key.Equals("editable", StringComparison.OrdinalIgnoreCase))
				{
					htmlAttributes.Remove(key);
				}
			}
		}



		/// <summary>標準化 HTML 屬性</summary>
		public static void StandardAttribute(IDictionary<string, object> htmlAttributes)
		{
			/*修正 Class 與 class 不一致的問題*/
			if (htmlAttributes.ContainsKey("Class"))
			{
				string cssClass = htmlAttributes["Class"].ToString();
				if (htmlAttributes.ContainsKey("class"))
				{
					cssClass += " " + htmlAttributes["class"].ToString();
				}
				cssClass = string.Join(" ", cssClass.Split(' ').Distinct());

				htmlAttributes.Remove("Class");
				htmlAttributes["class"] = cssClass;
			}
		}


		/// <summary>增加 css class</summary>
		public static void AddCssClass(IDictionary<string, object> htmlAttributes, string styleClass)
		{
			string key = htmlAttributes.Keys.FirstOrDefault(x => x.Equals("class", StringComparison.OrdinalIgnoreCase));
			if (key == null) { htmlAttributes["class"] = styleClass; return; }

			string value = htmlAttributes[key] as string;
			if (value == null) { htmlAttributes[key] = styleClass; return; }

			htmlAttributes[key] = styleClass + " " + value;
		}


	}

}