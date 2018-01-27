using SchoolNotify.API.App_Start;
using SchoolNotify.Infrastructure.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace SchoolNotify.API.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            InitializeContainer(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            SimpleInjectorModule.RegisterServices(container);
            SimpleInjectorConfig.StartServiceLocator(container);
        }
    }
}