using Autofac.Extras.NLog;
using Panteon.Sdk.Configuration;
using Panteon.Sdk.IO;
using Panteon.Sdk.Utils;

namespace Panteon.HelloTask.Configuration
{
    public class HelloTaskConfigProvider : TaskConfigProviderBase<HelloTaskSettings>
    {
        public HelloTaskConfigProvider(ILogger logger, IJsonSerializer jsonSerializer, IFileReader fileReader)
            : base(logger,jsonSerializer,fileReader)
        {
        }
    }
}