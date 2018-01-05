using Orion.API.Models;
using Orion.API.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Collections;

namespace Orion.Mvc.ModelBinder
{
	/// <summary></summary>
	public class WhereParamsModelBinder : IModelBinder
	{

		/// <summary></summary>
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (bindingContext == null) { throw new ArgumentNullException("bindingContext"); }

			var requestParams = new NameValueCollection();
			requestParams.Add(controllerContext.HttpContext.Request.Form);
			requestParams.Add(controllerContext.HttpContext.Request.QueryString);

			Type type = bindingContext.ModelType.GetGenericArguments()[0];
			return CreateWhereParams(type, requestParams);
		}




		/// <summary></summary>
		public object CreateWhereParams(Type type, NameValueCollection data)
		{
			Type makeme = typeof(WhereParams<>).MakeGenericType(type);
			var param = (IWhereParams)Activator.CreateInstance(makeme);
	
			foreach (var prop in type.GetProperties())
			{
				string strValue = data.GetValues(prop.Name)?.FirstOrDefault();
				if (string.IsNullOrWhiteSpace(strValue)) { continue; }

				Type propType = prop.PropertyType;
				if (propType.IsArray) 
				{
					propType = propType.GetElementType();
				}
				else if (propType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(propType))
				{ 
					propType = propType.GenericTypeArguments.First();					
				}

				var res = parseStringValue(propType, strValue.Trim());
				if(res.Values.Length == 0) { continue; }

				param.SetValues(prop.Name, res.Operator, res.Values);
			}
		
			return param;
		}




		private ParseResult parseStringValue(Type propType, string strValue)
		{			
			var result = new ParseResult {
				Operator = WhereOperator.Undefined
			};


			/* Between */
			if (strValue.Contains(".."))
			{
				var split = strValue.Split(new string[] { ".." }, StringSplitOptions.None);

				if (string.IsNullOrWhiteSpace(split[0]))
				{
					result.Operator = WhereOperator.LessEquals;
					result.Values = convertTo(propType, split[1]);
				}
				else if (string.IsNullOrWhiteSpace(split[1]))
				{
					result.Operator = WhereOperator.GreaterEquals;
					result.Values = convertTo(propType, split[0]);
				}
				else
				{
					result.Operator = WhereOperator.Between;
					result.Values = convertTo(propType, split);
				}

				return result;
			}

			

			/* IN */
			if (strValue.Contains("|"))
			{
				if(strValue.StartsWith("!"))
				{
					result.Operator = WhereOperator.NotIn; 
					strValue = strValue.Substring(1);
				}
				else
				{
					result.Operator = WhereOperator.In; 
				}

				result.Values = convertTo(propType, strValue.Split('|'));
				return result;

			}




			/* 雙字運算符 */
			if (strValue.Length >= 2)
			{
				switch (strValue.Substring(0, 2))
				{
					case "<=": result.Operator = WhereOperator.LessEquals; break;
					case ">=": result.Operator = WhereOperator.GreaterEquals; break;
					case "!=": result.Operator = WhereOperator.NotEquals; break;
					case "^=": result.Operator = WhereOperator.StartsWith; break;
					case "$=": result.Operator = WhereOperator.EndsWith; break;
					case "*=": result.Operator = WhereOperator.Contains; break;
				}

				if (result.Operator != WhereOperator.Undefined)
				{
					result.Values = convertTo(propType, strValue.Substring(2));
					return result;
				}
			}




			/* 單字運算符 */
			switch (strValue.Substring(0, 1))
			{
				case "=": result.Operator = WhereOperator.Equals; break;
				case "<": result.Operator = WhereOperator.LessThan; break;
				case ">": result.Operator = WhereOperator.GreaterThan; break;
			}

			if (result.Operator != WhereOperator.Undefined)
			{
				result.Values = convertTo(propType, strValue.Substring(1));
				return result;
			}



			result.Operator = WhereOperator.Equals;
			result.Values = convertTo(propType, strValue);
			return result;
		}



	
		private object[] convertTo(Type propType, params string[] strValues)
		{
			return strValues.Convert(propType).ToArray();
		}




	}



	class ParseResult
	{
		public WhereOperator Operator { get; set; }
		public object[] Values { get; set; }
	}


}
