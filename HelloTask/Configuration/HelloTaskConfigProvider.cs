using Autofac.Extras.NLog;
using Panteon.Sdk.Configuration;

namespace Panteon.HelloTask.Configuration
{
    public class HelloTaskConfigProvider : TaskConfigProviderBase<HelloTaskSettings>
    {
        public HelloTaskConfigProvider(ILogger logger)
            : base(logger)
        {
        }

        public override HelloTaskSettings ParseSettings(string configFilePath = null)
        {
            return new HelloTaskSettings
            {
                PollIntervalSeconds = 10,
                RedisConnectionString = "localhost:6379",
                SchedulePattern = "min(*)",
                DbNo = -1
            };
        }
    }
}