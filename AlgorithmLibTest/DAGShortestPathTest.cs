using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class DAGShortestPathTest
{
    [Test]
    public void Test1()
    {
        Graph g = new(6);
        g.SetLabel(0, "r");
        g.SetLabel(1, "s");
        g.SetLabel(2, "t");
        g.SetLabel(3, "x");
        g.SetLabel(4, "y");
        g.SetLabel(5, "z");
        g.AddDirectedEdge(0,1, 5);
        g.AddDirectedEdge(0, 2, 3);
        g.AddDirectedEdge(1, 2, 2);
        g.AddDirectedEdge(1, 3, 6);
        g.AddDirectedEdge(2, 3, 7);
        g.AddDirectedEdge(2, 4, 4);
        g.AddDirectedEdge(2, 5,2);
        g.AddDirectedEdge(3, 4,-1);
        g.AddDirectedEdge(3, 5, 1);
        g.AddDirectedEdge(4, 5, -2);
        var (distance, pred) = DAGShortestPath.ShortestPath(g, 1);
        Assert.That(distance[0], Is.EqualTo(Graph.INF));
        Assert.That(distance[1], Is.EqualTo(0));
        Assert.That(distance[2], Is.EqualTo(2));
        Assert.That(distance[3], Is.EqualTo(6));
        Assert.That(distance[4], Is.EqualTo(5));
        Assert.That(distance[5], Is.EqualTo(3));
        Assert.That(pred[0], Is.EqualTo(Graph.INF));
        Assert.That(pred[1], Is.EqualTo(Graph.INF));
        Assert.That(pred[2], Is.EqualTo(1));
        Assert.That(pred[3], Is.EqualTo(1));
        Assert.That(pred[4], Is.EqualTo(3));
        Assert.That(pred[5], Is.EqualTo(4));
        Assert.Pass();
    }
}