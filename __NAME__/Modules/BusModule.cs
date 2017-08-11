using Autofac;
using System;
using MassTransit;
using System.Configuration;

namespace __NAME__.Modules
{
    public class BusModule : Autofac.Module
    {
        public string HostAddress { get; set; }
        public string VirtualHost { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        private static BusConfiguration _busConfiguration = (BusConfiguration)ConfigurationManager.GetSection("BusConfiguration");
        private readonly System.Reflection.Assembly[] _assembliesToScan;

        public BusModule(params System.Reflection.Assembly[] assembliesToScan)
        {
            _assembliesToScan = assembliesToScan;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_assembliesToScan)
               .Where(t =>
               {
                   var a = typeof(IConsumer).IsAssignableFrom(t);
                   return a;
               })
               .AsSelf();

            builder.Register(context =>
                 Bus.Factory.CreateUsingRabbitMq(cfg =>
                  {
                      var host = cfg.Host(new Uri(_busConfiguration.HostAddress), _busConfiguration.VirtualHost, h =>
                      {

                          h.Username(_busConfiguration.Username);
                          h.Password(_busConfiguration.Password);
                      });
                      cfg.ReceiveEndpoint(host, ec =>
                      {
                         ec.LoadFrom(context.Resolve<ILifetimeScope>());
                      });
                  })
            ).SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }



    }
}
