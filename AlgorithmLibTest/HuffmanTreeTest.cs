using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class HuffmanTreeTest
{
    [Test]
    public void Test1()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        var encoded = HuffmanTree.Encode(text, map);
        Assert.That(encoded, Is.EqualTo("10010010000111100110011110101111110101111100001000111101011111000100101101011000111001110111101010000010111111010111110010010000111101000000011110101"));
        var decoded = HuffmanTree.Decode(encoded, tree);
        Assert.That(decoded, Is.EqualTo("the rain in spain stays mainly in the plain"));
        Assert.Pass();


    }
}