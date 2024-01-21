using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Serilog;

namespace ByteBrusher.Tests.SmokeTests;

[TestFixture]
public class StartUpTests
{
    private readonly string[] _args =
    [
        "--path", "/example/path",
        "--delete",
        "--video",
        "--textdocuments"
    ];

    [Test]
    public void CreateHostBuilder_ShouldCreateHostWithoutExceptions2()
    {
        // Arrange
        IHostBuilder hostBuilder = ByteBrusher.DependencyResolver.DependencyResolver.CreateHostBuilder(_args);

        // Act & Assert
        IHost host = null!;
        Action buildHostAction = () => host = hostBuilder.Build();
        buildHostAction.Should().NotThrow("because the host should be built without any configuration errors");

        // Asserting that specific services are available
        using (host)
        {
            ILogger? logger = host.Services.GetService<ILogger>();
            logger.Should().NotBeNull("because a logger service should be available in the host services");
            IByteBrusherClient? byteBrusherClient = host.Services.GetService<IByteBrusherClient>();
            byteBrusherClient.Should().NotBeNull("because a byteBrusherClient service should be available in the host services");
        }
    }
}
