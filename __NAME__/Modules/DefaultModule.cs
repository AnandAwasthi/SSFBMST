using Autofac;
using AwasthiSM.CommandProcessor.Command;
using AwasthiSM.CommandProcessor.Dispatcher;
using AwasthiSM.Domain.Query;
using AwasthiSM.MassTransit.Client;
using AwasthiSM.Mongo.DatabaseFactory;
using AwasthiSM.ServiceBus;
using System.Reflection;

namespace __NAME__
{
    public class DefaultModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {



            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
            builder.RegisterType<DbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<MassTransitBus>().As<ITransitBus>().InstancePerLifetimeScope();
            var serviceDomainCommand = Assembly.Load("AwasthiSM.Domain.Handler");
            builder.RegisterAssemblyTypes(serviceDomainCommand)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(serviceDomainCommand)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerLifetimeScope();

            var serviceDomainQuery = Assembly.Load("AwasthiSM.Domain.Query");
            builder.RegisterAssemblyTypes(serviceDomainQuery).AssignableTo<IQuery>().AsImplementedInterfaces().InstancePerLifetimeScope();

            var massTransitClient = Assembly.Load("AwasthiSM.MassTransit.Client");
            builder.RegisterAssemblyTypes(massTransitClient)
              .AsClosedTypesOf(typeof(IRequestClient<,>)).InstancePerLifetimeScope();

        }
    }
}
