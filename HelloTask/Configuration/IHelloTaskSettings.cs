using Panteon.Sdk.Configuration;

namespace Panteon.HelloTask.Configuration
{
    public interface IHelloTaskSettings : ITaskSettings
    {
        int PollIntervalSeconds { get; set; }
    }
}