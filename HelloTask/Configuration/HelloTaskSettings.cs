using Panteon.Sdk.Configuration;

namespace Panteon.HelloTask.Configuration
{
    public class HelloTaskSettings : WorkerSettingsBase, IHelloTaskSettings
    {
        public int PollIntervalSeconds { get; set; }
    }
}