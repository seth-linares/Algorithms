namespace AlgorithmLibTest;
using AlgorithmLib;
using NUnit.Framework;

[TestFixture]
public class QuickSortTest
{
    [Test]
    /* Sort the data */
    public void Test1()
    {
        IComparable[] sortedArray = { 1, 2, 3, 4, 5, 6 };
        IComparable[] unsortedArray = { 3, 5, 2, 6, 1, 4 };
        var data = new List<IComparable>(unsortedArray);
        QuickSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    [Test]
    /* Sort already Sorted Data */
    public void Test2()
    {
        IComparable[] sortedArray = { 1, 2, 3, 4, 5, 6 };
        var data = new List<IComparable>(sortedArray);
        QuickSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    
    [Test]
    /* Empty List */
    public void Test3()
    {
        IComparable[] sortedArray = Array.Empty<IComparable>();
        var data = new List<IComparable>();
        QuickSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
}