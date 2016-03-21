using System;
using Autofac.Extras.NLog;
using Panteon.SampleRealtimeTask.Configuration;
using Panteon.Sdk;
using Panteon.Sdk.History;
using Panteon.Sdk.Models;
using Panteon.Sdk.Realtime;

namespace Panteon.SampleRealtimeTask
{
    public class HelloRealtimeTask : RealtimePanteonWorker, IDisposable
    {
        public HelloRealtimeTask(ILogger logger, IHelloTaskSettings taskSettings, IPubSubClient pubSubClient, IHistoryStorage storage)
            : base(logger, taskSettings, pubSubClient, storage)
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
                    WorkerLogger.Info(message);
                }
            }

            Console.WriteLine(message);
        }
    }
}