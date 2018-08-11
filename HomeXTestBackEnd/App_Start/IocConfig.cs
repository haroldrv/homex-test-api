using Autofac;
using Autofac.Integration.WebApi;
using HomeXTest.Domain.Models;
using HomeXTest.Repository;
using HomeXTest.RepositoryInterfaces;
using System.Reflection;

namespace HomeXTest.API.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            builder.RegisterType<HomeXTestRepository<Activity>>()
                .As<IRepository<Activity>>().InstancePerRequest();

            builder.RegisterType<HomeXTestRepository<ActivitiesPeople>>()
                .As<IRepository<ActivitiesPeople>>().InstancePerRequest();
        }
    }
}