using Autofac;
using Autofac.Extras.NLog;
using Panteon.HelloTask.Configuration;
using Panteon.Realtime.Pusher;
using Panteon.Sdk;
using Panteon.Sdk.Realtime;
using Panteon.Sdk.Utils;

namespace Panteon.HelloTask
{
    public class TaskModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EnvironmentWrapper>().As<IEnvironmentWrapper>().SingleInstance();
     
            builder.RegisterType<JsonNetSerializer>().As<IJsonSerializer>().SingleInstance();

            builder.RegisterType<PubSubClient>().As<IPubSubClient>().SingleInstance();


            builder.Register(context => new HelloTaskConfigProvider(context.Resolve<ILogger>()).ParseSettings()).AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<HelloTask>().As<IPanteonTask>();
        }
    }
}