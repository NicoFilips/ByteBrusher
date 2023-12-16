using ByteBrusher.Util.Implementation.Arguments;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Serilog;

namespace ByteBrusher.Tests.SmokeTests;

[TestFixture]
public class StartUpTests
{
    private readonly string[] _args = new string[]
    {
        "--path", "/example/path",
        "--delete",
        "--video",
        "--textdocuments"
    };

    [Test]
    public void CreateHostBuilder_ShouldCreateHostWithoutExceptions2()
    {
        // Arrange
        IHostBuilder hostBuilder = DependencyResolver.DependencyResolver.CreateHostBuilder(_args);

        // Act & Assert
        IHost host = null!;
        Action buildHostAction = () => host = hostBuilder.Build();
        buildHostAction.Should().NotThrow("because the host should be built without any configuration errors");

        // Asserting that specific services are available
        using (host)
        {
            ILogger? logger = host.Services.GetService<ILogger>();
            logger.Should().NotBeNull("because a logger service should be available in the host services");

            // Optional: Add more checks for other specific services
            // ...
        }
    }

    [Test]
    public void ParseCommandLineOptions_WithAllArguments_ShouldReturnValidCliOptions()
    {
        // Arrange
        string[] args = new string[]
        {
            "--path", "/example/path",
            "--delete",
            "--video",
            "--textdocuments"
        };

        // Act
        CliOptions result = DependencyResolver.DependencyResolver.ParseCommandLineOptions(args);

        // Assert
        result.Should().NotBeNull();
        result.Path.Should().Be("/example/path");
        result.DeleteFlag.Should().BeTrue();
        result.IncludeVideos.Should().BeTrue();
        result.IncludeDocuments.Should().BeTrue();
    }

    [Test]
    public void ParseCommandLineOptions_WithMissingRequiredArgument_ShouldThrowException()
    {
        // Arrange
        string[] args = new string[]
        {
            "--delete",
            "--video",
            "--textdocuments"
        };

        // Act
        Action act = () => DependencyResolver.DependencyResolver.ParseCommandLineOptions(args);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}
