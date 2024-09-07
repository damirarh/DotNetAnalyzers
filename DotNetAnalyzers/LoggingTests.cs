using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetAnalyzers;

public class LoggingTests
{
    private ILogger logger;

    [SetUp]
    public void SetUp()
    {
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddJsonConsole())
            .BuildServiceProvider();

        logger = serviceProvider.GetRequiredService<ILogger<LoggingTests>>();
    }

    [TestCase("NTK")]
    public void LogMessage(string name)
    {
        logger.LogInformation($"Hello, world from {name}!");
    }
}
