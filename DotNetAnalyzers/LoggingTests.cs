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
        logger.HelloWorld(name);
    }
}

public static partial class LoggerExtensions
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Hello, world from {Name}!"
    )]
    public static partial void HelloWorld(this ILogger logger, string name);
}
