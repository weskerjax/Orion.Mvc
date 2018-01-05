using System.Web.Mvc;

namespace Orion.Mvc.ModelBinder
{
	/// <summary></summary>
	public class StringTrimModelBinder : DefaultModelBinder
    {
		/// <summary></summary>
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = base.BindModel(controllerContext, bindingContext);
            return (value is string) ? (value as string).Trim() : value;
        }         
    }
}
