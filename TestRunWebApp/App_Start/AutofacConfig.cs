using Autofac;
using Autofac.Integration.Mvc;
using Orion.API;
using Orion.Mvc.Security;
using Orion.Mvc.UI;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TestRunWebApp
{
    public class AutofacConfig
    {

        public static void Bootstrapper()
        {

            var builder = new ContainerBuilder();


            var server = HttpContext.Current.Server;
            builder.RegisterInstance(new MenuProvider(server.MapPath("~/Menu.config")));
            builder.RegisterInstance(new BreadcrumbProvider(server.MapPath("~/Breadcrumb.config")));
            
            

            var asm = Assembly.GetExecutingAssembly();

            //builder.RegisterType<UserServiceClient>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<OrionNLogLogger>().As<IOrionLogger>().SingleInstance();


            builder.RegisterType<SignInStoreCookie>().As<ISignInStore>();
            builder.RegisterType<SignInManager>().As<ISignInManager>();



            // Register MVC controllers.
            builder.RegisterControllers(asm);


            // OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(asm);
            //builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();


            var container = builder.Build();

            // 指定解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
        

    }
}