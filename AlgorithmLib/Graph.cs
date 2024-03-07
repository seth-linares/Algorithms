namespace AlgorithmLib;

public class Edge
{
    public int DestId { get; set; }
    public int Weight { get; set; }
}

public class Graph
{
    private readonly List<List<Edge>> _graph; // Id is the index.  Assume graphs are constant once created.
    private readonly List<string> _labels;
    
    public static int INF = Int32.MaxValue;

    public Graph(int size)
    {
        _graph = Enumerable.Range(0, size).Select(_ => new List<Edge>()).ToList();
        _labels = Enumerable.Range(0, size).Select(_ => "").ToList();
    }

    public void SetLabel(int id, string label)
    {
        _labels[id] = label;
    }

    public void AddDirectedEdge(int srcId, int destId, int weight=0)
    {
        var edge = new Edge { DestId = destId, Weight = weight };
        _graph[srcId].Add(edge);
    }

    public void AddUndirectedEdge(int srcId, int destId, int weight=0)
    {
        AddDirectedEdge(srcId, destId, weight);
        AddDirectedEdge(destId, srcId, weight);
    }

    public List<Edge> Edges(int id)
    {
        return _graph[id];
    }

    public int Size()
    {
        return _graph.Count;
    }

    public string GetLabel(int id)
    {
        return _labels[id];
    }
}