using NUnit.Framework;

public class Mmtests
{
    [Test]
    public void DummyTests()
    {
        Assert.AreEqual(1, 2-1);
    }

    [Test]
    public void FailingTests()
    {
        Assert.AreEqual(1, 1);
    }
}
