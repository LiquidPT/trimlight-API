namespace TrimlightData.UnitTest;

[TestClass]
public sealed class ExtensionMethodTests
{
    [TestMethod]
    public void HMACSHA256Hash()
    {
        string stringToEncode = "Trimlight|user|1733353597983";
        string secretKey = "nG4cZmRv^KWN#haXaHIc1F70xR*45n1T";
        string expectedValue = "s3SwqiSX8284BfI1GGNAu9N5NxZUmzMLeXmU+wcC63Q=";

        string value = stringToEncode.HMACSHA256Hash(secretKey);
        Assert.IsNotNull(value);
        Assert.AreEqual(expectedValue, value);
    }
}
