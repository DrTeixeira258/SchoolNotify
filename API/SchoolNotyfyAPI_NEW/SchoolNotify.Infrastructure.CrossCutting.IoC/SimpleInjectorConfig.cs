using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace SchoolNotify.Infrastructure.CrossCutting.IoC
{
    public class SimpleInjectorConfig
    {
        public static void StartServiceLocator(Container container)
        {
            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
        }
    }
}
