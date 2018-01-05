using Orion.API;
using System;
using System.Globalization;
using System.Web.Mvc;
using Orion.API.Extensions;

namespace Orion.Mvc.ModelBinder
{
	/// <summary></summary>
	public class CnDateTimeModelBinder : IModelBinder
	{
		/// <summary></summary>
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
			if(value == null) { return null; }

			string attempted = value.AttemptedValue?.Trim();
			try
			{
				if (attempted.IsMatch(@"^\d{4}"))
				{
					return value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
				}
				else
				{
					return OrionUtils.ParseCnDateTime(attempted) ?? OrionUtils.ParseCnDate(attempted);
				}
			}
			catch { }

			return null;
		}
	}

}
