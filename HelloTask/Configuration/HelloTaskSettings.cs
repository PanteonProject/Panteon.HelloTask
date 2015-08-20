using Panteon.Sdk.Configuration;

namespace Panteon.HelloTask.Configuration
{
    public class HelloTaskSettings : TaskSettingsBase, IHelloTaskSettings
    {
        public int PollIntervalSeconds { get; set; }
    }
}