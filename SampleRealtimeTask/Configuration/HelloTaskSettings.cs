using Panteon.Sdk.Configuration;

namespace Panteon.SampleRealtimeTask.Configuration
{
    public class HelloTaskSettings : WorkerSettingsBase, IHelloTaskSettings
    {
        public int PollIntervalSeconds { get; set; }
    }
}