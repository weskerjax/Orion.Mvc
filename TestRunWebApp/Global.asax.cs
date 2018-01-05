using Orion.API;
using Orion.Mvc;
using Orion.Mvc.ModelBinder;
using Orion.Mvc.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestRunWebApp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AutofacConfig.Bootstrapper(); 
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			/* Model Binder 配置 */
			ModelBinderProviders.BinderProviders.Add(new WhereParamsModelBinderProvider());
			ModelBinders.Binders.Add(typeof(string), new StringTrimModelBinder());

			ModelBinders.Binders.Add(typeof(DateTime), new CnDateTimeModelBinder());
			ModelBinders.Binders.Add(typeof(DateTime?), new CnDateTimeModelBinder());

		}


		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			/*多國語言處理*/
			CultureHandle.Handle(Request);
		}


		protected void Application_AcquireRequestState(object sender, EventArgs e)
		{
			var signInManager = DependencyResolver.Current.GetService<ISignInManager>();
#if DEBUG
			/*開發時自動登入*/
				IList<string> actList = OrionUtils.EnumToDictionary<ACT>().Keys.ToList();
				actList.Add("DevelopAdmin");
				signInManager.DevelopSignIn(actList);
			try
			{
			}
			catch (Exception) { }
#endif
			signInManager.Authenticate(Context);        
		}


	}

}
