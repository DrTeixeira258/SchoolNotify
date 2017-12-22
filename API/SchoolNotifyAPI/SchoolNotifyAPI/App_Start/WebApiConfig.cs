using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Globalization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SchoolNotifyAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.Culture = CultureInfo.CurrentCulture;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;

            string corsDomains = ConfigurationManager.AppSettings.Get("CorsDomains");
            var corsAttr = new EnableCorsAttribute(corsDomains, "accept,content-type,origin,x-my-header", "*");
            corsAttr.SupportsCredentials = true;
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
