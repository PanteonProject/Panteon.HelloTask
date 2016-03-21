using Panteon.Sdk.Configuration;

namespace Panteon.SampleRealtimeTask.Configuration
{
    public interface IHelloTaskSettings : IWorkerSettings
    {
        int PollIntervalSeconds { get; set; }
    }
}