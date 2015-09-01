using System;
using Autofac.Extras.NLog;
using Panteon.HelloTask.Configuration;
using Panteon.Sdk;
using Panteon.Sdk.Models;
using Panteon.Sdk.Realtime;

namespace Panteon.HelloTask
{
    public class HelloTask : RealtimePanteonWorker, IDisposable
    {
        public HelloTask(ILogger logger, IHelloTaskSettings taskSettings, IPubSubClient pubSubClient)
            : base(logger, taskSettings, pubSubClient)
        {
        }

        public override string Name => "My-Hello-Task";

        public override bool Init(bool autoRun)
        {
            return Run((task, offset) => DoSomething());
        }

        private void DoSomething()
        {
            string message = $"{Name} Hello {DateTime.Now}";

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
}