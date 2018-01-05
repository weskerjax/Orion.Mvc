using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Orion.API.Extensions;

namespace Orion.Mvc.Html
{

	/// <summary></summary>
	public static class HtmlExcelExportExtensions
	{
		/// <summary></summary>
		public static HtmlExcelExport<T> ExcelExport<T>(this HtmlHelper helper, IEnumerable<T> dataSource) where T : class
		{
			return new HtmlExcelExport<T>(dataSource, helper.ViewContext.Writer);
		}
		
	}


	/// <summary></summary>
	public class HtmlExcelExport<T> where T : class
	{

		private readonly TextWriter _writer;
		private IEnumerable<T> _dataSource;
		private List<string> _columnOrder = new List<string>();
		private Dictionary<string, string> _columnHeaders = new Dictionary<string, string>();
		private Dictionary<string, Delegate> _columnGetters = new Dictionary<string, Delegate>();

		private string _headerStyle = "color: #fff; background: #2d6da3;";


		/// <summary></summary>
		public HtmlExcelExport(IEnumerable<T> dataSource, TextWriter writer)
		{
			_dataSource = dataSource;
			_writer = writer;

			foreach (var prop in typeof(T).GetProperties().Where(x => x.CanRead))
			{
				_columnOrder.Add(prop.Name);
				_columnHeaders[prop.Name] = prop.GetDisplayName() ?? prop.Name;
				_columnGetters[prop.Name] = (Func<T, object>)(x => prop.GetValue(x));
			}
		}


		/// <summary></summary>
		public HtmlExcelExport<T> HeaderStyle(string cssStyle)
		{
			_headerStyle = cssStyle;
			return this;
		}


		/// <summary></summary>
		public HtmlExcelExport<T> ColumnOrder(IEnumerable<string> columnList)
		{
			_columnOrder = columnList.ToList();
			return this;
		}


		/// <summary></summary>
		public HtmlExcelExport<T> Ignore<TProp>(Expression<Func<T, TProp>> expression)
		{
			string name = getPropertyName(expression);
			_columnOrder.Remove(name);
			return this;
		}


		/// <summary></summary>
		public HtmlExcelExport<T> Column<TProp>(Expression<Func<T, TProp>> expression, string header = null)
		{
			string name = getPropertyName(expression);
			Column(name, expression, header);
			return this;
		}


		/// <summary></summary>
		public HtmlExcelExport<T> Column<TProp>(string name, Expression<Func<T, TProp>> expression, string header = null)
		{
			_columnGetters[name] = expression.Compile();
			if (header != null) { _columnHeaders[name] = header; }
			return this;
		}



		/// <summary></summary>
		public void Render()
		{
			Action<T> writeRow = (x => { });

			foreach (var column in _columnOrder)
			{
				if (!_columnGetters.ContainsKey(column)) { continue; }

				writeRow += (x => {
					writeHtml("<td>");
					writeText(_columnGetters[column].DynamicInvoke(x));
					writeHtml("</td>");
				});
			}
			

			writeHtml("<table>");
			writeHtml("<tr class=\"head\">");

			foreach (var column in _columnOrder)
			{
				if (!_columnGetters.ContainsKey(column)) { continue; }

				writeHtml($"<td style=\"{_headerStyle}\">");
				writeText(_columnHeaders[column]);
				writeHtml("</td>");
			}

			writeHtml("</tr>");


			foreach (var row in _dataSource)
			{
				writeHtml("<tr>");
				writeRow(row);
				writeHtml("</tr>");
			}

			writeHtml("</table>");
		}


		/// <summary>
		/// Renders to the TextWriter, and returns null. 
		/// This is by design so that it can be used with inline syntax in views.
		/// </summary>
		public override string ToString()
		{
			Render();
			return null;
		}




		/*===============================================================*/

		private string getPropertyName(LambdaExpression lambdaExpr)
		{
			PropertyInfo prop = lambdaExpr.GetProperty();
			if (prop != null) { return prop.Name; }

			throw new ArgumentException("無法取得 " + lambdaExpr + " 的 Property 名稱"); 
		}

		private void writeHtml(string html)
		{
			_writer.Write(html);
		}

		private void writeText(object obj)
		{
			if (obj == null) { return; }

			if (obj is IHtmlString) { _writer.Write(obj.ToString()); }
			else { _writer.Write(HttpUtility.HtmlEncode(obj.ToString())); }
		}


	}


}
