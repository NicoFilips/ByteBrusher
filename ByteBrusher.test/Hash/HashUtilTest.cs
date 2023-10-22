using Moq;
using ByteBrusher.Util.Interface.Hash.Models;

namespace ByteBrusher.test.Hash;

using NUnit.Framework;

public class HashUtilTest
{
    private readonly Mock<IFileAbstraction> _fileStreamMock = new();

    // [Setup]
    // public void Setup()
    // {
    //     _fileStreamMock.Setup(x => x.Start(It.IsAny<string>())).Returns(new FileStream("sfsdf"));
    // }

    [Test]
    public void CalculateChecksum_ValidFile_CalculatesCorrectChecksum()
    {
        Assert.Pass();
    }
}
