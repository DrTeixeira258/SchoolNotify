using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using Domain.Interfaces.Repositories.Base;
using Data.Repositories.Base;
using Data.Interfaces.Managers;
using Data.Context;
using Data.Interfaces.Context;
using Data.UnitOfWork;

namespace IoC.SimpleInjector
{
    public class SimpleInjectorConfiguration
    {
        public static void RegisterServices(Container container)
        {

            RegisterDataManagers(container);

            RegisterDataLayer(container);

            RegisterApplicationLayer(container);

            var adapter = new SimpleInjectorWebApiDependencyResolver(container);
        }

        public static void StartServiceLocator(Container container)
        {
            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
        }


        private static void RegisterDataLayer(Container container)
        {
            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //container.Register<IColaboradorRepository, ColaboradorRepository>(Lifestyle.Scoped);
        }

        private static void RegisterDataManagers(Container container)
        {
            container.Register<IContextManager, ContextManager>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDbContext, SchoolNotifyContext>(Lifestyle.Scoped);
        }
        private static void RegisterApplicationLayer(Container container)
        {
            //container.Register<IColaboradorAppService, ColaboradorAppService>(Lifestyle.Scoped);
        }





    }
}


