# Panteon.SampleRealtimeWorker

Panteon SampleRealtime Worker

**Worker**
```cs
    public class HelloTask : RealtimePanteonWorker, IDisposable
    {
        public HelloTask(ILogger logger, IHelloTaskSettings taskSettings, IPubSubClient pubSubClient)
            : base(logger, taskSettings, pubSubClient)
        {
        }

        public override string Name
        {
            get { return "My-Hello-Task"; }
        }

        public override bool Init(bool autoRun)
        {
            return Run((task, offset) => DoSomething());
        }

        private void DoSomething()
        {
            string message = string.Format("{0} Hello {1}", Name, DateTime.Now);

            for (int i = 0; i < 1000000; i++)
            {
                var tmp = i / 100000;

                if (i % 100000 == 0)
                {
                    Progress(new ProgressMessage { Message = message, Percent = 10m * tmp });
                }
            }

            Console.WriteLine(message);
        }
    }
```

**Exports**
```cs
[Export(typeof(ITaskExports))]
    public class Exports : ITaskExports
    {
        public ContainerBuilder Builder
        {
            get
            {
                var builder = new ContainerBuilder();

                builder.RegisterModule<WorkerModule>();

                builder.RegisterType<JsonNetSerializer>().As<IJsonSerializer>().SingleInstance();

                builder.RegisterType<PubSubClient>().As<IPubSubClient>().SingleInstance();

                builder.RegisterType<FileSystem>().As<IFileSystem>().SingleInstance();
                builder.RegisterType<FileReader>().As<IFileReader>().SingleInstance();

                builder.Register(
                    context =>
                        new HelloTaskConfigProvider(
                            context.Resolve<ILogger>(),
                            context.Resolve<IJsonSerializer>(),
                            context.Resolve<IFileReader>()
                            )
                            .ParseSettings()
                    ).AsImplementedInterfaces()
                    .SingleInstance();

                builder.RegisterType<HelloTask>().As<IPanteonWorker>();

                return builder;
            }
        }
    }
```
