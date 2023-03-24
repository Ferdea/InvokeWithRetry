using NUnit.Framework;

namespace InvokeWithRetry;

[TestFixture]
public class InvokeWithRetryTests
{
    [Test]
    public void GoodAction_Test()
    {
        var callCount = 0;
        Action act = () =>
        {
            callCount++;
            Console.WriteLine("404"); 
        };
        var result = InvokeWithRetryClass.InvokeWithRetry(act, 1);
        Assert.IsTrue(result);
        Assert.AreEqual(callCount, 1);
    }
    
    [Test]
    public void NormAction_FalseTest()
    {
        var callCount = 0;
        var a = 0;
        Action act = () =>
        {
            callCount++;
            Console.WriteLine(5 / a);
            a += 1;
        };
        var result = InvokeWithRetryClass.InvokeWithRetry(act, 1);
        Assert.IsFalse(result);
        Assert.AreEqual(callCount, 1);
    }
    
    [Test]
    public void NormAction_TrueTest()
    {
        var callCount = 0;
        var a = -1;
        Action act = () =>
        {
            callCount++;
            a++;
            Console.WriteLine(5 / a);
        };
        var result = InvokeWithRetryClass.InvokeWithRetry(act, 100);
        Assert.IsTrue(result);
        Assert.AreEqual(callCount, 2); // Проверка, что не выполняется лишнее число раз
    }
    
    [Test]
    public void BadAction_Test()
    {
        var callCount = 0;
        var a = 0;
        Action act = () =>
        {
            callCount++;
            Console.WriteLine(5 / a);
        };
        var result = InvokeWithRetryClass.InvokeWithRetry(act, 100);
        Assert.IsFalse(result);
        Assert.AreEqual(callCount, 100);
    }
}