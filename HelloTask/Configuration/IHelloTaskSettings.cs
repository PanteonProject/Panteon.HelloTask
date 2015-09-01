using Panteon.Sdk.Configuration;

namespace Panteon.HelloTask.Configuration
{
    public interface IHelloTaskSettings : IWorkerSettings
    {
        int PollIntervalSeconds { get; set; }
    }
}