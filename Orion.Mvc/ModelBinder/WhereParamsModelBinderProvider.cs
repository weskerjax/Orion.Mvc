using Orion.API.Models;
using System;
using System.Web.Mvc;

namespace Orion.Mvc.ModelBinder
{
	/// <summary></summary>
	public class WhereParamsModelBinderProvider : IModelBinderProvider
	{
		private Type _type = typeof(IWhereParams);
		private WhereParamsModelBinder _binder = new WhereParamsModelBinder();

		/// <summary></summary>
		public IModelBinder GetBinder(Type modelType)
		{
			return _type.IsAssignableFrom(modelType) ? _binder : null;
		}
	}
}
