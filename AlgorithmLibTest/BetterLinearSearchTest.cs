using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class BetterLinearSearchTest
{
    [Test]
    public void Test1()
    {
        var list = new List<IComparable> { 1, 2, 3, 4, 5, 6 };
        var index = BetterLinearSearch.Search(list, 4);
        Assert.That(index, Is.EqualTo(3));
        Assert.Pass();
    }
    
    [Test]
    public void Test2()
    {
        var list = new List<IComparable> { 1, 2, 3, 4, 5, 6 };
        var index = BetterLinearSearch.Search(list, 8);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    public void Test3()
    {
        var list = new List<IComparable> { "cat", "dog", "pig", "chicken", "duck" };
        var index = BetterLinearSearch.Search(list, "pig");
        Assert.That(index, Is.EqualTo(2));
        Assert.Pass();
    }
    
    [Test]
    public void Test4()
    {
        var list = new List<IComparable> { "cat", "dog", "pig", "chicken", "duck" };
        var index = BetterLinearSearch.Search(list, "eagle");
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
}