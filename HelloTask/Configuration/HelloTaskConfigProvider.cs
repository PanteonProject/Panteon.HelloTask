using System.IO;
using System.Reflection;
using Autofac.Extras.NLog;
using Panteon.Sdk.Configuration;
using Panteon.Sdk.IO;
using Panteon.Sdk.Utils;

namespace Panteon.HelloTask.Configuration
{
    public class HelloTaskConfigProvider : TaskConfigProviderBase<HelloTaskSettings>
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IFileReader _fileReader;

        public HelloTaskConfigProvider(ILogger logger, IJsonSerializer jsonSerializer, IFileReader fileReader)
            : base(logger,jsonSerializer,fileReader)
        {
            _jsonSerializer = jsonSerializer;
            _fileReader = fileReader;
        }

        public override HelloTaskSettings ParseSettings(string configFilePath = null)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrEmpty(directoryName))
                configFilePath = configFilePath ?? Path.Combine(directoryName, "config.json");

            return _jsonSerializer.Deserialize<HelloTaskSettings>(_fileReader.ReadFileContent(configFilePath).Content);
        }
    }
}