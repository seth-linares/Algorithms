using System.Runtime.CompilerServices;

namespace AlgorithmLib;


public static class DAGShortestPath
{
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        List<int> sorted_topology = DAGTopologicalSort.Sort(g);
        List<int> pred = new List<int>();
        List<int> distance = new List<int>(); // Rather than setting a length for these, I'll use Add() when needed. 


        for(int i = 0; i < sorted_topology.Count; i++) {
            if(sorted_topology[i] == startVertex) {
                distance.Add(0); // set 0 distance for the startVertex which will be needed for when we use our Relax() method
                pred.Add(Graph.INF);

            }

            else {
                distance.Add(Graph.INF); // Basically just putting in nulls for the non-startVertex positions
                pred.Add(Graph.INF);
            }
            
        }


        for(int i = 0; i < sorted_topology.Count; i++) { // This is the crucial loop that let's us start at the startVertex and then relax our way through and find the shortest path
            foreach(Edge e in g.Edges(sorted_topology[i])) {
                Relax(sorted_topology[i], e.DestId, e.Weight, distance, pred);

            }

        }
            









        return (distance, pred);
    } 


    public static void Relax(int u, int v, int weight, List<int> distance, List<int> pred) {

        if(distance[v] > distance[u] + weight && distance[u] != Graph.INF) { 
            distance[v] = distance[u] + weight; 
            pred[v] = u; // set the predecessor of v to u since it has now been found to have a shorter path 
        }


    } 
    
}