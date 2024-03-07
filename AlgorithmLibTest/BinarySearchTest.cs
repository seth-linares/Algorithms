namespace AlgorithmLibTest;
using AlgorithmLib;
using NUnit.Framework;

[TestFixture]
public class BinarySearchTest
{
    [Test]
    /* First Position Match */
    public void Test1()
    {
        IComparable[] array = { 1, 2, 3, 4, 5, 6 };
        var data = new List<IComparable>(array);
        var index = BinarySearch.Search(data, 6);
        Assert.That(index, Is.EqualTo(5));
        Assert.Pass();
    }
    
    [Test]
    /* Last Position Match */
    public void Test2()
    {
        IComparable[] array = { 1, 2, 3, 4, 5, 6 };
        var data = new List<IComparable>(array);
        var index = BinarySearch.Search(data, 1);
        Assert.That(index, Is.EqualTo(0));
        Assert.Pass();
    }
    
    [Test]
    /* Middle Position Match */
    public void Test3()
    {
        IComparable[] array = { 1, 2, 3, 4, 5, 6 };
        var data = new List<IComparable>(array);
        var index = BinarySearch.Search(data, 4);
        Assert.That(index, Is.EqualTo(3));
        Assert.Pass();
    }
    
    [Test]
    /* Invalid Match too Big */
    public void Test4()
    {
        IComparable[] array = { 1, 2, 3, 4, 5, 6 };
        var data = new List<IComparable>(array);
        var index = BinarySearch.Search(data, 10);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    /* Invalid Match too Small */
    public void Test5()
    {
        IComparable[] array = { 1, 2, 3, 4, 5, 6 };
        var data = new List<IComparable>(array);
        var index = BinarySearch.Search(data, 0);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    /* Empty List */
    public void Test6()
    {
        var empty = new List<IComparable>();
        var index = BinarySearch.Search(empty,7);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
}