using Autofac;
using Autofac.Integration.WebApi;
using HomeXTest.API.App_Start;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace HomeXTest.API
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var builder = new ContainerBuilder();
            IocConfig.RegisterDependencies(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);

            appBuilder.UseWebApi(config);
        }
    }
}