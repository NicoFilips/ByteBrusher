using ByteBrusher.Util.Abstraction.Hash.Models;
using Moq;

namespace ByteBrusher.Integrationtest.Hash;

public class HashUtilTest
{
    private readonly Mock<IFileAbstraction> _fileStreamMock = new();

    // [Setup]
    // public void Setup()
    // {
    //     _fileStreamMock.Setup(x => x.Start(It.IsAny<string>())).Returns(new FileStream("sfsdf"));
    // }

}
