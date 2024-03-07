using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class StringMatcherTest
{
    [Test]
    public void Test1()
    {
        var results = StringMatcher.Match("GTAACAGTAAACG", "AAC", new List<char> { 'A', 'C', 'G', 'T' });
        var expected = new List<int> { 4, 11 };
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        var results = StringMatcher.Match("GTAACAGTAAACG", "AACT", new List<char> { 'A', 'C', 'G', 'T' });
        var expected = new List<int>();
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test3()
    {
        var results = StringMatcher.Match("GTAACAGTAAACG", "AA", new List<char> { 'A', 'C', 'G', 'T' });
        var expected = new List<int> { 3, 9, 10 };
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test4()
    {
        var results = StringMatcher.Match("ABCBCABCBCBC", "CBC", new List<char> { 'A', 'B', 'C'});
        var expected = new List<int> { 4, 9, 11};
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }
}